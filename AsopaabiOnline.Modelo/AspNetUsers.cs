
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{     //clase modelo AspNetUsers
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            DireccionPedido = new HashSet<DireccionPedido>();
            HistorialPedido = new HashSet<HistorialPedido>();
            Pedido = new HashSet<Pedido>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }

        [NotMapped]
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string NormalizedEmail { get; set; }

        [NotMapped]
        public bool EmailConfirmed { get; set; }
        [NotMapped]
        public string PasswordHash { get; set; }
        [NotMapped]
        public string SecurityStamp { get; set; }
        [NotMapped]
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        [NotMapped]
        public bool? PhoneNumberConfirmed { get; set; }
        [NotMapped]
        public bool TwoFactorEnabled { get; set; }
        [NotMapped]
        public DateTimeOffset? LockoutEnd { get; set; }
        [NotMapped]
        public bool LockoutEnabled { get; set; }
        [NotMapped]
        public int AccessFailedCount { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TipoDeCliente CustomerType { get; set; }
        public TipoDeActividad ActivityType { get; set; }
        public int Usertype { get; set; }

       
        [NotMapped]
      
        public string FullName { get { return (FirstName + " " + SecondName  +" " + FirstLastName + " " + SecondLastName) ; } }

        [NotMapped]
        [Display(Name = "Edad")]
        public int Age { get { return (DateTime.Now - DateOfBirth).Days / 365; } }
        
       

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
      
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
       
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
      
        public virtual ICollection<DireccionPedido> DireccionPedido { get; set; }
        public virtual ICollection<HistorialPedido> HistorialPedido { get; set; }
     
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
