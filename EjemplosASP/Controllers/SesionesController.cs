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
            ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "prod", producto);
            //Ejemplo con lista de productos
            List<Producto> productos = new List<Producto>() {
                new Producto {
                Id = 1,
                Nombre = "Atuncito",
                Precio = 25,
                Cantidad = 12,
                Foto = "atun.jpg"
            },
                new Producto {
                Id = 2,
                Nombre = "Quesito",
                Precio = 15,
                Cantidad = 24,
                Foto = "queso.jpg"
            },
                new Producto {
                Id = 3,
                Nombre = "Sardina",
                Precio = (decimal)10.5,
                Cantidad = 48,
                Foto = "sardina.png"
            }
            };
            ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "prods", productos);
            return View();
        }
    }
}
