using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemplosASP.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            ProductoModelo productoModelo = new ProductoModelo();
            ViewBag.productos = productoModelo.getTodos();
            return View();
        }
    }
}
