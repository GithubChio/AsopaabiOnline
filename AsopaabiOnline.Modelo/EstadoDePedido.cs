using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{
    public enum EstadoDePedido
    {

        Reciente = 1,
        [Display(Name ="En Proceso")]
        EnProceso = 2,
        Finalizado = 3
    }
}