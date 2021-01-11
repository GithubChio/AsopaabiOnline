using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{
    public enum EstadoDeProducto
    {
        Disponible = 1,
        [Display(Name = "En oferta")]
        EnOferta = 2,
        [Display(Name = "No disponible")]
        NoDisponible = 3
    }
}