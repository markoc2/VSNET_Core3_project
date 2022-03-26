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
    public class PrestamoController : Controller
    {

        private readonly ILogger<PrestamoController> _logger;
        private readonly MyDbContext _mydbcontext;
        public PrestamoController(ILogger<PrestamoController> logger, MyDbContext context)
        {
            _logger = logger;
            _mydbcontext = context;
        }
        public IActionResult Index()
        {

            var prestamos = (from pe in _mydbcontext.prestamos
                             join c in _mydbcontext.clientes on pe.IdCliente equals c.IdCliente
                             join t in _mydbcontext.tipoprestamos on pe.IdTipoPrestamo equals t.IdTipoPrestamo
                             // where c.IdCliente == id
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
                             }).ToList();


            //BCVM.clientes = clientes;
            //BCVM.tipoprestamos = tipoprestamos;
            //BCVM.viewprestamos = prestamos ;

            return View(prestamos);
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            searchString = searchString.ToUpper().Replace("-", "").Replace(" ", "");

            try
            {

                var prestamos = _mydbcontext.prestamos
                                   .Join(_mydbcontext.tipoprestamos, p => p.IdTipoPrestamo, t => t.IdTipoPrestamo, (p, t) => new { p, t })
                                   .Join(_mydbcontext.clientes, ppc => ppc.p.IdCliente, c => c.IdCliente, (ppc, c) => new { ppc, c })
                                   .Where(p_c =>
                                        p_c.c.Nombre.ToUpper().Replace("-", "").Replace(" ", "").Contains(searchString) ||
                                        p_c.c.Apellido.ToUpper().Replace("-", "").Replace(" ", "").Contains(searchString) ||
                                        p_c.c.Cedula.ToUpper().Replace("-", "").Replace(" ", "").Contains(searchString) ||
                                        searchString == null)
                                   .Select(m => new
                                   {
                                       m.ppc.p.IdPrestamo,
                                       m.ppc.p.IdCliente,
                                       m.ppc.p.IdTipoPrestamo,
                                       m.ppc.t.Tipo,
                                       m.ppc.p.Monto,
                                       m.ppc.p.Interes,
                                       m.ppc.p.Plazo,
                                       m.ppc.p.FechaCreacion,
                                       m.ppc.p.CreadoPor,
                                       m.ppc.p.EstadoPrestamo,
                                       m.c.Nombre,
                                       m.c.Apellido,
                                       m.c.Telefono,
                                       m.c.Cedula
                                   }).ToList();

                //dynamic mymodel = new ExpandoObject();
                //mymodel.prestamos = prestamos;
                return View(prestamos);


            }
            catch
            {

                var prestamos = _mydbcontext.prestamos
                                  .Join(_mydbcontext.tipoprestamos, p => p.IdTipoPrestamo, t => t.IdTipoPrestamo, (p, t) => new { p, t })
                                  .Join(_mydbcontext.clientes, ppc => ppc.p.IdCliente, c => c.IdCliente, (ppc, c) => new { ppc, c })
                                  .Select(m => new
                                  {
                                      m.ppc.p.IdPrestamo,
                                      m.ppc.p.IdCliente,
                                      m.ppc.p.IdTipoPrestamo,
                                      m.ppc.t.Tipo,
                                      m.ppc.p.Monto,
                                      m.ppc.p.Interes,
                                      m.ppc.p.Plazo,
                                      m.ppc.p.FechaCreacion,
                                      m.ppc.p.CreadoPor,
                                      m.ppc.p.EstadoPrestamo,
                                      m.c.Nombre,
                                      m.c.Apellido,
                                      m.c.Telefono,
                                      m.c.Cedula
                                  }).ToList();

                dynamic mymodel = new ExpandoObject();
                mymodel.prestamos = prestamos;
                return View(mymodel);
            }
        }


        public ActionResult Create(int id = 0, string vista = "Index")
        {

            VistaPrestamoModel BCVM = new VistaPrestamoModel();

            var tipoprestamos = _mydbcontext.tipoprestamos.ToList();
            if (id > 0) { BCVM.clientes = _mydbcontext.clientes.Where(c => c.IdCliente == id).ToList(); }
            else { BCVM.clientes = _mydbcontext.clientes.ToList(); };
            Prestamo prestamo = new Prestamo { };

            BCVM.tipoprestamos = tipoprestamos;
            BCVM.prestamo = prestamo;

            return View(BCVM);
        }
        // POST: PrestamoController/Create
        [HttpPost]
        public ActionResult Create(Prestamo prestamo)
        {
            //Prestamo prestamo = _mydbcontext.prestamos.Where(x => x.IdPrestamo == IdPrestamo).FirstOrDefault();

            try
            {
                prestamo.FechaCreacion = DateTime.Now;
                prestamo.EstadoPrestamo = "Creado";
                _mydbcontext.prestamos.Add(prestamo);
                _mydbcontext.SaveChanges();

                return Json(new { result = true });
            }
            catch (Exception ex)
            {

                return Json(new { result = false, error = ex.Message });
            }


        }

        public IActionResult Save(Prestamo prestamo)
        {
            prestamo.FechaCreacion = DateTime.Now;
            prestamo.EstadoPrestamo = "Creado";
            _mydbcontext.prestamos.Add(prestamo);
            _mydbcontext.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult PrestamoAprobar(int IdPrestamo)
        {

            try
            {
                Prestamo prestamo = _mydbcontext.prestamos.Where(x => x.IdPrestamo == IdPrestamo).FirstOrDefault();
                prestamo.EstadoPrestamo = "Aprobado";
                // _mydbcontext.SaveChanges();
                decimal Monto = ((prestamo.Monto + prestamo.Interes) / prestamo.Plazo);

                 
                List<Pago> pagos = new List<Pago>();
                DateTime now = DateTime.Now.AddMonths(1);
                 
                for (int i = 0; i < prestamo.Plazo; i++)
                {
                    var first = new DateTime(now.Year, now.Month, 1);
                    pagos.Add(new Pago { IdPrestamo = IdPrestamo, FechaPago = first.AddMonths(1).AddDays(-1), Estado = "Pendiente", MontoPagado = Monto });
                    now = now.AddMonths(1);
                }
                 
                _mydbcontext.AddRange(pagos);


                _mydbcontext.SaveChanges();

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }


        }


        public IActionResult Edit(int id, string vista = "Index")
        {
            VistaPrestamoModel BCVM = new VistaPrestamoModel();

            var tipoprestamos = _mydbcontext.tipoprestamos.ToList();
            Prestamo prestamo = _mydbcontext.prestamos.Find(id);
            if (id > 0) { BCVM.clientes = _mydbcontext.clientes.Where(x => x.IdCliente == prestamo.IdCliente).ToList(); }
            else { BCVM.clientes = _mydbcontext.clientes.ToList(); };

            BCVM.tipoprestamos = tipoprestamos;
            BCVM.prestamo = prestamo;

            return View(BCVM);

        }
        // POST: ClienteController/Edit/5
        [HttpPost]
        public ActionResult Edit(Prestamo prestamo)
        {

            try
            {
                Prestamo prestamoActual = _mydbcontext.prestamos.Where(x => x.IdPrestamo == prestamo.IdPrestamo).FirstOrDefault();
                prestamoActual.Monto = prestamo.Monto;
                prestamoActual.Interes = prestamo.Interes;
                prestamoActual.Plazo = prestamo.Plazo;
                _mydbcontext.SaveChanges();
                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult Delete(int IdPrestamo)
        {
            try
            {
                Prestamo prestamo = _mydbcontext.prestamos.Where(x => x.IdPrestamo == IdPrestamo).FirstOrDefault();
                prestamo.EstadoPrestamo = "Suspendido";
                _mydbcontext.SaveChanges();

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, error = ex.Message });
            }
        }


        public IActionResult List(int id)
        {
            {

                //VistaPrestamosModel BCVM = new VistaPrestamosModel();

                //var tipoprestamos = _mydbcontext.tipoprestamos.ToList();
                //var clientes = _mydbcontext.clientes.Where(x => x.IdCliente == id).ToList();

                var prestamos = (from pe in _mydbcontext.prestamos
                                 join c in _mydbcontext.clientes on pe.IdCliente equals c.IdCliente
                                 join t in _mydbcontext.tipoprestamos on pe.IdTipoPrestamo equals t.IdTipoPrestamo
                                 where c.IdCliente == id
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
                                 }).ToList();


                //BCVM.clientes = clientes;
                //BCVM.tipoprestamos = tipoprestamos;
                //BCVM.viewprestamos = prestamos ;

                return View(prestamos);

            }
        }
    }
}
