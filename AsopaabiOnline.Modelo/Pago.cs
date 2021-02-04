using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{
    public partial class Pago
    {

        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public OpcionesDePago OpcionesDePago { get; set; }
        public int Monto { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
