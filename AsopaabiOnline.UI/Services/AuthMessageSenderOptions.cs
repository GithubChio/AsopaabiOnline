using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsopaabiOnline.UI.Services
{//clase modelo para enviar correos electronicos atraves de la pagina
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
