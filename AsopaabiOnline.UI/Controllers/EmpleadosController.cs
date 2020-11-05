using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsopaabiOnline.LogicaDeNegocio;

namespace AsopaabiOnline.UI.Controllers
{
    public class EmpleadosController : Controller
    {
        [HttpGet]
        [Route("Empleados/Agregar")]
        public IActionResult Agregar()
        {
            return View();
        }
      

        [HttpPost]
        [Route("Empleados/Agregar")]
        public IActionResult Agregar(Modelo.Empleado elEmpleado)
        {
            try
            {


                CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
                elCoordinador.Agregar(elEmpleado);
                return RedirectToAction("Mostrar");

            }
            catch
            {

                return View();
            }
        }

        [HttpGet]
        [Route("Empleados/Mostrar")]
        public IActionResult Mostrar()
        {
            CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();

            return View(elCoordinador.ListarEmpleados());
        }

    }

}
