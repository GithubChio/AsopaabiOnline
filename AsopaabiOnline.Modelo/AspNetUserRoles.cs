using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        [NotMapped]
        public virtual AspNetRoles Role { get; set; }
        [NotMapped]
        public virtual AspNetUsers User { get; set; }
    }
}
