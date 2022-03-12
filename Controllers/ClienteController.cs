using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VBNET_Core3_project.Data;
using VBNET_Core3_project.Models;

namespace VBNET_Core3_project.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly MyDbContext _mydbcontext;
        public ClienteController(ILogger<ClienteController> logger, MyDbContext context)
        {
            _logger = logger;
            _mydbcontext = context;
        }
        public IActionResult Index()
        {

            List<Cliente> clientes = _mydbcontext.clientes.ToList();

            return View(clientes);
        }
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            searchString = searchString.ToUpper().Replace("-", "").Replace(" ", "");

            try
            {
                //if a user choose the radio button option as Subject  

                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(_mydbcontext.clientes.Where(x =>
                x.Nombre.ToUpper().Replace("-", "").Replace(" ", "").Contains(searchString) ||
                x.Apellido.ToUpper().Replace("-", "").Replace(" ", "").Contains(searchString) ||
                x.Cedula.ToUpper().Replace("-", "").Replace(" ", "").Contains(searchString) ||
                searchString == null).ToList());

            }
            catch
            {

                List<Cliente> clientes = _mydbcontext.clientes.ToList();

                return View(clientes);
            }
        }

        [HttpPost]
        public ActionResult ClienteValidar(int IdCliente)
        {
            Prestamo p = (from t1 in _mydbcontext.prestamos
                          where t1.IdCliente == IdCliente  // any identifier comparison can be done here
                          select t1).FirstOrDefault();
            if (p != null)
            {
                return Json(new { result = false, error = "El cliente tiene prestamos activos" });
               
            }
            else
            {
                try
                {
                    Cliente clientes = _mydbcontext.clientes.Where(x => x.IdCliente == IdCliente).FirstOrDefault();
                    _mydbcontext.Remove(clientes);
                    _mydbcontext.SaveChanges();

                    return Json(new { result = true });
                }
                catch (Exception ex)
                {
                    return Json(new { result = false, error = ex.Message });
                }
            }

            
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(Cliente cliente)
        {
            cliente.FechaCreacion = DateTime.Now;
            _mydbcontext.clientes.Add(cliente);
            _mydbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            Cliente cliente = _mydbcontext.clientes.Where(x => x.IdCliente == id).FirstOrDefault();

            return View(cliente);
        }
        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Cliente cliente)
        {

            try
            {
                Cliente clienteActual = _mydbcontext.clientes.Where(x => x.IdCliente == cliente.IdCliente).FirstOrDefault();
                clienteActual.Nombre = cliente.Nombre;
                clienteActual.Apellido = cliente.Apellido;
                clienteActual.Direccion = cliente.Direccion;
                clienteActual.Cedula = cliente.Cedula;
                clienteActual.Telefono = cliente.Telefono;
                clienteActual.Genero = cliente.Genero;
                _mydbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
