using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{        //clase enum para guardar los tipos de actividades del usuario 
    public enum TipoDeActividad
    {
        [Display(Name = "Hotelería")]
        Hoteleria = 1,
        [Display(Name = "Soda/Restaurante")]
        Soda_Restaurante = 2,
        AutoConsumo = 3,
        Supermercado = 4,
        Otro = 5,

    }
}
