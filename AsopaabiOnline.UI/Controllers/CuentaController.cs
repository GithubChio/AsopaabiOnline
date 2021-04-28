﻿using System;
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
   //controlador de cuenta 
    public class CuentaController : BaseController //hereda el controlador base para la notificacion de mensajes.
    {
        private readonly SignInManager<User> signInManager; //instancia de la clase usuario para iniciar sesion 
        private readonly UserManager<User> userManager; //instancia de la clase usuario para que sirva como administrador
        private readonly RoleManager<IdentityRole> roleManager; //instancia de la clase por defecto identity role para administrar roles
        private readonly IEmailSender emailSender; // metodo para enviar mensajes
        private readonly string DefaultRoleName = "Cliente"; 
        private readonly IWebHostEnvironment _env;

        public CuentaController(UserManager<User> userManager, SignInManager<User> signInManager,          //constructor del controlador de la cuenta
            RoleManager<IdentityRole> roleManager, IEmailSender emailSender, IWebHostEnvironment _env) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this._env = _env;

        }




        //Método  GET y POST para registrar usuarios 

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
                    if (isExistEmail(user))  //se valida que la existencia del email ingresado no este
                    { 
                        Alert("Parece que ya existe un usuario con este correo electrónico.", NotificationType.warning);
                        return View();
                    }

                    if (isExistDNI(user)) //se valida que la existencia del DNI no exista 
                    {
                        Alert("Parece que ya existe un usuario con esta cédula.", NotificationType.warning);
                        return View();
                    }
                    
                    var result = await userManager.CreateAsync(user, model.Password); // el admnistrador de usuario registra un nuevo usuario
                    if (result.Succeeded) //si se registra 
                    {

                        //await signInManager.SignInAsync(user, isPersistent: false);
                        await userManager.AddToRoleAsync(user, DefaultRoleName); //se agrega el rol de cliente por defecto
                        Alert("Usuario registrado", NotificationType.success);
                        return RedirectToAction("Login");

                    }
                   
                }

                return View(model);
            }
            catch
            {
                Alert("No se ha podido registrar, inténtalo de nuevo", NotificationType.error);
                return View();
            }

        }


        // lista usarios por un  email en especifico
        public List<User> UsersListByEmail(User user)
        {

            var Database = HttpContext.User; 
            var result = from User in userManager.Users
                         where User.Email == user.Email
                         select User;   //se consulta en la lista de usuarios la existencia de un email 


            return result.ToList();
        }

        //lista usarios por un  DNI en especifico 
        public List<User> UsersListByDNI(User user)
        {

            var Database = HttpContext.User;
            var result = from User in userManager.Users
                       where User.DNI == user.DNI
                       select User;  //se consulta en la lista de usuarios la existencia de un DNI


            return result.ToList();
        }

      
        //verifica si existe el DNI buscado 
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

        //verifica si existe el email buscado
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


        //Método GET y POST para iniciar sesion 
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

                    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,false, lockoutOnFailure: true); //se inicia sesion 
                    if (result.Succeeded) //si inicia sesion  
                    {

                        return RedirectToAction("Tienda", "Home"); //se redirecciona a la tienda 
                    }

                    if (result.IsLockedOut) 
                    {
                        Alert("Usuario bloqueado", NotificationType.info);
                        return RedirectToAction("Lockout");
                    }


              
                }

                return View(model);
            }
            catch
            {
                Alert("No se ha podido iniciar sesión, inténtalo de nuevo", NotificationType.error);
                return View();
            }
        }



        //Método para cerrar sesion 
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync(); // el administrador de inicio de sesion, cierra sesion 

            return RedirectToAction("Login");



        }


        //Método para bloquear un usuario despues de 3 intentos fallidos de contraseña

        [HttpGet]
        public IActionResult Lockout()
        {
            return View();
        }


        //Método GET y POST para enviar correo para restablecer contraseña en caso de olvido de contraseña
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View(); 
        }

       [HttpPost]

        public async Task<IActionResult> ForgotPassword(ForgotPassword input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(input.Email);  //el administrador de usuarios encuentra el usuario por email.


                    if (user == null)
                    {
                        // No revele que el usuario no existe o no está confirmado
                        return RedirectToAction("ForgotPasswordConfirmation");
                    }

                    var code = await userManager.GeneratePasswordResetTokenAsync(user);
                    // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Action(action: "ResetPassword", controller: "Cuenta", values: new { userId = user.UserName, code = code }, protocol: Request.Scheme);

                    await emailSender.SendEmailAsync(input.Email, "Restablecer Contraseña", templateForgotPassword(input, callbackUrl)); // se  envia el correo con un codigo unico generado para restablecer la contraseña

                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                return View();
            }
            catch 
            {

                Alert("Algo ha ocurrido, inténtalo de nuevo", NotificationType.error);
                return View();
            }

           
        }




        //Plantilla de olvido de contraseña 
        public  string templateForgotPassword(ForgotPassword input, string callbackUrl)
        {

            string body = string.Empty;
            // uso de streamreader para leer  plantilla html

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


        //Método GET yPost para restablecer  contraseña
        [HttpGet]
        public IActionResult ResetPassword(string code = null)
        {
            try
            {
                if (code == null)
                {
                    Alert("Se debe proporcionar un código para restablecer la contraseña", NotificationType.info);
                    return View();
                }
                else
                {
                    ResetPassword resetPassword = new ResetPassword
                    {
                        Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code)) //se obtiene el codigo que fue generado y si es el mismo  se presenta la pantalla de restablecer contraseña
                    };
                    return View(resetPassword);
                }
            }
            catch 
            {

                Alert("Algo ha ocurrido, inténtalo de nuevo", NotificationType.error);
                return View();
            }
            
        }


        [HttpPost]

        public async Task<IActionResult> ResetPassword(ResetPassword Input)
        {
            try { 
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(Input.Email); // se busca el usuario por email
                if (user == null)
                {
                  
                    return RedirectToAction("ResetPasswordConfirmation");
                }

                var result = await userManager.ResetPasswordAsync(user,Input.Code, Input.Password); // se restablece la contraseña 
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }

                
            }
            return View();
            }
            catch
            {

                Alert("Algo ha ocurrido, inténtalo de nuevo", NotificationType.error);
                return View();
            }
        }


        //Método GET para confirmar el restablecimiento de contraseña

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //Método GET para mostrar la vista de deshabilitado

        [HttpGet]
        public IActionResult DisableView()
        {

            return View();
        }

    }


}

