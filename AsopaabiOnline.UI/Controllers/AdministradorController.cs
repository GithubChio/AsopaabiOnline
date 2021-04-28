using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopaabiOnline.UI.Models;
using AsopaabiOnline.UI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsopaabiOnline.UI.Controllers
{
    //Controlador administrador 
    public class AdministradorController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;//instancia de la clase  IdentityRole para que sirva como administrador de los roles
        private readonly UserManager<User> userManager;//instancia de la clase  usuario para que sirva como administrador
        private readonly SignInManager<User> signInManager;//instancia de la clase  usuario para que sirva como administrador del inicio de sesion 
        public AdministradorController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

         //Método GET para listar los usuarios

        [HttpGet]
        public IActionResult UserList()
        {
            var list = userManager.Users;  //el administrador de usuarios brinda la lista de todos los usuarios


            return View(list);
        }

        


        //Método GET y POST para obtener y realizar la actualización de datos de los usuarios 

        [HttpGet]

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);  //el administrador de usuario encuentra el usuario por id
            var userRole = await userManager.GetRolesAsync(user); //el administrador de roles encuentra el rol del usuario solicitado
            ViewBag.Roles = userRole.ToList();//el administrador de roles  lista todos los roles del usuario buscado
            if (user == null)
            {
                ViewBag.Message = $"el usuario con el id= {id} no fue encontrado";
                return View("Error");
            }
            else
            {   //se obtienen los datos del usuario a editar 
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
                var user = await userManager.FindByIdAsync(input.Id);//el administrador de usuario encuentra el usuario por id

                var oldRoleList = await userManager.GetRolesAsync(user);//el administrador de usuario encuentra el rol del usuario solicitado

                if (user == null)
                {
                    Alert("El usuario no fue encontrado", NotificationType.warning);
                   
                    return RedirectToAction("UserList");
                }
                else
                {
                    // se editan los datos del usuario 
                    user.Id = input.Id;
                    user.UserType = input.UserType;
                    user.CustomerType = input.CustomerType;


                    if (input.UserType.Equals(AsopaabiOnline.UI.Models.Enums.UserType.Administrador)) //condicion: si el usuario selecciona el tipo de usuario Administrador
                    {
                        roleName = "Administrador"; 

                        foreach (var oldRoleName in oldRoleList.ToList())  //se recorre la lista de roles de ese usuario 
                        {
                            if (oldRoleName =="Administrador")
                            {
                                Alert($"Parece que este usuario ya tiene el rol administrador", NotificationType.warning);
                                return RedirectToAction("UserList");
                            }

                            await userManager.RemoveFromRoleAsync(user, oldRoleName); //se elimina el rol antiguo 
                        }

                        await userManager.AddToRoleAsync(user, roleName); //se agrega el rol Administrador 



                    }
                    else if (input.UserType.Equals(AsopaabiOnline.UI.Models.Enums.UserType.AsistenteAdministrativo))  //condicion: si el usuario selecciona el tipo de usuario asistente administrativo
                    {
                        roleName = "AsistenteAdministrativo";
                        foreach (var oldRoleName in oldRoleList.ToList())  //se recorre la lista de roles de ese usuario 
                        {
                            await userManager.RemoveFromRoleAsync(user, oldRoleName);  //se elimina el rol antiguo 
                        }

                        await userManager.AddToRoleAsync(user, roleName);  //se agrega el rol asistente administrativo


                    }
                    else  //condicion: si el usuario selecciona el tipo de usuario Cliente
                    {
                        foreach (var oldRoleName in oldRoleList.ToList())//se recorre la lista de roles de ese usuario 
                        {
                            if (oldRoleName == "Administrador" )
                            {
                                Alert($"No se puede cambiar de rol por que es un usuario administrador.", NotificationType.warning);
                                return RedirectToAction("UserList");
                            }
                            await userManager.RemoveFromRoleAsync(user, oldRoleName); //se elimina el rol antiguo 
                        }
                        roleName = "Cliente";
                        await userManager.AddToRoleAsync(user, roleName);//se agrega el rol Cliente

                    }


                    var elResultado = await userManager.UpdateAsync(user); //el administrador actualiza el usuario 

                    if (elResultado.Succeeded)
                    {
                        Alert("Usuario actualizado.", NotificationType.success);
                        return RedirectToAction("UserList");
                    }
                   
                }
                return View(input);
            }
            catch
            {
                Alert("Algo ha salido mal, Inténtalo de nuevo!", NotificationType.error);

                return RedirectToAction("UserList");
            }

        }


        //Método GET para listar los  detalles de los usuarios

        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await userManager.FindByIdAsync(id); //el administrador de usuario encuentra el usuario por id
            var userRole = await userManager.GetRolesAsync(user);  //el administrador de usuario encuentra el rol del usuario solicitado
            ViewBag.Roles = userRole.ToList(); //el administrador de roles  lista todos los roles del usuario buscado
            if (user == null)
            {
                ViewBag.ErrorMessage = $"el usuario con el id= {id} no fue encontrado";
                return View("Error");
            }
            else
            {//se detallan los datos del usuario para enviarlos a la vista 
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



        // Método para habilitar los usuarios que han sido deshabilitados

        [HttpPost]
        public async Task<IActionResult> Enable(User input)
        {
            try
            {
                string roleName = "Cliente";

                var user = await userManager.FindByIdAsync(input.Id);//el administrador de usuario encuentra el usuario por id 

                var oldRoleList = await userManager.GetRolesAsync(user); //el administrador de usuario encuentra el rol del usuario solicitado

                if (user == null)
                {
                    Alert("El usuario  no fue encontrado.", NotificationType.warning);
                    return View("UserList");
                }
                else
                {
                    user.Id = input.Id;

                    foreach (var oldRoleName in oldRoleList.ToList()) //se recorren la lista de roles del usuario 
                    {
                        if (oldRoleName == "Deshabilitado") //condicion: si esta deshabilitado 
                        {
                            await userManager.RemoveFromRoleAsync(user, oldRoleName); //se elimina el rol antiguo del usuario 
                            await userManager.AddToRoleAsync(user, roleName); //el administrador de usuarios agrega el nuevo rol habilitado
                           
                           
                        }
                        else
                        {
                            Alert("Este usuario ya esta habilitado.", NotificationType.warning);
                           
                            return RedirectToAction("UserList");
                        }

                    }

                    var elResultado = await userManager.UpdateAsync(user); //el administrador de usuarios actualiza el usuario

                    if (elResultado.Succeeded)
                    {
                        Alert($"Se ha habilitado a su rol de cliente. ", NotificationType.success);
                        return RedirectToAction("UserList");
                    }
                   

                }
                return View(input);
            }
            catch
            {
                Alert("Algo ha salido mal, Inténtalo de nuevo!", NotificationType.error);

                return RedirectToAction("UserList");
            }


        }

        // Método para deshabilitar los usuarios 

        [HttpPost]
        public async Task<IActionResult> Disable(User input)
        {
            try
            {
                string roleName = "Deshabilitado";

                var user = await userManager.FindByIdAsync(input.Id);//el administrador de usuario encuentra el usuario por id 

                var oldRoleList = await userManager.GetRolesAsync(user); //el administrador de usuario encuentra el rol del usuario solicitado

                if (user == null)
                {
                    Alert("El usuario no fue encontrado.", NotificationType.warning);

                    return View("UserList");
                }
                else
                {
                    user.Id = input.Id;

                    foreach (var oldRoleName in oldRoleList.ToList())//se recorren la lista de roles del usuario 
                    {
                        if (oldRoleName == "Deshabilitado")
                        {
                            Alert($"Este usuario ya esta deshabilitado.", NotificationType.warning);
                          
                          return  RedirectToAction("DisableUsersList");
                        }
                        else //condicion: si no esta deshabilitado 
                        {
                            await userManager.RemoveFromRoleAsync(user, oldRoleName);//se elimina el rol antiguo del usuario 
                            await userManager.AddToRoleAsync(user, roleName);//el administrador de usuarios agrega el nuevo rol deshabilitado
                        }

                    }

                   
                    var elResultado = await userManager.UpdateAsync(user);//el administrador de usuarios actualiza el usuario

                    if (elResultado.Succeeded)
                    {
                        Alert($"Usuario deshabilitado", NotificationType.success);
                        return RedirectToAction("UserList");
                    }
                  

                }
                return View(input);
            }
            catch
            {
                Alert("Algo ha salido mal, Inténtalo de nuevo!", NotificationType.error);

                return RedirectToAction("UserList");
            }


        }


        //Método GET para listar los usuarios deshabilitados
        [HttpGet]

        public async Task<IActionResult> DisableUsersList()
        {
            var list = await userManager.GetUsersInRoleAsync("Deshabilitado");


            return View(list);
        }


        //Método GET para listar los clientes

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


        //Método GET para listar los empleados
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


        //Método GET y POST para agregar un  rol 
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
                    Alert($"Rol agregado.", NotificationType.success);
                    return RedirectToAction("RolesList", "Administrador");
                }
                foreach (IdentityError elError in result.Errors)
                {
                    ModelState.AddModelError("", elError.Description);
                }

            }
            return View(role);
        }


        //Método GET para listar los roles existentes

        [HttpGet]
        public IActionResult RolesList()
        {
            var list = roleManager.Roles;
            return View(list);
        }

        //Método GET y POST para eliminar un  rol 
        [HttpGet]

        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                Alert($"Parece que no se encontro el rol que deseas.", NotificationType.warning);
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
                    Alert($"Parece que el rol {Rol.Name} no existe.", NotificationType.warning);
                    return View();
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

                    if (role.Name == "Deshabilitado")
                    {
                        Alert($"El rol deshabilitado no se puede eliminar por seguridad del sistema.", NotificationType.warning);
                        return RedirectToAction("RolesList", "Administrador");
                    }
                    if (role.Name == "Cliente")
                    {
                        Alert($"El rol cliente no se puede eliminar por seguridad del sistema.", NotificationType.warning);
                        return RedirectToAction("RolesList", "Administrador");
                    }
                    if (role.Name == "Administrador")
                    {
                        Alert($"El rol administrador no se puede eliminar por seguridad del sistema.", NotificationType.warning);
                        return RedirectToAction("RolesList", "Administrador");
                    }
                    if (role.Name == "AsistenteAdministrativo")
                    {
                        Alert($"El rol asistente administrativo no se puede eliminar por seguridad del sistema.", NotificationType.warning);
                        return RedirectToAction("RolesList", "Administrador");
                    }
                    var elResultado = await roleManager.DeleteAsync(role);

                    if (elResultado.Succeeded)
                    {
                        Alert($"El rol {Rol.Name} ha sido eliminado.", NotificationType.success);
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
                Alert($"Algo ha salido mal,inténtalo de nuevo", NotificationType.error);
                return View();
            }
        }







    }
}
