﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsopaabiOnline.Modelo
{   //clase modelo AspNetRoleClaims
    public partial class AspNetRoleClaims
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }


        [NotMapped]
        public virtual AspNetRoles Role { get; set; }
    }
}
