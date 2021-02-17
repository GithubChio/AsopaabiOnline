using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.AccesoADatos;
using AsopaabiOnline.LogicaDeNegocio;
using AsopaabiOnline.Modelo;
using AsopaabiOnline.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly SignInManager<User> signInManager;
       
        private readonly UserManager<User> userManager;

        public ClientesController (UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }


        [HttpGet]
        public async Task<IActionResult> Perfil()
        {

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"el perfil con el nombre= {User} no fue encontrado";
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



        [HttpGet]

        public async Task<IActionResult> EditarPerfil()
        {

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"el usuario con el id= {User} no fue encontrado";
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
                    ViewBag.ErrorMessage = $"el usuario con el id= {input} no fue encontrado";
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
                        StatusMessage = "Su perfil ha sido actualizado";
                        return RedirectToAction("Perfil", "Clientes");
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
        public async Task<IActionResult> VerDetalles()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"el usuario con el id= {User} no fue encontrado";
                return View("Error");
            }
            else
            {
                User userDetails = new Models.User()
                {
                    Id = user.Id,
                    DNI= user.DNI,
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





        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
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
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
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
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            await signInManager.RefreshSignInAsync(user);

           
            return RedirectToAction("Perfil");

        }




    }
}
