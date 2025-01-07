using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioUsuario
    {
       
        public void agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into USERS (Email, Pass, Nombre, Apellido, UrlImagenPerfil, Admin) values (@Email, @Pass, @Nombre, @Apellido, @ImagenUrl, 0)");
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Pass", nuevo.Pass);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
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
        public void actualizar(Usuario cambio)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update USERS set Email = @Email, Pass = @Pass, Nombre = @Nombre, Apellido = @Apellido, UrlImagenPerfil = @ImagenUrl, Admin = @Admin where Id = @id");
                datos.setearParametro("@Email", cambio.Email);
                datos.setearParametro("@Pass", cambio.Pass);
                datos.setearParametro("@Nombre", cambio.Nombre);
                datos.setearParametro("@Apellido", cambio.Apellido);
                datos.setearParametro("@ImagenUrl", cambio.UrlImagen);
                datos.setearParametro("@Admin", cambio.Admin);
                datos.setearParametro("@id", cambio.Id);
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

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin, UrlImagenPerfil, nombre, apellido from USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)datos.Lector["Admin"];
                    if (!(datos.Lector["UrlImagenPerfil"] is DBNull))
                        usuario.UrlImagen = (string)datos.Lector["UrlImagenPerfil"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["Apellido"];

                    return true;
                }
                return false;

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
    }
}
