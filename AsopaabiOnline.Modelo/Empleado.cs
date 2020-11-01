using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int TipoDeEmpleado { get; set; }
        public int IdPedido { get; set; }
        public string IdUsuario { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }
    }
}
