using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{       //clase modelo  AspNetUserTokens
    public partial class AspNetUserTokens
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        [NotMapped]
        public virtual AspNetUsers User { get; set; }
    }
}
