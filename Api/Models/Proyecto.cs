﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Models
{
    public partial class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public decimal? Presupuesto { get; set; }
        public bool? EstaDisponible { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Ciudad { get; set; }
        public string Propietario { get; set; }
        public string Cliente { get; set; }
    }
}
