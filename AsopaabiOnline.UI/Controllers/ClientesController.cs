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
{
    public class ClientesController : BaseController
    {
        private readonly SignInManager<User> signInManager;
       
        private readonly UserManager<User> userManager;

        public ClientesController (UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

    
        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            try
            {

                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    Alert("El perfil no fue encontrado", NotificationType.error);

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



        [HttpGet]

        public async Task<IActionResult> EditarPerfil()
        {

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                Alert("El perfil no fue encontrado", NotificationType.warning);
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
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    Alert("El usuario no fue encontrado", NotificationType.warning);
                    return View("Error");
                }
                else
                {
                  ;
                    user.FirstName = input.FirstName;
                    user.SecondName = input.SecondName;
                    user.FirstLastName = input.FirstLastName;
                    user.SecondLastName = input.SecondLastName;
                    user.PhoneNumber = input.PhoneNumber;
                    user.PhoneNumber2 = input.PhoneNumber2;
                    user.ActivityType = input.ActivityType;


                    var elResultado = await userManager.UpdateAsync(user);

                    if (elResultado.Succeeded)
                    {
                        await signInManager.RefreshSignInAsync(user);
                        Alert("Su perfil ha sido actualizado", NotificationType.success);
                        
                        return RedirectToAction("Perfil");
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
                Alert("Algo ha salido mal, inténtalo de nuevo.", NotificationType.error);
                return RedirectToAction("Perfil");
            }

        }

       

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





        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                
                return NotFound($"No se pudo cargar el usuario con ID'{userManager.GetUserId(User)}'.");
            }

            var hasPassword = await userManager.HasPasswordAsync(user);

            if (hasPassword)
            {
                return RedirectToAction("ChangePassword");
            }

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> SetPassword(SetPassword Input)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se pudo cargar el usuario con ID'{userManager.GetUserId(User)}'.");
            }

            var addPasswordResult = await userManager.AddPasswordAsync(user, Input.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            await signInManager.RefreshSignInAsync(user);
          
            return RedirectToAction("Perfil");
        }


        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                Alert("Usuario inválido.", NotificationType.warning);
                return View();
            }

            var hasPassword = await userManager.HasPasswordAsync(user);

            if (!hasPassword)
            {
                return RedirectToAction("SetPassword");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword Input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User);
                    if (user == null)
                    {
                        Alert("Usuario inválido.", NotificationType.warning);
                        return View();
                    }

                    var changePasswordResult = await userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
                    if (changePasswordResult.Succeeded)
                    {

                        await signInManager.RefreshSignInAsync(user);

                        Alert("Contraseña cambiada.", NotificationType.success);
                        return RedirectToAction("Perfil");
                    }
                    Alert("Debe completar los campos correctamente o su contraseña actual es inválida.", NotificationType.warning);
                    return View();
                }
                else
                {
                    Alert("Debe completar los campos correctamente o su contraseña actual es inválida.", NotificationType.warning);
                    return View();
                }
            }
            catch
            {
                Alert("Algo ha salido mal, inténtalo de nuevo.", NotificationType.error);
                return RedirectToAction("Perfil");
            }

        }




    }
}
