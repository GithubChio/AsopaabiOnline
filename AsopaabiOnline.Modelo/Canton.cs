using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{     //clase modelo Canton
    public partial class Canton
    {   
        public Canton()  //constructor de la clase 
        {
            DireccionPedido = new HashSet<DireccionPedido>();
            Distrito = new HashSet<Distrito>();
        }
          

        //atributos de la clase 
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int IdProvincia { get; set; }

       

       
        public virtual Provincia IdProvinciaNavigation { get; set; }

        
        public virtual ICollection<DireccionPedido> DireccionPedido { get; set; }

        
        public virtual ICollection<Distrito> Distrito { get; set; }
    }
}
