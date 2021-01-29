using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.UI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
using AsopaabiOnline.Modelo;

namespace AsopaabiOnline.UI.Controllers
{
    public class CuentaController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly string DefaultRoleName = "Administrador";

        public CuentaController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
        }

        public string ReturnUrl { get; set; }

        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new  User{
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    FirstLastName = model.FirstLastName,
                    SecondLastName = model.SecondLastName,
                    DateOfBirth = model.DateOfBirth,
                    DNI = model.DNI,
                    PhoneNumber = model.PhoneNumber,
                    PhoneNumber2 = model.PhoneNumber2,
                    ActivityType = model.ActivityType,
                    CustomerType = TipoDeCliente.Nuevo,
                    UserType  = Models.Enums.UserType.Cliente
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    //await signInManager.SignInAsync(user, isPersistent: false);
                    await userManager.AddToRoleAsync(user, DefaultRoleName);
                    return RedirectToAction("Login");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Tienda", "Home");
                }

                if (result.IsLockedOut)
                {

                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
                    return View();
                }
            }

            return View(model);
        }

     
        public async Task<IActionResult> LogoutAsync()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Cuenta");

            

        }


        [HttpGet]
        public IActionResult UserList()
        {
            var list = userManager.Users;
            return View(list);
        }


        

        [HttpGet]

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"el usuario con el id= {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                User userToEdit = new Models.User()
                {
                    Id = user.Id,
                    DNI= user.DNI,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    FirstLastName = user.FirstLastName,
                    SecondLastName = user.SecondLastName,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumber2 = user.PhoneNumber2,
                    ActivityType = user.ActivityType,
                    UserType = user.UserType,
                    CustomerType= user.CustomerType
                 

                };

                return View(userToEdit);
            }

        }

        [HttpPost]

        public async Task<IActionResult> EditUser(User input)
        {
            try
            {
                string roleName = "";
                var user = await userManager.FindByIdAsync(input.Id);
               
                var oldRoleList = await userManager.GetRolesAsync(user);
              
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"el rol con el id= {input.Id} no fue encontrado";
                    return View("Error");
                }
                else
                {
                    user.Id = input.Id;
                    user.UserType = input.UserType;

                    
                   
                    if (input.UserType.Equals(AsopaabiOnline.UI.Models.Enums.UserType.Administrador))
                    {
                        roleName ="Administrador";
                      
                        foreach( var oldRoleName in oldRoleList.ToList())
                        {
                            await userManager.RemoveFromRoleAsync(user,oldRoleName);
                        }
                      
                        await userManager.AddToRoleAsync(user, roleName);



                    }
                    else if (input.UserType.Equals(AsopaabiOnline.UI.Models.Enums.UserType.AsistenteAdministrativo))
                    {
                        roleName = "AsistenteAdministrativo";
                        foreach (var oldRoleName in oldRoleList.ToList())
                        {
                            await userManager.RemoveFromRoleAsync(user, oldRoleName);
                        }
                        
                        await userManager.AddToRoleAsync(user, roleName);
                    

                    }
                    else
                    {
                        foreach (var oldRoleName in oldRoleList.ToList())
                        {
                            await userManager.RemoveFromRoleAsync(user, oldRoleName);
                        }
                        roleName = "Cliente";
                        await userManager.AddToRoleAsync(user, roleName);
                       
                    }
                    var elResultado = await userManager.UpdateAsync(user);

                    if (elResultado.Succeeded)
                    {
                        return RedirectToAction("UserList", "Cuenta");
                    }
                    foreach (var elError in elResultado.Errors)
                    {
                        ModelState.AddModelError("", elError.Description);
                    }
                }
                return View(input);
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var roles = await userManager.GetRolesAsync(user);
            ViewBag.Roles = roles.ToList();
            if (user == null)
            {
                ViewBag.ErrorMessage = $"el usuario con el id= {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                User userDetails = new Models.User()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    FirstLastName = user.FirstLastName,
                    SecondLastName = user.SecondLastName,
                    DateOfBirth = user.DateOfBirth,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumber2 = user.PhoneNumber2,
                    ActivityType = user.ActivityType,
                    UserType = user.UserType,
                    CustomerType = user.CustomerType,
                    
                   
                };

                return View(user);
            }


        }


        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(Role role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole newRole = new IdentityRole
                {
                    Name = role.Name
                };
                IdentityResult result = await roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("RolesList", "Cuenta");
                }
                foreach (IdentityError elError in result.Errors)
                {
                    ModelState.AddModelError("", elError.Description);
                }

            }
            return View(role);
        }

        [HttpGet]
        public IActionResult ListOfRoles()
        {
            var list = roleManager.Roles;
            return View(list);
        }


        [HttpGet]
       
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"el rol con el id= {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                Role roleToDelete = new Role()
                {
                    id = role.Id,
                    Name = role.Name
                };

                return View(roleToDelete);
            }

        }

        [HttpPost]
      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(Role Rol)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(Rol.id);
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"el rol con el id= {Rol.id} no fue encontrado";
                    return View("Error");
                }
                else
                {
                    Role roleToDelete = new Role()
                    {
                        id = role.Id,
                        Name = role.Name
                    };


                    role.Id = roleToDelete.id;
                    role.Name = roleToDelete.Name;

                    var elResultado = await roleManager.DeleteAsync(role);

                    if (elResultado.Succeeded)
                    {
                        return RedirectToAction("RolesList", "Cuenta");
                    }
                    foreach (var elError in elResultado.Errors)
                    {
                        ModelState.AddModelError("", elError.Description);
                    }
                }
                return View(Rol);
            }
            catch
            {
                return View();
            }
        }


        
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }


        public async Task<IActionResult> ForgotPassword(ForgotPassword input)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(input.Email);
                if (user == null )
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                var code = await userManager.GeneratePasswordResetTokenAsync(user);
               // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action( action: "ResetPassword", controller:"Cuenta",values: new { userId=user.UserName,code = code}, protocol: Request.Scheme);

                await emailSender.SendEmailAsync( input.Email,"Restablecer Contraseña",
                    $"Por favor restablezca su contraseña dando <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click aquí</a>.");

                return RedirectToAction("ForgotPasswordConfirmation");
            }

            return View();
        }



        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string code = null)
        {
            if (code == null)
            {
                return BadRequest("Se debe proporcionar un código para restablecer la contraseña.");
            }
            else
            {
                ResetPassword  resetPassword = new ResetPassword
                {
                    Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
                };
                return View(resetPassword);
            }
        }


        [HttpPost]

        public async Task<IActionResult> ResetPassword(ResetPassword Input)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(Input.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist
                    return RedirectToAction("ResetPasswordConfirmation");
                }

                var result = await userManager.ResetPasswordAsync(user,Input.Code, Input.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }



    }


}

