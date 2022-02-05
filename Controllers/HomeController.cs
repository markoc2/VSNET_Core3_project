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
                Nombre = "Marco",
                Direccion = "aqui y alla",
                Telefono = "88810848",
                Edad = 41
            });
            clientes.Add(new Cliente()
            {
                Nombre = "Anielka",
                Direccion = "aqui",
                Telefono = "88810848",
                Edad = 40
            });

            clientes.Add(new Cliente()
            {
                Nombre = "Matias",
                Direccion = "alla mismo",
                Telefono = "88810848",
                Edad = 11
            });

            clientes.Add(new Cliente()
            {
                Nombre = "Nubia",
                Direccion = "alla y aqui",
                Telefono = "88810848",
                Edad = 7
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
