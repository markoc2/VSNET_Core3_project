using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VBNET_Core3_project.Models;

namespace VBNET_Core3_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //simular datos 

            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente()
            {
                Nombre = "Marco Antonio",
                Apellido = "Cordoba Castrillo",
                Direccion = "aqui y alla",
                Telefono = "88810848",
                Cedula = "201-xxxxxx-xxxx1"
            });
            clientes.Add(new Cliente()
            {
                Nombre = "Anielka",
                Apellido = "Acevedo Fonseca",
                Direccion = "aqui",
                Telefono = "88810848",
                Cedula = "001-xxxxxx-xxxx1"
            });

            clientes.Add(new Cliente()
            {
                Nombre = "Matias",
                Apellido= "Cordoba Acevedo",    
                Direccion = "alla mismo",
                Telefono = "88810848",
                Cedula = "N/A"
            });

            clientes.Add(new Cliente()
            {
                Nombre = "Nubia",
                Apellido = "Cordoba Acevedo",
                Direccion = "alla y aqui",
                Telefono = "88810848",
                Cedula = "N/A"
            });

            return View(clientes);
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
