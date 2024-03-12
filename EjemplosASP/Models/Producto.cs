using System.ComponentModel.DataAnnotations;

namespace EjemplosASP.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Foto { get; set; }
        [Range(0,240)]
        public int Cantidad { get; set; }
    }
}
