using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comercio
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Session.Add("Error", "Tu sesión activa. Si deseas crear un nuevo usuario, cierra sesión.");
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void btnRegistrarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                NegocioUsuario negocio = new NegocioUsuario();

                if(Seguridad.validarTextoVacio(txtEmail.Text) || Seguridad.validarTextoVacio(txtPass.Text))
                {
                    Session.Add("Error", "Debes completar ambos campos.");
                    Response.Redirect("Error.aspx", false);
                }
                else
                {
                    usuario.Email = txtEmail.Text;
                    usuario.Pass = txtPass.Text;
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;

                    if (txtImagenPerfil.PostedFile.FileName != "")
                    {
                        string ruta = Server.MapPath("./Images/Perfil/");
                        txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                        usuario.UrlImagen = "perfil-" + usuario.Id + ".jpg";
                    }

                    negocio.agregar(usuario);
                    Session.Add("usuario", usuario);


                    Image img = (Image)Master.FindControl("imgAvatar");
                    img.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagen + "?v=" + DateTime.Now.ToString();

                    Response.Redirect("Default.aspx", false);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}