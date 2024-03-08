using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjemplosASP.Models
{
    public class CuentaViewModel
    {
        public Cuenta cuenta { get; set; }
        public List<Lenguaje> lengueajes { get; set; }
        public SelectList cargos { get; set; }
    }
}
