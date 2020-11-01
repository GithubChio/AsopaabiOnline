using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class Provincia
    {
        public Provincia()
        {
            Canton = new HashSet<Canton>();
            DireccionPedido = new HashSet<DireccionPedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Canton> Canton { get; set; }
        public virtual ICollection<DireccionPedido> DireccionPedido { get; set; }
    }
}
