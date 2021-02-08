using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsopaabiOnline.UI.Models
{
    public class CartViewModel
    {
        public Pedido pedido { get; set; }
        public Producto producto { get; set; }
    }
}
