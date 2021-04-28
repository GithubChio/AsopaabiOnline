using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{    //clase modelo  Distrito
    public partial class Distrito
    {
        public Distrito()//constructor de la clase 
        {
            DireccionPedido = new HashSet<DireccionPedido>();
        }
        //atributos de la clase 
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
