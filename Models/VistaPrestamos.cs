using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VBNET_Core3_project.Models
{
    public class VistaPrestamos 
    {
        public int IdPrestamo { get; set; } 
        public int IdCliente { get; set; } 
        public int IdTipoPrestamo { get; set; } 
        public string Tipo { get; set; }
        public decimal Monto { get; set; } 
        public decimal Interes { get; set; } 
        public int Plazo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string EstadoPrestamo { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Telefono { get; set; } 
        public string Cedula { get; set; } 

    }
    public class VistaPrestamosModel
    {
        public List<Cliente> clientes { get; set; }
        public List<Prestamo> prestamos { get; set; }
        public List<TipoPrestamo> tipoprestamos { get; set; } 
        
    }

    public class VistaPrestamoModel
    {
        public List<Cliente> clientes { get; set; }
        public Prestamo prestamo { get; set; }
        public List<TipoPrestamo> tipoprestamos { get; set; }

    }
}
