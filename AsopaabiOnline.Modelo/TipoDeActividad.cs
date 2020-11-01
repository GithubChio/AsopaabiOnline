using System;
using System.ComponentModel;

namespace AsopaabiOnline.Modelo
{
    public enum TipoDeActividad
    {
        Hoteleria = 1,
        [Description("Soda / Restaurante")]
        Soda_Restaurante = 2,
        AutoConsumo = 3,
        Supermercado = 4
    }
}
