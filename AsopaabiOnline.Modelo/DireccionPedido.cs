using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class DireccionPedido
    {
        public DireccionPedido()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public int IdCanton { get; set; }
        public int IdDistrito { get; set; }
        public string Detalles { get; set; }

        public virtual Canton IdCantonNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
