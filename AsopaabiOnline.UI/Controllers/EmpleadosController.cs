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

            Modelo.Empleado elEmpleado = new Modelo.Empleado();
            CoordinadorDeUsuarios elCoordinadorDeUsuarios =new  CoordinadorDeUsuarios();

            elEmpleado.LaListaDeUsuarios = elCoordinadorDeUsuarios.ListarUsuarios();
            return View(elEmpleado);
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


        [HttpGet]
        [Route("Empleados/Actualizar")]
        public IActionResult Actualizar(int id)
        {
            CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
            var elEmpleadoEncontrado = elCoordinador.ObtenerEmpleadoPorId(id);

            return View(elEmpleadoEncontrado);
        }
        [HttpPost]
        [Route("Empleados/Actualizar")]
        public IActionResult Actualizar(Modelo.Empleado elEmpleado)
        {
            try
            {
                CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
                elCoordinador.Actualizar(elEmpleado);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Empleados/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
            var elEmpleadoEncontrado = elCoordinador.ObtenerEmpleadoPorId(id);

            return View(elEmpleadoEncontrado);
        }

        [HttpPost]
        [Route("Empleados/Eliminar")]
        public IActionResult Eliminar(Modelo.Empleado elEmpleado)
        {
            try
            {
                CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
                elCoordinador.Eliminar(elEmpleado);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Empleados/CambiarAEmpleadoAsistente")]
        public IActionResult CambiarAEmpleadoAsistente(int id)
        {
            CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
            var elEmpleadoEncontrado = elCoordinador.ObtenerEmpleadoPorId(id);

            return View(elEmpleadoEncontrado);
        }

        [HttpPost]
        [Route("Empleados/CambiarAEmpleadoAsistente")]
        public IActionResult CambiarAEmpleadoAsistente(Modelo.Empleado elEmpleado)
        {
            try
            {
                CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
                elCoordinador.CambiarAEmpleadoAsistente(elEmpleado);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Empleados/CambiarAEmpleadoAdministrador")]
        public IActionResult CambiarAEmpleadoAdministrador(int id)
        {
            CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
            var elEmpleadoEncontrado = elCoordinador.ObtenerEmpleadoPorId(id);

            return View(elEmpleadoEncontrado);
        }

        [HttpPost]
        [Route("Empleados/CambiarAEmpleadoAdministrador")]
        public IActionResult CambiarAEmpleadoAdministrador(Modelo.Empleado elEmpleado)
        {
            try
            {
                CoordinadorDeEmpleados elCoordinador = new CoordinadorDeEmpleados();
                elCoordinador.CambiarAEmpleadoAdministrador(elEmpleado);
                return RedirectToAction("Mostrar");
            }
            catch
            {
                return View();
            }
        }

    }

}
