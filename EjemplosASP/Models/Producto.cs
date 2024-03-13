using System.ComponentModel.DataAnnotations;

namespace EjemplosASP.Models
{
    public class Producto
    {
        [Required(ErrorMessage = "")]
        public int Id { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="El nombre de producto debe ser de 4 letras o más")]
        [MaxLength(20)]
        public string Nombre { get; set; }
        [Required]
        public double Precio { get; set; }
        public string Foto { get; set; }
        [Range(0,240)]
        public int Cantidad { get; set; }
    }
}
