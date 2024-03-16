using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemplosASP.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Required(ErrorMessage = "")]
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="El nombre de producto debe ser de 4 letras o más")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column("Precio")]
        public decimal Precio { get; set; }
        [MaxLength(50)]
        [Required]
        public string Foto { get; set; }
        [Range(0,240)]
        public int? Cantidad { get; set; }
    }
}
