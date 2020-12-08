using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AsopaabiOnline.Modelo
{
    public enum Categoria
    {
        Fruta = 1,
        Hortalizas = 2,
        [Description("Raíces y Tubérculos")]
        Raices_y_Tuberculos = 3,
        [Description("Flores Aromáticas")]
        FloresAromaticas = 4,
        Otro = 5

    }
}
