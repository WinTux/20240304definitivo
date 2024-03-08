using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemplosASP.Controllers
{
    [Route("Ejemplos")]
    public class EjemplosController : Controller
    {
        private IConfiguration configuration;

        public EjemplosController(IConfiguration configuration) {
            this.configuration = configuration;
        }
        [Route("Index")]
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

        public IActionResult EjemploSettings()
        {
            ViewBag.valor1 = configuration["Texto"];
            ViewBag.valor2 = configuration["Terminado"];
            ViewBag.valor3 = configuration["MisConfiguraciones:configuracion3"];
            ViewBag.valor4 = configuration["Logging:LogLevel:Default"];

            return View("PaginaAppSetting");
        }

        public IActionResult EjemploQueryString1([FromQuery(Name = "usuario")] string usuario) {
            ViewBag.usu = usuario;
            return View("EjemploQS1");
        }

        public IActionResult EjemploQueryString2([FromQuery(Name = "usuario")] string usuario, [FromQuery(Name = "password")] int Password)
        {
            ViewBag.usu = usuario;
            ViewBag.pwd = Password;
            return View("EjemploQS2");
        }

        public IActionResult EjemploQueryString3()
        {
            string usuario = HttpContext.Request.Query["usuario"].ToString();
            int password = int.Parse( HttpContext.Request.Query["password"].ToString());
            ViewBag.usu = usuario;
            ViewBag.pwd = password;
            return View("EjemploQS2");
        }
        [Route("param/{codigo}")]
        public IActionResult EjemploParametrosRoute(int codigo)
        {
            ViewBag.codigo = codigo;
            return View("EjemploParamRoute");
        }
        [Route("param2/{codigo}/{categoria}")]
        public IActionResult EjemploParametrosRoute2(int codigo, int categoria)
        {
            ViewBag.codigo = codigo;
            ViewBag.categoria = categoria;
            return View("EjemploParamRoute2");
        }
    }
}
