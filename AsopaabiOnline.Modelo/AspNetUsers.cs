using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Cliente = new HashSet<Cliente>();
            Empleado = new HashSet<Empleado>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

       
        [NotMapped]
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        [NotMapped]
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        [NotMapped]
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        [NotMapped]
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        [NotMapped]
        public virtual ICollection<Cliente> Cliente { get; set; }
        [NotMapped]
        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
