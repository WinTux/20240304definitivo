using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace EjemplosASP.Controllers
{
    public class ArchivosController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private SuperMercadoContext db;
        public ArchivosController(IWebHostEnvironment webHostEnvironment, SuperMercadoContext db)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.db = db;
        }
        public IActionResult Index()
        {
            return View("Index", new Producto());
            
        }
        [HttpPost]
        public IActionResult Guardar(Producto prod, IFormFile foto)
        {
            //if(!ModelState.IsValid)
            //    return View("Index");
            if (foto == null || foto.Length == 0)
                return Content("Archivo nulo o corrupto");
            else
            {
                var ruta = Path.Combine(webHostEnvironment.WebRootPath, "imagenes", foto.FileName); // "C:\Usuario\Pepe\...", "/Users/Pepe/..."
                var stream = new FileStream(ruta, FileMode.Create);
                foto.CopyToAsync(stream);
                prod.Foto = foto.FileName;
                db.Productos.Add(prod);//db.Add(prod);
                db.SaveChanges();
            }
            ViewBag.producto = prod;
            return View("Guardado");
        }
    }
}
