using EjemplosASP.Auxiliares;
using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemplosASP.Controllers
{
    public class SesionesController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("edad", 24);
            HttpContext.Session.SetString("usuario","Pepe");
            Producto producto = new Producto { 
                Id = 1,
                Nombre = "Atuncito",
                Precio = 25,
                Cantidad = 12,
                Foto = "atun.jpg"
            };
            //Ejemplo con lista de productos
            ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "prod", producto);
            return View();
        }
    }
}
