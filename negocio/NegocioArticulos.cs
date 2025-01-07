using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Runtime.InteropServices.ComTypes;

namespace negocio
{
    public class NegocioArticulos
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id AS ArticuloId, A.Codigo AS ArticuloCodigo, A.Nombre AS ArticuloNombre, A.Descripcion AS ArticuloDescripcion, A.IdMarca AS ArticuloIdMarca, A.IdCategoria AS ArticuloIdCategoria, A.ImagenUrl AS ArticuloImagenUrl, A.Precio AS ArticuloPrecio, C.Descripcion AS CategoriaDescripcion, M.Descripcion AS MarcaDescripcion FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id ");
                if(id != "")
                    datos.preguntarID(id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["ArticuloId"];
                    aux.Codigo = (string)datos.Lector["ArticuloCodigo"];
                    aux.Nombre = (string)datos.Lector["ArticuloNombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];
                    aux.IdCategoria = (int)datos.Lector["ArticuloIdCategoria"];
                    aux.IdMarca = (int)datos.Lector["ArticuloIdMarca"];



                    if(!(datos.Lector["ArticuloPrecio"] is DBNull))
                    {
                        decimal numerolimpio = (decimal)datos.Lector["ArticuloPrecio"];
                        decimal numeroTruncado = Math.Truncate(numerolimpio * 100) / 100;
                        aux.Precio = numeroTruncado;
                    }
                    else
                        aux.Precio = 0;

                    if (!(datos.Lector["ArticuloImagenUrl"] is DBNull))
                    {
                        string urlImagen = (string)datos.Lector["ArticuloImagenUrl"];
                        //if (Seguridad.EsImagenValida(urlImagen))
                        aux.UrlImagen = urlImagen;
                        //else
                        //    //aux.UrlImagen = urlImagen;
                        //    aux.UrlImagen = "https://img.freepik.com/vector-premium/no-hay-foto-disponible-icono-vector-simbolo-imagen-predeterminado-imagen-proximamente-sitio-web-o-aplicacion-movil_87543-10615.jpg";
                    }
                    else
                        aux.UrlImagen = "";


                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];


                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo cambio)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @id");
                datos.setearParametro("@Id", cambio.Id);
                datos.setearParametro("@Codigo", cambio.Codigo);
                datos.setearParametro("@Nombre", cambio.Nombre);
                datos.setearParametro("@Descripcion", cambio.Descripcion);
                datos.setearParametro("@IdMarca", cambio.IdMarca);
                datos.setearParametro("@IdCategoria", cambio.IdCategoria);
                datos.setearParametro("@ImagenUrl", cambio.UrlImagen);
                datos.setearParametro("@Precio", cambio.Precio);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> buscarArticulos(int? minprecio, int? maxprecio, string categoria, string marca) 
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = "SELECT A.Id AS ArticuloId, A.Codigo AS ArticuloCodigo, A.Nombre AS ArticuloNombre, A.Descripcion AS ArticuloDescripcion, A.IdMarca AS ArticuloIdMarca, A.IdCategoria AS ArticuloIdCategoria, A.ImagenUrl AS ArticuloImagenUrl, A.Precio AS ArticuloPrecio, C.Descripcion AS CategoriaDescripcion, M.Descripcion AS MarcaDescripcion FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id";
                if (minprecio == 0)
                {
                    query = query + " AND Precio > 0 AND Precio <= 10000";
                }
                if (minprecio == 10001)
                {
                    query = query + " AND Precio > 10000 AND Precio <= 30000";
                }
                if (minprecio == 30001)
                {
                    query = query + " AND Precio > 30000 AND Precio <= 50000";
                }
                if (minprecio == 50001)
                {
                    query = query + " AND Precio > 50000";
                }
                if (!String.IsNullOrEmpty(categoria))
                {
                    query = query + " AND C.Descripcion = '" + categoria + "'";
                }
                if (!String.IsNullOrEmpty(marca))
                {
                    query = query + " AND M.Descripcion = '" + marca + "'";
                }
                datos.setearConsulta(query);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["ArticuloId"];
                    aux.Codigo = (string)datos.Lector["ArticuloCodigo"];
                    aux.Nombre = (string)datos.Lector["ArticuloNombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];
                    aux.IdCategoria = (int)datos.Lector["ArticuloIdCategoria"];
                    aux.IdMarca = (int)datos.Lector["ArticuloIdMarca"];
                    if (!(datos.Lector["ArticuloImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ArticuloImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["ArticuloPrecio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
    

}
