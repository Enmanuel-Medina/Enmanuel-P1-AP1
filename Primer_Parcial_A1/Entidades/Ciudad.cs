using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Primer_Parcial_A1.Entidades
{
    class Ciudad
    {
        [Key]
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
    }
}
