using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VBNET_Core3_project.Models
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }
        [Required(ErrorMessage = "Este Campo Cliente es Requerido")]
        [ForeignKey("ClienteId")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Este Campo Tipo Prestamo es Requerido")] 
        [ForeignKey("TipoPrestamoId")]
        public int IdTipoPrestamo { get; set; }

        [Required(ErrorMessage = "Este Campo Monto es Requerido")]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Este campo debe ser mayor 0.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes { get; set; }
        [Required(ErrorMessage = "Este Campo Plazo es Requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Plazo debe ser mayor 0.")]
        public int Plazo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string EstadoPrestamo { get; set; }


        [ForeignKey("PrestamosFK")]
        public Cliente Cliente { get; set; }

        [ForeignKey("TipoPrestamoFK")]
        public TipoPrestamo TipoPrestamo { get; set; }



    }
}
