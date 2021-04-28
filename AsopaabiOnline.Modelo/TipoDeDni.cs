


using System.ComponentModel.DataAnnotations;

namespace AsopaabiOnline.Modelo
{ //clase enum para guardar los tipos de DNI
    public enum TipoDeDni
    {
      [Display(Name ="Cédula Física")]
        CedulaFisica = 1,

        [Display(Name = "Cédula Jurídica")]
        CedulaJuridica = 2
    }
}