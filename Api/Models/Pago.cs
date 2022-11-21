using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public string Nombre { get; set; }
        public string IdProyecto { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Pagador { get; set; }
    }
}
