namespace EjemplosASP.Models
{
    public class ProductoModelo
    {
        List<Producto> productos;
        /*
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
                Precio = 10.5,
                Cantidad = 48,
                Foto = "sardina.png"
            }
            };*/
    public ProductoModelo(SuperMercadoContext context)
    {
            productos = context.Productos.ToList();
    }
    public List<Producto> getTodos() {
            return productos;
        }
        public Producto getById(int id) { 
            return productos.Single(prod => prod.Id == id);//SELECT * FROM Producto WHERE Id = id;
        }
    }
}
