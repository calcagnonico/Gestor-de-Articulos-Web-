using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using static System.Collections.Specialized.BitVector32;

namespace negocio
{
    public class UsuarioNegocio
    {
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
                datos.setearConsulta("Update USERS set email = @email, urlImagenPerfil = @imagen, nombre = @nombre, apellido = @apellido, fechaNacimiento = @fecha Where Id = @id");
                datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                datos.setearParametro("@email", user.Email);
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

        public bool CargarUser(string id, Usuario user)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("Select id, email, pass, admin, urlimagenPerfil, nombre, apellido, fechaNacimiento from USERS Where id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();
                if (datos.Lectorbd.Read())
                {
                    user.Id = (int)datos.Lectorbd["id"];
                    user.Admin = (bool)datos.Lectorbd["admin"];
                    user.Email = (string)datos.Lectorbd["email"];
                    user.Pass = (string)datos.Lectorbd["pass"];
                    if (!(datos.Lectorbd["urlimagenPerfil"] is DBNull))
                        user.ImagenPerfil = (string)datos.Lectorbd["urlimagenPerfil"];
                    if (!(datos.Lectorbd["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lectorbd["nombre"];
                    if (!(datos.Lectorbd["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lectorbd["apellido"];
                    if (!(datos.Lectorbd["fechaNacimiento"] is DBNull))
                        user.FechaNacimiento = DateTime.Parse(datos.Lectorbd["fechaNacimiento"].ToString());


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

        public void Haceradmin(int iduser, int adminbool)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearConsulta("Update USERS set admin = @adminbool Where id = @Id");
                datos.setearParametro("@Id", iduser);
                datos.setearParametro("@adminbool", adminbool);
                datos.ejecutarLectura();
            }
            catch (Exception)
            {

                throw;
            }



        }

        public bool chequearemailusuario(string emailuser)
        {
            AccesoBD datos = new AccesoBD();
            bool bandera = true;
            string email = "";
            try
            {
                datos.setearConsulta("Select email from USERS");
                datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    email = (string)datos.Lectorbd["email"];
                    if (email == emailuser)
                        bandera = false;
                }

                return bandera;

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

        public List<Usuario> listarusuarios(int id)
        {
            AccesoBD datos = new AccesoBD();
            List<Usuario> listausuarios = new List<Usuario> ();
            try
            {
                datos.setearConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin, FechaNacimiento from USERS where Id <> @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)datos.Lectorbd.GetInt32(0);
                    aux.Email = (string)datos.Lectorbd.GetString(1);
                    aux.Pass = (string)datos.Lectorbd.GetString(2);
                    aux.Nombre = (string)datos.Lectorbd.GetString(3);
                    if (!(datos.Lectorbd["apellido"] is DBNull))
                        aux.Apellido = (string)datos.Lectorbd.GetString(4);
                    if (!(datos.Lectorbd["urlImagenPerfil"] is DBNull))
                        aux.ImagenPerfil = (string)datos.Lectorbd.GetString(5);
                    aux.Admin = (bool)datos.Lectorbd.GetBoolean(6);
                    if (!(datos.Lectorbd["FechaNacimiento"] is DBNull))
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

        public void eliminarusuario(int userid)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("Delete from USERS where Id = @Id");
                datos.setearParametro("@id", userid);
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
