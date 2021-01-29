using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class HistorialPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public string IdCliente { get; set; }

        public virtual AspNetUsers IdClienteNavigation { get; set; }
        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
