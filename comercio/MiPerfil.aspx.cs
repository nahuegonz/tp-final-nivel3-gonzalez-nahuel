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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Enabled = false;
                txtPass.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;

                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    txtEmail.Text = usuario.Email;
                    txtEmail.ReadOnly = true;
                    txtPass.Text = usuario.Pass;
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    if (!string.IsNullOrEmpty(usuario.UrlImagen))
                        imgNuevoPerfil.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagen;
                }

            }
        }

        protected void btnEditarEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;
            txtEmail.Focus();
        }

        protected void btnEditarPass_Click(object sender, EventArgs e)
        {
            txtPass.Enabled = true;
            txtPass.Focus();
        }

        protected void btnEditarNombre_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        protected void btnEditarApellido_Click(object sender, EventArgs e)
        {
            txtApellido.Enabled = true;
            txtApellido.Focus();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                NegocioUsuario negocio = new NegocioUsuario();
                Usuario usuario = (Usuario)Session["usuario"];

                if(txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/Perfil/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagen = "perfil-" + usuario.Id + ".jpg";
                }

                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                negocio.actualizar(usuario);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/Perfil/" + usuario.UrlImagen;

                // crear mensaje de datos actualizados.


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}