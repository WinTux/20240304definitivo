using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemplosASP.Controllers
{
    public class EjemplosController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.estatura = 171;
            ViewBag.usuario = "Pepe";
            ViewBag.casado = false;
            ViewBag.peso = 52.5;

            return View();
        }

        public IActionResult EjemploObjetos()
        {
            Producto prod = new Producto { 
                Id = 1,
                Nombre = "Queso",
                Precio = 20.5,
                Foto = "queso.jpg",
                Cantidad = 3
            };
            ViewBag.producto = prod;
            return View();
        }
        public IActionResult EjemploListaObjetos()
        {
            List<Producto> prods = new List<Producto> {
                new Producto
            {
                Id = 1,
                Nombre = "Queso",
                Precio = 20.5,
                Foto = "queso.jpg",
                Cantidad = 1
            },
                new Producto
            {
                Id = 2,
                Nombre = "Sardina",
                Precio = 15.7,
                Foto = "sardina.png",
                Cantidad = 2
            },
                new Producto
            {
                Id = 3,
                Nombre = "Helado",
                Precio = 22.0,
                Foto = "helado1.jfif",
                Cantidad = 5
            }
            };
            ViewBag.productos = prods;
            return View();
        }
    }
}
