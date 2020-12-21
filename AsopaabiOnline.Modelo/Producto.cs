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
        public int Id { get; set; }

       
        [Required(ErrorMessage ="La imagen es requerida")]
        public string Imagen { get; set; }


        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; }

        [Display(Name ="Unidad de Medida")]
        [Required(ErrorMessage = "La unidad de medida es requerida")]
        public UnidadesDeMedida? UnidadDeMedida { get; set; }

        [Required(ErrorMessage = "El precio costo es requerido")]
        [Display(Name ="Precio de Costo")]
       
        [Range(0, 9999999999999999.99)]
        public double PrecioCosto { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido")]

        [Display(Name = "Precio Unitario")]
        public double PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La utilidad es requerida")]
        public int Utilidad { get; set; }

        [Required(ErrorMessage = "La categoria es requerida")]
        public CategoriaDeProducto? Categoria { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        [Display(Name = "Estado")]
        public EstadoDeProducto? Estado { get; set; }


        [NotMapped]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
