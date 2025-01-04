using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using static System.Net.WebRequestMethods;
using System.Data;
using Microsoft.Ajax.Utilities;

namespace Comercio
{
    public partial class Buscador : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        public List<Categoria> ListaCategoria { get; set; }
        public List<Marca> ListaMarca { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            NegocioArticulos negocio = new NegocioArticulos();
            Articulo articulo = new Articulo();
            ListaArticulo = negocio.listar();

            NegocioCategoria negocio2 = new NegocioCategoria();
            Categoria categoria = new Categoria();
            ListaCategoria = negocio2.listar();

            NegocioMarca negocio3 = new NegocioMarca();
            Marca marca = new Marca();
            ListaMarca = negocio3.listar();

            if (!IsPostBack)
            {
                repArticulos.DataSource = ListaArticulo;
                repCategoria.DataSource = ListaCategoria;
                repMarca.DataSource = ListaMarca;

                repArticulos.DataBind();
                repCategoria.DataBind();
                repMarca.DataBind();
            }

        }

    }
}