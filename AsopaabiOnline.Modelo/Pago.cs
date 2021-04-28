using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{   //clase modelo Pago
    public partial class Pago
    {
        public int Id { get; set; }
        [Display(Name = "Pedido")]
        public int IdPedido { get; set; }


        [Display(Name = "Opciones de Pago")]
        public OpcionesDePago OpcionesDePago { get; set; }
        public double Monto { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
