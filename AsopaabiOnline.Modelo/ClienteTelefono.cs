using System;
using System.Collections.Generic;

namespace AsopaabiOnline.Modelo
{
    public partial class ClienteTelefono
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int Telefono1 { get; set; }
        public int Telefono2 { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
