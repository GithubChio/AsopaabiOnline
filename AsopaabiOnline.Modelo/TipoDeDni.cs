


using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{
    public enum TipoDeDni
    {
      [Display(Name ="Cédula Física")]
        CedulaFisica = 1,

        [Display(Name = "Cédula Jurídica")]
        CedulaJuridica = 2
    }
}