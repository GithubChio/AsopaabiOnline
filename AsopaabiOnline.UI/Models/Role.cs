using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsopaabiOnline.UI.Models
{
    public class Role
    {
        [Key]
        public string id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Rol")]
        public string Name { get; set; }
    }
}
