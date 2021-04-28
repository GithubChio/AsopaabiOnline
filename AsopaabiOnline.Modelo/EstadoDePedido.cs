using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{ //clase enum para guardar los estados de los pedidos
    public enum EstadoDePedido
    {

        Reciente = 1,
        [Display(Name ="En Proceso")]
        EnProceso = 2,
        Finalizado = 3
    }
}