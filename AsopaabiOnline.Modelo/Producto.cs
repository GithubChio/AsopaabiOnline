using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string UnidadDeMedida { get; set; }
        public double PrecioCosto { get; set; }
        public double PrecioUnitario { get; set; }
        public int Utilidad { get; set; }
        public Categoria Categoria { get; set; }
        public EstadoDeProducto Estado { get; set; }

        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
