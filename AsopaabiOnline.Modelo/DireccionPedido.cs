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
            Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }


        [Display(Name ="Provincias")]
        public int IdProvincia { get; set; }
        [Display(Name = "Cantón")]
        public int IdCanton { get; set; }
        [Display(Name = "Distrito")]
        public int IdDistrito { get; set; }
        public string Detalles { get; set; }

        [NotMapped]
        public List<Modelo.Provincia>LaListaDeProvincias { get; set; }

        [NotMapped]
        public List<Modelo.Canton> LaListaDeCantones { get; set; }

        [NotMapped]
        public List<Modelo.Distrito> LaListaDeDistritos { get; set; }
     
        [ForeignKey("IdCanton")]
        public virtual Canton IdCantonNavigation { get; set; }
        
        [ForeignKey("IdDistrito")]
        public virtual Distrito IdDistritoNavigation { get; set; }
       
        [ForeignKey("IdProvincia")]
        public virtual Provincia IdProvinciaNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
