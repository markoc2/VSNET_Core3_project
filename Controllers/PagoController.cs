using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VBNET_Core3_project.Models;

namespace VBNET_Core3_project.Controllers
{
    public class PagoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
