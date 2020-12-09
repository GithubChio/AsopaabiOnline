using System.ComponentModel;

namespace AsopaabiOnline.Modelo
{
    public enum EstadoDeProducto
    {
        Disponible = 1,
        [Description("En Oferta")]
        EnOferta = 2,
        [Description("No Disponible")]
        NoDisponible = 3
    }
}