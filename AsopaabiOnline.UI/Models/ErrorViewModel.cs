using System;

namespace AsopaabiOnline.UI.Models
{ // clase para notificar errores

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
