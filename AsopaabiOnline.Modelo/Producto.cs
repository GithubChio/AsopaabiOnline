using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string Imagen { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Nombre { get; set; }


        [EnumDataType(typeof(UnidadesDeMedida))]
        [Display(Name ="Unidad de Medida")]
        public UnidadesDeMedida UnidadDeMedida { get; set; }

        [DataType(DataType.Currency,ErrorMessage ="Este campo solo permite números")]
        [Required(ErrorMessage = "El precio es requerido")]
        [Display(Name ="Precio")]
    
        public int Precio { get; set; }


        public CategoriaDeProducto Categoria { get; set; }

       
        [Display(Name = "Estado")]
        public EstadoDeProducto Estado { get; set; }


        [NotMapped]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
