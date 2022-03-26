using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using VBNET_Core3_project.Models;
using VBNET_Core3_project.Data;
using System.Dynamic;

namespace VBNET_Core3_project.Controllers
{
    public class PagoController : Controller
    {

        private readonly ILogger<PagoController> _logger;
        private readonly MyDbContext _mydbcontext;

        public PagoController(ILogger<PagoController> logger, MyDbContext context)
        {
            _logger = logger;
            _mydbcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int id)
        {
            { 
                var prestamos = (from pe in _mydbcontext.prestamos
                                 join c in _mydbcontext.clientes on pe.IdCliente equals c.IdCliente
                                 join t in _mydbcontext.tipoprestamos on pe.IdTipoPrestamo equals t.IdTipoPrestamo
                                 where pe.IdPrestamo == id
                                 select new VistaPrestamos
                                 {
                                     IdPrestamo = pe.IdPrestamo,
                                     IdCliente = pe.IdCliente,
                                     IdTipoPrestamo = pe.IdTipoPrestamo,
                                     Tipo = t.Tipo,
                                     Monto = pe.Monto,
                                     Interes = pe.Interes,
                                     Plazo = pe.Plazo,
                                     FechaCreacion = pe.FechaCreacion,
                                     CreadoPor = pe.CreadoPor,
                                     EstadoPrestamo = pe.EstadoPrestamo,
                                     Nombre = c.Nombre,
                                     Apellido = c.Apellido,
                                     Telefono = c.Telefono,
                                     Cedula = c.Cedula
                                 }).FirstOrDefault();

                var pago = (from pa in _mydbcontext.pagos 
                                 where pa.IdPrestamo == id
                                 select new Pago
                                 {
                                     IdPrestamo = pa.IdPrestamo,
                                     IdPago = pa.IdPago, 
                                     MontoPagado = pa.MontoPagado,
                                     FechaPago = pa.FechaPago,
                                     Estado = pa.Estado 

                                 }).ToList();


                VistaPrestamoPagoModel viewModel = new VistaPrestamoPagoModel();
                viewModel.prestamo = prestamos;
                viewModel.pago = pago;
                return View(viewModel);

            }
        }


        [HttpPost]
        public ActionResult Pagar(int IdPago,int IdPrestamo)
        {
            try
            {
                Pago pago = _mydbcontext.pagos.Where(x => x.IdPago == IdPago).FirstOrDefault();
                pago.Estado = "Pagado";
                _mydbcontext.SaveChanges();

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }
        }

    }
}
