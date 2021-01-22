using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.UI.Models;
using Microsoft.Extensions.Logging;


namespace AsopaabiOnline.UI.Controllers
{
    public class CuentaController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public CuentaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
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
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    
                    return RedirectToAction("Agregar", "Clientes");

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
                    return RedirectToAction("ListOfRoles", "Cuenta");
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
                        return RedirectToAction("ListOfRoles", "Cuenta");
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



    }


}

