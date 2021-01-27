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
        private readonly UserManager<User> userManager;

        //[HttpGet]
        //public async Task<IActionResult> Perfil(string input)
        //{

        //    var user = await userManager.FindByNameAsync(input);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"el perfil con el nombre= {input} no fue encontrado";
        //        return View("Error");
        //    }
        //    else
        //    {
        //        User model = new Models.User()
        //        {
        //            Id = user.Id,
        //            DNI= user.DNI,
        //            FirstName = user.FirstName,
        //            SecondName = user.SecondName,
        //            FirstLastName = user.FirstLastName,
        //            SecondLastName = user.SecondLastName,
                    

        //        };

        //        return View(user);

        //    }
        //}




        [HttpGet]

        public async Task<IActionResult> EditarPerfil(string id)
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
                var user = await userManager.FindByIdAsync(input.Id);
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"el usuario con el id= {input} no fue encontrado";
                    return View("Error");
                }
                else
                {
                    user.Id = input.Id;
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
                        return RedirectToAction("Profile", "Cuenta");
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
        public async Task<IActionResult> VerDetalles(string id)
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
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    FirstLastName = user.FirstLastName,
                    SecondLastName = user.SecondLastName,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumber2 = user.PhoneNumber2,
                    ActivityType = user.ActivityType,
                    

                };

                return View(user);
            }


        }

    }
}
