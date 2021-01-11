using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AsopaabiOnline.Modelo
{
   public enum  OpcionesDePago
    {
        Efectivo =1,
        [Display(Name ="Por transacción Bancaria")]
        PorTransaccionBancaria=2,
    }
}
