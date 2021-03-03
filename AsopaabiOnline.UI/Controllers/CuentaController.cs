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
using AsopaabiOnline.UI.Models.Enums;
using AsopaabiOnline.LogicaDeNegocio;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AsopaabiOnline.UI.Controllers
{
   
    public class CuentaController : BaseController
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly string DefaultRoleName = "Cliente";
        private readonly IWebHostEnvironment _env;

        public CuentaController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender, IWebHostEnvironment _env)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this._env = _env;

        }




       

        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }
        [HttpPost]
     
        public async Task<IActionResult> Register(Register model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var user = new User
                    {
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
                        ActivityType = TipoDeActividad.AutoConsumo,
                        CustomerType = TipoDeCliente.Nuevo,
                        UserType = Models.Enums.UserType.Cliente,


                    };
                    if (isExistEmail(user))
                    {
                        Alert("Parece que ya existe un usuario con este correo electrónico.", NotificationType.warning);
                        return View();
                    }

                    if (isExistDNI(user))
                    {
                        Alert("Parece que ya existe un usuario con esta cédula.", NotificationType.warning);
                        return View();
                    }
                    
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {

                        //await signInManager.SignInAsync(user, isPersistent: false);
                        await userManager.AddToRoleAsync(user, DefaultRoleName);
                        Alert("Usuario registrado.", NotificationType.success);
                        return RedirectToAction("Login");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(model);
            }
            catch
            {
                Alert("¡Algo ha salido mal!,  completa los campos obligatorios.", NotificationType.error);
                return View();
            }

        }


        public List<User> UsersListByEmail(User user)
        {

            var Database = HttpContext.User;
            var result = from User in userManager.Users
                         where User.Email == user.Email
                         select User;


            return result.ToList();
        }


        public List<User> UsersListByDNI(User user)
        {

            var Database = HttpContext.User;
            var result = from User in userManager.Users
                       where User.DNI == user.DNI
                       select User;


            return result.ToList();
        }

        public bool isExistDNI(User user)
        {
            var result = UsersListByDNI(user);
            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public bool isExistEmail(User user)
        {
            var result = UsersListByEmail(user);
            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
   
        public async Task<IActionResult> Login(Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    
                    if (isExistEmail(user))
                    {
                        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                        if (result.Succeeded)
                        {

                            return RedirectToAction("Tienda", "Home");
                        }

                        if (result.IsLockedOut)
                        {
                            Alert("Usuario bloqueado.", NotificationType.info);
                            return RedirectToAction("Lockout");
                        }
                    

                    else
                    {
                        Alert("Intento de inicio de sesión no válido.", NotificationType.warning);
                        return View();
                    }

                    }
                    else
                    {
                        Alert("Este usuario no existe, por favor registrate primero.", NotificationType.warning);
                        return View();
                    }
                    
                }

                return View(model);
            }
            catch
            {
                Alert("¡Algo ha salido mal!, este usuario no existe o revisa que las credenciales esten correctamente.", NotificationType.error);
                return View();
            }
           
        }



 
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();

            return RedirectToAction("Login");



        }

       
        

        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }



        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

       [HttpPost]

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

                await emailSender.SendEmailAsync( input.Email,"Restablecer Contraseña", templateForgotPassword(input, callbackUrl));

                return RedirectToAction("ForgotPasswordConfirmation");
            }

            return View();
        }





        public  string templateForgotPassword(ForgotPassword input, string callbackUrl)
        {

            string body = string.Empty;
            //using streamreader for reading my htmltemplate   
            var pathToFile = _env.WebRootPath
                          + Path.DirectorySeparatorChar.ToString()
                          + "EmailTemplates"
                          + Path.DirectorySeparatorChar.ToString()
                          + "ForgotPasswordEmail.html";


            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                body = SourceReader.ReadToEnd();
            }
            string  callback = $"{HtmlEncoder.Default.Encode(callbackUrl)}";
            body = body.Replace("{usuario}", input.Email);
            body = body.Replace("{callback}", callback);

            return body;
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
                Alert("Se debe proporcionar un código para restablecer la contraseña.", NotificationType.error);
                return View();
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



        [HttpGet]
        public IActionResult DisableView()
        {

            return View();
        }

    }


}

