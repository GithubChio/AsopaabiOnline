using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class Distrito
    {
        public Distrito()
        {
            DireccionPedido = new HashSet<DireccionPedido>();
        }

        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdCanton { get; set; }

        [NotMapped]
        public virtual Canton IdCantonNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<DireccionPedido> DireccionPedido { get; set; }
    }
}
