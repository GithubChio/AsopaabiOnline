using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class HistorialPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
