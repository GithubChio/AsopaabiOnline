using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public  AdministradorController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                    DNI = user.DNI,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    FirstLastName = user.FirstLastName,
                    SecondLastName = user.SecondLastName,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumber2 = user.PhoneNumber2,
                    ActivityType = user.ActivityType,
                    UserType = user.UserType,
                    CustomerType = user.CustomerType


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
                        roleName = "Administrador";

                        foreach (var oldRoleName in oldRoleList.ToList())
                        {
                            await userManager.RemoveFromRoleAsync(user, oldRoleName);
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
                        return RedirectToAction("UserList", "Administrador");
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
        public IActionResult CustomerList()
        {

            try
            {

                var Customer = userManager.Users.Where(user => user.UserType == Models.Enums.UserType.Cliente);
                ViewBag.Customer = Customer;
                if (Customer == null)
                {
                    return View("Error");
                }
                return View(Customer);
            }
            catch
            {
                return View();
            }
           
        }


        [HttpGet]
        public IActionResult EmployeeList()
        {

            try
            {

                var Customer = userManager.Users.Where(user => user.UserType == Models.Enums.UserType.Administrador || user.UserType == Models.Enums.UserType.AsistenteAdministrativo);
                ViewBag.Customer = Customer;
                if (Customer == null)
                {
                    return View("Error");
                }
                return View(Customer);
            }
            catch
            {
                return View();
            }

        }


    }
}
