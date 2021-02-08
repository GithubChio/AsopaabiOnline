using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class Pago
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int OpcionesDePago { get; set; }
        public float Monto { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
