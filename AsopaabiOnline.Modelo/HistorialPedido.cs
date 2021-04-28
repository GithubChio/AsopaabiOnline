using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{    //clase modelo HistorialPedido
    public partial class HistorialPedido
    {
        public int Id { get; set; }


        [Display(Name = "Pedidos")]
        public int IdPedido { get; set; }
        public string IdCliente { get; set; }

        public virtual AspNetUsers IdClienteNavigation { get; set; }
        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
