using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsopaabiOnline.UI.Models.Enums
{
    public enum UserType
    {

        Administrador =1,
        Cliente = 2,

        [Display(Name ="Asistente Administrativo")]
        AsistenteAdministrativo = 3

    }
}
