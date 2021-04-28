using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.UI.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{ // controlador de clientes 
    public class ClientesController : BaseController//hereda el controlador base para la notificacion de mensajes.
    {
        private readonly SignInManager<User> signInManager; //instancia de la clase de usuario para iniciar sesion 
       
        private readonly UserManager<User> userManager; //instancia de la clase  usuario para administrar los usuarios

        public ClientesController (UserManager<User> userManager, SignInManager<User> signInManager)//constructor del controlador de clientes
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //Método para mostrar el perfil del usuario

        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            try
            {

                var user = await userManager.GetUserAsync(User); //el administrador de usuario obtiene el usuario logueado
                if (user == null) //si no se encuentra el usuario 
                {
                    Alert("El perfil no fue encontrado", NotificationType.info); //mensaje informativo

                    return View("Error");
                }
                else
                {
                    User model = new Models.User() 
                    {
                        Id = user.Id,
                        DNI = user.DNI,
                        FirstName = user.FirstName,
                        SecondName = user.SecondName,
                        FirstLastName = user.FirstLastName,
                        SecondLastName = user.SecondLastName,
                        Email= user.Email,
                        ActivityType = user.ActivityType


                    };



                    return View(model);
                }
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo.", NotificationType.error);
                return RedirectToAction("Perfil");
            }
        }


        //Método  GET y POST obtener el usuario y editar los datos solicitados.
        [HttpGet]

        public async Task<IActionResult> EditarPerfil()
        {

            var user = await userManager.GetUserAsync(User); //el administrador de usuario obtiene el usuario logueado
            if (user == null)
            {
                Alert("El perfil no fue encontrado", NotificationType.info); //mensaje informativo 
                return View("Error");
            }
            else
            {
                User userToEdit = new Models.User()
                {
                    Id = user.Id,   
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    FirstLastName = user.FirstLastName,
                    SecondLastName = user.SecondLastName,
                  
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumber2 = user.PhoneNumber2,
                    ActivityType = user.ActivityType

                };

                return View(userToEdit);
            }

        }

        [HttpPost]

        public async Task<IActionResult> EditarPerfil(User input)
        {
            try
            {
                var user = await userManager.GetUserAsync(User); //el administrador de usuario obtiene el usuario logueado
                if (user == null)
                {
                    Alert("El usuario no fue encontrado", NotificationType.warning);
                    return View("Error");
                }
                else
                {
                    //se asignan los valores ingresados en vez de los anteriores
                  
                    user.FirstName = input.FirstName;
                    user.SecondName = input.SecondName;
                    user.FirstLastName = input.FirstLastName;
                    user.SecondLastName = input.SecondLastName;
                    user.PhoneNumber = input.PhoneNumber;
                    user.PhoneNumber2 = input.PhoneNumber2;
                    user.ActivityType = input.ActivityType;

                    
                    var elResultado = await userManager.UpdateAsync(user);  //el administrador de usuario actualiza el perfil 

                    if (elResultado.Succeeded)
                    {
                        await signInManager.RefreshSignInAsync(user);//se actualiza el inicio de sesion 
                        Alert("Perfil editado correctamente", NotificationType.success);
                        
                        return RedirectToAction("Perfil");
                    }
                   
                }
                return View(input);
            }
            catch
            {
                Alert("No se ha podido actualizar su perfil, inténtalo de nuevo.", NotificationType.error);
                return RedirectToAction("Perfil");
            }

        }


        //Método para mostrar  los detalles del usuario
        [HttpGet]
        public async Task<IActionResult> VerDetalles()
        {
            try
            {
                var user = await userManager.GetUserAsync(User);

                if (user == null)
                {
                    Alert("El usuario no fue encontrado", NotificationType.warning);
                    return View("Error");
                }
                else
                {
                    User userDetails = new Models.User()
                    {
                        Id = user.Id,
                        DNI = user.DNI,
                        FirstName = user.FirstName,
                        SecondName = user.SecondName,
                        FirstLastName = user.FirstLastName,
                        SecondLastName = user.SecondLastName,
                        DateOfBirth = user.DateOfBirth,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        PhoneNumber2 = user.PhoneNumber2,
                        ActivityType = user.ActivityType,


                    };

                    return View(userDetails);
                }
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo.", NotificationType.error);
                return RedirectToAction("Perfil");
            }
        }


        //Método  GET y POST de seguridad para crear una nueva contraseña en caso que el usuario no disponga de una.
        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            try
            {
                var user = await userManager.GetUserAsync(User); //el administrador de usuario obtiene el usuario logueado
                if (user == null)
                {
                    Alert("No se pudo cargar el usuario ", NotificationType.warning);

                    return View();

                }

                var hasPassword = await userManager.HasPasswordAsync(user); //el administrador busca la contraseña del usuario 

                if (hasPassword) //si tiene contraseña
                {

                    return RedirectToAction("ChangePassword"); //se redige a la pantalla de cambiar contraseña
           
                }

                return View();
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo", NotificationType.error);
                return RedirectToAction("Perfil");
            }
        }



        [HttpPost]
        public async Task<IActionResult> SetPassword(SetPassword Input)
        {

            try
            {
                var user = await userManager.GetUserAsync(User);//el administrador de usuario obtiene el usuario logueado
                if (user == null)
                {
                    Alert("No se pudo cargar el usuario ", NotificationType.warning);
                }

                var addPasswordResult = await userManager.AddPasswordAsync(user, Input.NewPassword); //el administrador de usuarios agrega la nueva contraseña
                if (addPasswordResult.Succeeded)
                {

                    await signInManager.RefreshSignInAsync(user); //se refresca el inicio de sesion 

                }

                return RedirectToAction("Perfil");
            }
            catch 
            {

                Alert("Algo ha salido mal, inténtalo de nuevo", NotificationType.error);
                return RedirectToAction("Perfil");
            }

           
        }


        //Método  GET y POST para cambiar la  contraseña.

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            try { 
            var user = await userManager.GetUserAsync(User); //el administrador de usuario obtiene el usuario logueado
                if (user == null)
            {
                Alert("No se pudo cargar el usuario", NotificationType.warning);
                return View();
            }

            var hasPassword = await userManager.HasPasswordAsync(user); // el administrador de usuario verifica si hay una contraseña

            if (!hasPassword) //si no hay contraseña
            {
                return RedirectToAction("SetPassword"); //redirecciona a la pantalla de establecer contraseña
            }

            return View();
        }
            catch 
            {

                Alert("Algo ha salido mal, inténtalo de nuevo", NotificationType.error); 
                return RedirectToAction("Perfil");
    }
}

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword Input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User); //el administrador de usuario obtiene el usuario logueado
                    if (user == null)
                    {
                        Alert("No se pudo cargar el usuario", NotificationType.warning);
                        return View();
                    }

                    var changePasswordResult = await userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword); // el administrador de usuario cambia la contraseña
                    if (changePasswordResult.Succeeded)
                    {

                        await signInManager.RefreshSignInAsync(user); //se actualiza el inicio de sesion con la nueva contraseña

                        Alert("Contraseña cambiada.", NotificationType.success);
                        return RedirectToAction("Perfil");
                    }
                   
                }
                Alert("Debe completar los campos correctamente o su contraseña actual es inválida", NotificationType.warning);
                return View();
            }
            catch
            {
                Alert("No se ha podido cambiar su contraseña, inténtalo de nuevo.", NotificationType.error);
                return RedirectToAction("Perfil");
            }

        }




    }
}
