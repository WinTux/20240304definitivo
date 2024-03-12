using EjemplosASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemplosASP.Controllers
{
    public class FormularioController : Controller
    {
        public IActionResult Index()
        {
            CuentaViewModel cuentaViewModel = new CuentaViewModel();
            cuentaViewModel.cuenta = new Cuenta()
            {
                Id = 1,
                Disponible = true,
                genero = "M"
            };
            cuentaViewModel.lengueajes = new List<Lenguaje>() {
                new Lenguaje() {id="len01",nombre="C#",estaTickeado=true},
                new Lenguaje() {id="len02",nombre="Java",estaTickeado=false},
                new Lenguaje() {id="len03",nombre="Python",estaTickeado=true},
                new Lenguaje() {id="len04",nombre="C++",estaTickeado=false}
            };
            List<Cargo> cargos = new List<Cargo>() {
                new Cargo { id="c01", nombre="Auxiliar en desarrollo"},
                new Cargo { id="c02", nombre="Pasante en desarrollo 2"},
                new Cargo { id="c03", nombre="Tecnico Administrador de Sistemas 4"}
            };
            cuentaViewModel.cargos = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(cargos, "id", "nombre");

            return View("Index",cuentaViewModel);
        }
        [HttpPost]
        public IActionResult Guardar(CuentaViewModel cuentaViewModel, List<Lenguaje> lenguajes) {
            cuentaViewModel.cuenta.Lenguajes = new List<string>();
            foreach (Lenguaje len in lenguajes) {
                if (len.estaTickeado)
                    cuentaViewModel.cuenta.Lenguajes.Add(len.id);
            }
            ViewBag.cuenta = cuentaViewModel.cuenta;
            return View("Registrado");
        }
    }
}
