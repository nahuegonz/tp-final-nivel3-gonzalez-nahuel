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
    }
}