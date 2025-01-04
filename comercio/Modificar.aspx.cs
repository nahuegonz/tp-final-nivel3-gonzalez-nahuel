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
    public partial class Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    NegocioCategoria negocio1 = new NegocioCategoria();
                    List<Categoria> categorias = negocio1.listar();

                    NegocioMarca negocio2 = new NegocioMarca();
                    List<Marca> marcas = negocio2.listar();

                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    NegocioArticulos negocio = new NegocioArticulos();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    txtNombreProducto.Text = seleccionado.Nombre;
                    txtDescripcionProducto.Text = seleccionado.Descripcion;
                    txtCodigoProducto.Text = seleccionado.Codigo;
                    txtPrecioProducto.Text = seleccionado.Precio.ToString();

                    if (!string.IsNullOrEmpty(seleccionado.UrlImagen))
                        imgNuevoProducto.ImageUrl = "~/Images/Productos/" + seleccionado.UrlImagen;


                    ddlCategoria.SelectedValue = seleccionado.IdCategoria.ToString();
                    ddlMarca.SelectedValue = seleccionado.IdMarca.ToString();



                    //txtImagenProducto.Text = seleccionado.UrlImagen;



                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                NegocioArticulos negocio = new NegocioArticulos();

                nuevo.Nombre = txtNombreProducto.Text;
                nuevo.Descripcion = txtDescripcionProducto.Text;
                nuevo.Codigo = txtCodigoProducto.Text;
                nuevo.Precio = int.Parse(txtPrecioProducto.Text);
                nuevo.IdMarca = int.Parse(ddlMarca.SelectedValue);
                nuevo.IdCategoria = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                // ver si esto funciona como espero.
                //string ruta = Server.MapPath("./Images/Productos/");
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                //txtImagenProducto.PostedFile.SaveAs(ruta + "producto-" + id + ".jpg");

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"].ToString());
                    negocio.modificar(nuevo);
                    // seria bueno poner un mensaje de confirmacion.
                    Response.Redirect("Productos.aspx", false);
                }
                else
                {
                    negocio.agregar(nuevo);
                    // seria bueno poner un mensaje de confirmacion.
                    Response.Redirect("Modificar.aspx", false);

                }



            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnImagenProducto_Click(object sender, EventArgs e)
        {

        }
    }
}