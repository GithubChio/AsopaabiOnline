using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{                //clase modelo Provincia
    public partial class Provincia
    {
        public Provincia()//constructor de la clase 
        {
             Canton = new HashSet<Canton>();
            DireccionPedido = new HashSet<DireccionPedido>();
        }

        //atributos de la clase 

        [Key]
        public int Id { get; set; }
       
        public string Nombre { get; set; }

       
         [NotMapped]
        public virtual ICollection<Canton> Canton { get; set; }

        [NotMapped]
        public virtual ICollection<DireccionPedido> DireccionPedido { get; set; }
    }
}
