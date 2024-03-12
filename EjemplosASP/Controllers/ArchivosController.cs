﻿using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace EjemplosASP.Controllers
{
    public class ArchivosController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;

        public ArchivosController(IWebHostEnvironment webHostEnvironment) {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View("Index", new Producto());
        }
        [HttpPost]
        public IActionResult Guardar(Producto prod, IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
                return Content("Archivo nulo o corrupto");
            else
            {
                var ruta = Path.Combine(webHostEnvironment.WebRootPath, "imagenes", foto.FileName); // "C:\Usuario\Pepe\...", "/Users/Pepe/..."
                var stream = new FileStream(ruta, FileMode.Create);
                foto.CopyToAsync(stream);
                prod.Foto = foto.FileName;
            }
            ViewBag.producto = prod;
            return View("Guardado");
        }
    }
}
