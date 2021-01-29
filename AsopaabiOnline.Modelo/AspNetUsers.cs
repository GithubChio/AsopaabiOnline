
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            HistorialPedido = new HashSet<HistorialPedido>();
            Pedido = new HashSet<Pedido>();
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
        public string PhoneNumber2 { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CustomerType { get; set; }
        public int? ActivityType { get; set; }
        public int Usertype { get; set; }

        [NotMapped]
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        [NotMapped]
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        [NotMapped]
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        [NotMapped]
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
        [NotMapped]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
