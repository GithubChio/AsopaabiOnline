

using System.ComponentModel.DataAnnotations;


namespace AsopaabiOnline.Modelo
{
    //clase enum para guardar las categorias de producto
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
