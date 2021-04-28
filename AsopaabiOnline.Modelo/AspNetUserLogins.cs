using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{   //clase modelo AspNetUserLogins
    public partial class AspNetUserLogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public string UserId { get; set; }

        [NotMapped]
        public virtual AspNetUsers User { get; set; }
    }
}
