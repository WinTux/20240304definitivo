using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemplosASP.Controllers
{
    public class ProductoController : Controller
    {
        private SuperMercadoContext context;

        public ProductoController(SuperMercadoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ProductoModelo productoModelo = new ProductoModelo(context);
            ViewBag.productos = productoModelo.getTodos();
            return View();
        }
    }
}
