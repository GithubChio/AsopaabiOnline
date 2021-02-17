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
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public  AdministradorController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
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
        public async Task<IActionResult>Disable(string id)
        {
            var user = await userManager.FindByIdAsync(id);
           
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
                    IsDisable =  user.IsDisable


                };

                return View(user);
            }


        }


        [HttpPost]
        public async Task<IActionResult> DisableAsync(User input, bool disable)
        {
            try
            {
                var user = await userManager.FindByIdAsync(input.Id);
                if (user != null && user.IsDisable == true)
                {
                    await userManager.SetLockoutEnabledAsync(user, disable);

         
                    return RedirectToAction("UserList");
                }
               
            }
            catch
            {
                ViewBag.ErrorMessage = $"el usuario con el id = {input.Id} no fue encontrado";
                return View("Error");
            }
            
            return View();
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
                    return RedirectToAction("RolesList", "Administrador");
                }
                foreach (IdentityError elError in result.Errors)
                {
                    ModelState.AddModelError("", elError.Description);
                }

            }
            return View(role);
        }

        [HttpGet]
        public IActionResult RolesList()
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
                        return RedirectToAction("RolesList", "Administrador");
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
