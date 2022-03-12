using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VBNET_Core3_project.Models
{
    public class TipoPrestamo
    {
        [Key]
        public int IdTipoPrestamo { get; set; } 
        [Required(ErrorMessage = "Este Campo Tipo es Requerido")] 
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Este Campo Interes es Requerido")]
        public decimal Interes { get; set; }


    }
}
