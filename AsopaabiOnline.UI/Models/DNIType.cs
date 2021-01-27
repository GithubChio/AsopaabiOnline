using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.UI.Models
{
    public enum DNIType
    {
        [Display(Name = "Cédula Física")]
        cedulaFisica =1,
            [Display(Name = "Cédula Jurídica")]
        cedulaJuridica =2
    }
}