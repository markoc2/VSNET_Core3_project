using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.Extensions.Logging; 
using VBNET_Core3_project.Data;
using VBNET_Core3_project.Models;

namespace VBNET_Core3_project.Controllers
{
    public class TipoPrestamoController : Controller
    {

        private readonly ILogger<TipoPrestamoController> _logger;
        private readonly MyDbContext _mydbcontext;
        public TipoPrestamoController(ILogger<TipoPrestamoController> logger, MyDbContext context)
        {
            _logger = logger;
            _mydbcontext = context;
        }
        // GET: TipoPrestamoController
        public ActionResult Index()
        {
            List<TipoPrestamo> tipoprestamo = _mydbcontext.tipoprestamos.ToList();

            return View(tipoprestamo);
        }

        

        // GET: TipoPrestamoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPrestamoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoPrestamo tipoprestamos)
        {
            try
            { 
                _mydbcontext.tipoprestamos.Add(tipoprestamos);
                _mydbcontext.SaveChanges();  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPrestamoController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoPrestamo tipoprestamo = _mydbcontext.tipoprestamos
                                                .Where(x => x.IdTipoPrestamo == id)
                                                .FirstOrDefault();

            return View(tipoprestamo); 
        }

        // POST: TipoPrestamoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoPrestamo tipoprestamos)
        {
            try
            {
                TipoPrestamo tipoprestamosActual = _mydbcontext.tipoprestamos.Where(x => x.IdTipoPrestamo == id).FirstOrDefault();
                tipoprestamosActual.Tipo = tipoprestamos.Tipo;
                tipoprestamosActual.Interes = tipoprestamos.Interes;
                _mydbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPrestamoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                TipoPrestamo tipoprestamosActual = _mydbcontext.tipoprestamos.Where(x => x.IdTipoPrestamo == id).FirstOrDefault();
                _mydbcontext.Remove(tipoprestamosActual);
                _mydbcontext.SaveChanges();

                List<TipoPrestamo> tipoprestamo = _mydbcontext.tipoprestamos.ToList();

                return RedirectToAction("Index", tipoprestamo);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: TipoPrestamoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
