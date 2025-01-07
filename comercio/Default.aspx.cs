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
    public partial class _Default : Page
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

            foreach (var articulo in ListaArticulo)
            {
                articulo.UrlImagenValidada = Seguridad.EsImagenValida(articulo.UrlImagen)
                    ? articulo.UrlImagen
                    : "https://img.freepik.com/vector-premium/no-hay-foto-disponible-icono-vector-simbolo-imagen-predeterminado-imagen-proximamente-sitio-web-o-aplicacion-movil_87543-10615.jpg";
            }

            if (!IsPostBack)
            {
                var categoriasConArticulos = ListaArticulo
                    .GroupBy(art => art.Categoria.Descripcion)
                    .Take(5)
                    .Select(grupo => new
                    {
                        Categoria = grupo.Key,
                        GruposDeArticulos = grupo
                    .Take(12)
                    .Select((articulo, index) => new { articulo, index })
                    .GroupBy(x => x.index / 4)
                    .Select(g => g.Select(x => x.articulo).ToList())
                    .ToList()
                    })
                    .ToList();

                repCategoriasConArticulos.DataSource = categoriasConArticulos;
                repCategoriasConArticulos.DataBind();

            }

        }

    }
}