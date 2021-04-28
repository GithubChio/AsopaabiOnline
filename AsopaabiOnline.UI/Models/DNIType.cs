using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.UI.Models
{  //Clase numerica para el tipo de dni 
    public enum DNIType
    {
        [Display(Name = "Cédula Física")]
        cedulaFisica =1,
            [Display(Name = "Cédula Jurídica")]
        cedulaJuridica =2
    }
}