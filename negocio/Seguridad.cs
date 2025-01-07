using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;


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

        public static bool validarTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return true;
                else
                    return false;

            }


            return false;
        }

        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;

        }

        public static void atraparError(Exception ex, HttpContext context)
        {
            context.Session["Error"] = ex.ToString();
            context.Response.Redirect("Error.aspx", false);
        }



    }
}
