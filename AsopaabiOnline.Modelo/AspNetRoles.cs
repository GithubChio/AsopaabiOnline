using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{  //clase modelo AspNetRoles
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }


        [NotMapped]
        public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        [NotMapped]
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
