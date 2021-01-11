using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class Canton
    {
        public Canton()
        {
            DireccionPedido = new HashSet<DireccionPedido>();
            Distrito = new HashSet<Distrito>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdProvincia { get; set; }

       

        [NotMapped]
        public virtual Provincia IdProvinciaNavigation { get; set; }

      
        public virtual ICollection<DireccionPedido> DireccionPedido { get; set; }

        [NotMapped]
        public virtual ICollection<Distrito> Distrito { get; set; }
    }
}
