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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Session.Add("Error", "Debes desloguearte si deseas iniciar sesion con otro usuario.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnIngresarCuenta_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            NegocioUsuario negocio = new NegocioUsuario();

            try
            {
                if(Seguridad.validarTextoVacio(txtEmail.Text) || Seguridad.validarTextoVacio(txtPass.Text)){
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx");
                }
                else
                {
                    usuario.Email = txtEmail.Text;
                    usuario.Pass = txtPass.Text;
                }

                if (negocio.Login(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }


            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Seguridad.atraparError(ex, HttpContext.Current);
            }
        }

    }
}