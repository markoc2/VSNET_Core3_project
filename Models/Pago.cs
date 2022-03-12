using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VBNET_Core3_project.Models
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }
        [Required(ErrorMessage = "Este Campo Nombre es Requerido")]
        public int IdPrestamo { get; set; }
        [Required(ErrorMessage = "Este Campo Nombre es Requerido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal  MontoPagado { get; set; }
        public DateTime FechaPago { get; set; }
         

        [ForeignKey("PagosFK")]
        public Prestamo Prestamo { get; set; }

    }
}
