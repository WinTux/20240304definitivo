using EjemplosASP.Auxiliares;
using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemplosASP.Controllers
{
    public class CarritoController : Controller
    {
        private SuperMercadoContext context;

        public CarritoController(SuperMercadoContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Item> carrito = ConversorSesion.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            ViewBag.carrito = carrito;
            ViewBag.total = carrito.Sum(item => item.producto.Precio * item.cantidad);
            return View();
        }
        [Route("agregar/{id}")]
        public IActionResult agregar(int id)
        {
            ProductoModelo productoModelo = new ProductoModelo(context);
            if (ConversorSesion.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito") == null) { 
                List<Item> carrito = new List<Item>();
                carrito.Add(new Item
                {
                    producto = productoModelo.getById(id),
                    cantidad = 1
                });
                ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "carrito", carrito);
            }
            else
            {
                List<Item> carrito = ConversorSesion.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
                int indice = existe(id);
                if (indice != -1)
                    carrito[indice].cantidad++;
                else
                    carrito.Add(new Item { producto = productoModelo.getById(id), cantidad=1});
                ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "carrito", carrito);
            }
            return RedirectToAction("Index");
        }
        private int existe(int id) {
            List<Item> carrito = ConversorSesion.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            for (int i = 0; i < carrito.Count; i++)
                if (carrito[i].producto.Id == id)
                    return i;
            return -1;
        }
        [Route("eliminar/{id}")]
        public IActionResult eliminar(int id)
        {
            List<Item> carrito = ConversorSesion.GetObjetoDesdeJson<List<Item>>(HttpContext.Session, "carrito");
            int indice = existe(id);
            carrito.RemoveAt(indice);
            ConversorSesion.ConvertirObjetoAJson(HttpContext.Session, "carrito", carrito);
            return RedirectToAction("Index");
        }
    }
    
}
