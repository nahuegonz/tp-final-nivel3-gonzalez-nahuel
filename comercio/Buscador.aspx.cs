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
            ListaArticulo = negocio.listar();

            NegocioCategoria negocio2 = new NegocioCategoria();
            ListaCategoria = negocio2.listar();

            NegocioMarca negocio3 = new NegocioMarca();
            ListaMarca = negocio3.listar();

            Session.Add("listaArticulos", negocio.listar());

            foreach (var articulo in ListaArticulo)
            {
                articulo.UrlImagenValidada = Seguridad.EsImagenValida(articulo.UrlImagen)
                    ? articulo.UrlImagen
                    : "https://img.freepik.com/vector-premium/no-hay-foto-disponible-icono-vector-simbolo-imagen-predeterminado-imagen-proximamente-sitio-web-o-aplicacion-movil_87543-10615.jpg";
            }

            if (!IsPostBack)
            {
                if (Session["busqueda"] != null)
                {
                    string filtro = Session["busqueda"].ToString();
                    List<Articulo> listaFiltrada = ListaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                    repArticulos.DataSource = listaFiltrada;
                }
                else
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