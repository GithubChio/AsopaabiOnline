using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class DireccionPedido
    {
        public DireccionPedido()
        {
            //Pedido = new HashSet<Pedido>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage ="Este campo es requerido")]
            
        [Display(Name ="Provincia")]
        public int IdProvincia { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Cantón")]
        public int IdCanton { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Distrito")]
        public int IdDistrito { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        public string Detalles { get; set; }




        [NotMapped]
        public List<Modelo.Provincia>LaListaDeProvincias { get; set; }

       

        [ForeignKey("IdCanton")]
        public virtual Canton IdCantonNavigation { get; set; }

       
        [ForeignKey("IdDistrito")]
        public virtual Distrito IdDistritoNavigation { get; set; }

      

        [ForeignKey("IdProvincia")]
        public virtual Provincia IdProvinciaNavigation { get; set; }


       
        public virtual ICollection<Pedido> Pedido { get; set; }

       
    }
}
