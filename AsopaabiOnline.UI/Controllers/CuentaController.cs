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

namespace AsopaabiOnline.UI.Controllers
{
   
    public class CuentaController : BaseController
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly string DefaultRoleName = "Cliente";

        public CuentaController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
        }

    
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
                var user = new User {
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
                    UserType = Models.Enums.UserType.Cliente,
                    

                };
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
                    Alert("Intento de inicio de sesión no válido.", NotificationType.error);
                    return View();
                }
            }

            return View(model);
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

        
    }


}

