﻿using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{                //clase enum para guardar las unidades de medida
    public enum UnidadesDeMedida
    {
        [Display(Name ="Empaque Kg")]
        Empaque_kg = 1,
         Gramos = 2,
         Unidad = 3,
         Rollo = 4,
         Bandeja = 5,


    }
}