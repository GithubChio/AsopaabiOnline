using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{     //clase modelo  DireccionPedido
    public partial class DireccionPedido
    {
        public DireccionPedido()//constructor de la clase 
        {
            Pedido = new HashSet<Pedido>();
        }

        //atributos de la clase 

        [Key]
      
        public int Id { get; set; }


            
        [Display(Name ="Provincia")]
        public int IdProvincia { get; set; }


       
        [Display(Name = "Cantón")]
        public int IdCanton { get; set; }


        [Display(Name = "Distrito")]
        public int IdDistrito { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        public string Detalles { get; set; }

        public string IdCliente { get; set; }


        [NotMapped]
        public List<Modelo.Provincia>LaListaDeProvincias { get; set; }

       

        [ForeignKey("IdCanton")]
        public virtual Canton IdCantonNavigation { get; set; }

        [ForeignKey("IdCliente")]
        public virtual AspNetUsers IdClienteNavigation { get; set; }
        

        [ForeignKey("IdDistrito")]
        public virtual Distrito IdDistritoNavigation { get; set; }

      

        [ForeignKey("IdProvincia")]
        public virtual Provincia IdProvinciaNavigation { get; set; }


       
        public virtual ICollection<Pedido> Pedido { get; set; }

       
    }
}
