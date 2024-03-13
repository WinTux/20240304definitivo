using System.Runtime.CompilerServices;
using Newtonsoft.Json;
namespace EjemplosASP.Auxiliares
{
    public static class ConversorSesion
    {
        public static void ConvertirObjetoAJson(this ISession sesion, string llave, object valor) {
            sesion.SetString(llave, JsonConvert.SerializeObject(valor));
        }
        public static T GetObjetoDesdeJson<T>(this ISession sesion, string llave) {
            var valor = sesion.GetString(llave);//{"prop":"val"}
            return valor == null ? default(T) : JsonConvert.DeserializeObject<T>(valor);
        }
    }
}
