using dominio;
using Microsoft.Win32;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class SiteMaster : MasterPage
    {
        public List<Articulo> listaArticulos { get; set; }
        public List<Marca> listaMarcas { get; set; }
        public List<Categoria> listaCategorias { get; set; }
        public List<Articulo> listaFiltrada { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page is Favoritos || Page is MiPerfil || Page is Modificar || Page is Productos)
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Ingresar.aspx", false);
           
            }

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (!string.IsNullOrEmpty(usuario.UrlImagen))
                    imgAvatar.ImageUrl = "~/Images/Perfil/" + ((Usuario)Session["usuario"]).UrlImagen + "?v=" + DateTime.Now.Ticks.ToString();


                if (usuario.Admin == false && Page is Modificar || usuario.Admin == false && Page is Productos)
                {
                    Session.Add("Error", "Debes tener perfil admin para ingresar.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            //else
            //{
            //    imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png" + "?v=" + DateTime.Now.Ticks.ToString();
            //}





        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;

            Session.Add("busqueda", busqueda);
            Response.Redirect("Buscador.aspx", false);
            

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Response.Redirect("Ingresar.aspx");
        }
    }
}