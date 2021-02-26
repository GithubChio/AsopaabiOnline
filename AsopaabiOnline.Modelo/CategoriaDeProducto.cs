

using System.ComponentModel.DataAnnotations;


namespace AsopaabiOnline.Modelo
{
    public enum CategoriaDeProducto
    {
        Frutas = 1,
        Hortalizas = 2,
        [Display(Name = "Raíces y Tubérculos")]
        
        Raices_y_Tuberculos = 3,
        [Display(Name = "Flores Aromáticas")]
        
        FloresAromaticas = 4,
        Otros = 5

    }
}
