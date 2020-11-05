using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Provincias Nombre { get; set; }

        [NotMapped]
        public virtual ICollection<Canton> Canton { get; set; }
        [NotMapped]
        public virtual ICollection<DireccionPedido> DireccionPedido { get; set; }
    }
}
