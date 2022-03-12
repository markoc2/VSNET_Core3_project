using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VBNET_Core3_project.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        
        [StringLength(100)]
        [Required(ErrorMessage = "Este Campo Nombre es Requerido")]
        public string Nombre { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Este Campo Nombre es Requerido")]
        public string Apellido { get; set; }

        [StringLength(500)]
        public string Direccion { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Este Campo Nombre es Requerido")]
        public string Telefono { get; set; }
        public int Genero { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Este Campo Nombre es Requerido")]
        public string Cedula { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }

         
    }
}
