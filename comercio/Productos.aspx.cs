using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Comercio
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NegocioArticulos negocio = new NegocioArticulos();
                Session.Add("listaProductos", negocio.listar());
                dgvProductos.DataSource = Session["listaProductos"];
                dgvProductos.DataBind();

                
            }

        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProductos.PageIndex = e.NewPageIndex;
            dgvProductos.DataBind();
        }

        //protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string id = dgvProductos.SelectedDataKey.Value.ToString();
        //    Response.Redirect("Modificar.aspx?id=" + id);

        //}

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                //string id = dgvProductos.SelectedDataKey.Value.ToString();
                //Response.Redirect("Modificar.aspx?id=" + id);

                int index = Convert.ToInt32(e.CommandArgument);
                
                GridViewRow selectedRow = dgvProductos.Rows[index];
                TableCell identification = selectedRow.Cells[0];
                string id = identification.Text;

                Response.Redirect("Modificar.aspx?id=" + id);
            }
            if(e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                NegocioArticulos negocio = new NegocioArticulos();
                negocio.eliminar(index);
                
            }
        }
    }
}