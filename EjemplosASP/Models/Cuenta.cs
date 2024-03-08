namespace EjemplosASP.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Descripcion { get; set; }
        public bool Disponible { get; set; }
        public List<string> Lenguajes { get; set; }
        public string genero;
        public string cargo;

    }
}
