using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;


namespace negocio
{
    public class UsuarioNegocio
    {
        //id
        //email
        //pass
        //admin false

        //nombre, apellido, fecha, imagen

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearProcedimiento("StoredAgregarUsuario");
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Pass", nuevo.Pass);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                return datos.ejecutarAccionconreturn();
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

        public void actualizar(Usuario user)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("Update USERS set UrlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, fechaNacimiento = @fecha Where Id = @id");
                datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                //datos.setearParametro("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@fecha", user.FechaNacimiento);
                datos.setearParametro("@id", user.Id);
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

        public bool Login(Usuario trainee)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                //Le faltaria agregar la fecha de nacimiento.
                datos.setearConsulta("Select id, email, pass, admin, urlimagenPerfil, nombre, apellido, fechaNacimiento from USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", trainee.Email);
                datos.setearParametro("@pass", trainee.Pass);
                datos.ejecutarLectura();
                if (datos.Lectorbd.Read())
                {
                    trainee.Id = (int)datos.Lectorbd["id"];
                    trainee.Admin = (bool)datos.Lectorbd["admin"];
                    if (!(datos.Lectorbd["urlimagenPerfil"] is DBNull))
                        trainee.ImagenPerfil = (string)datos.Lectorbd["urlimagenPerfil"];
                    if (!(datos.Lectorbd["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.Lectorbd["nombre"];
                    if (!(datos.Lectorbd["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.Lectorbd["apellido"];
                    if (!(datos.Lectorbd["fechaNacimiento"] is DBNull))
                        trainee.FechaNacimiento = DateTime.Parse(datos.Lectorbd["fechaNacimiento"].ToString());

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

        public List<Usuario> listarusuarios()
        {
            AccesoBD datos = new AccesoBD();
            List<Usuario> listausuarios = new List<Usuario> ();
            try
            {
               datos.setearConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin, FechaNacimiento from USERS");
               datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    Usuario aux = new Usuario();
               
                    aux.Id = (int)datos.Lectorbd.GetInt32(0);
                    aux.Email = (string)datos.Lectorbd.GetString(1);
                    aux.Pass = (string)datos.Lectorbd.GetString(2);
                    aux.Nombre = (string)datos.Lectorbd.GetString(3);
                    aux.Apellido = (string)datos.Lectorbd.GetString(4);
                    aux.ImagenPerfil = (string)datos.Lectorbd.GetString(5);
                    aux.Admin = (bool)datos.Lectorbd.GetBoolean(6);
                    aux.FechaNacimiento = datos.Lectorbd.GetDateTime(7);
                    listausuarios.Add(aux);
                }
                return listausuarios;

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



        public void actualizarclave(string clave, Usuario user)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("Update USERS set pass = @clave Where Id = @id");
                datos.setearParametro("@id", user.Id);
                datos.setearParametro("@clave", clave);
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



    }
}
