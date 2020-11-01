using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class DetallePedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
