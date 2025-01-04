using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool EsImagenValida(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD"; 

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Verificar si la solicitud fue exitosa y si el contenido es una imagen
                    return response.StatusCode == HttpStatusCode.OK &&
                           response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase);
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
