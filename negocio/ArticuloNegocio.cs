using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using dominio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace negocio
{
    public class ArticuloNegocio
    {
        //Creamos variable que tendra el id del usuario
        int idusuario;

        //Metodo que devuelve una lista de objetos que obtiene a traves de una consulta embebida en la BD
        public List<Articulo> listarConSP(int id = 0)
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoBD datos = new AccesoBD();

            try
            {
                //Seteamos procedimiento almacenado
                if (id == 0)
                {
                    datos.setearProcedimiento("StoredListar");
                }
                else
                { 
                    datos.setearProcedimiento("StoredListarId");
                    datos.setearParametro("@Id", id);
                }
                //Ejecutamos

                datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    Articulo aux = new Articulo();
                    aux.artid = (int)datos.Lectorbd.GetInt32(0);
                    aux.artcodigo = (string)datos.Lectorbd.GetString(1);
                    aux.artnombre = (string)datos.Lectorbd.GetString(2);
                    aux.artdescripcion = (string)datos.Lectorbd.GetString(3);
                    aux.artimagen = (string)datos.Lectorbd.GetString(4);
                    aux.artprecio = (decimal)datos.Lectorbd.GetDecimal(5);
                    aux.artestado = (bool)datos.Lectorbd.GetBoolean(10);

                    //Redondeamos a 2 decimales el precio 
                    aux.artprecio = Decimal.Round(aux.artprecio, 2);

                    aux.artmarca = new Marca();
                    aux.artmarca.Id = (int)datos.Lectorbd.GetInt32(8);
                    aux.artmarca.Descripcion = (string)datos.Lectorbd.GetString(9);

                    aux.artcategoria = new Categoria();
                    aux.artcategoria.Id = (int)datos.Lectorbd.GetInt32(6);
                    aux.artcategoria.Descripcion = (string)datos.Lectorbd.GetString(7);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> listarConSPFavoritos(int Userid)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoBD datos = new AccesoBD();

            try
            {
                //Seteamos procedimiento almacenado
                    datos.setearProcedimiento("StoredListarFav");
                    datos.setearParametro("@IdUser", Userid);
                //Ejecutamos

                datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    Articulo aux = new Articulo();
                    aux.artid = (int)datos.Lectorbd.GetInt32(0);
                    aux.artcodigo = (string)datos.Lectorbd.GetString(1);
                    aux.artnombre = (string)datos.Lectorbd.GetString(2);
                    aux.artdescripcion = (string)datos.Lectorbd.GetString(3);
                    aux.artimagen = (string)datos.Lectorbd.GetString(4);
                    aux.artprecio = (decimal)datos.Lectorbd.GetDecimal(5);
                    aux.artestado = (bool)datos.Lectorbd.GetBoolean(10);

                    //Redondeamos a 2 decimales el precio 
                    aux.artprecio = Decimal.Round(aux.artprecio, 2);

                    aux.artmarca = new Marca();
                    aux.artmarca.Id = (int)datos.Lectorbd.GetInt32(8);
                    aux.artmarca.Descripcion = (string)datos.Lectorbd.GetString(9);

                    aux.artcategoria = new Categoria();
                    aux.artcategoria.Id = (int)datos.Lectorbd.GetInt32(6);
                    aux.artcategoria.Descripcion = (string)datos.Lectorbd.GetString(7);

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Chequearfav(int userId, int Artid)
        {
            bool bandera = false;
            List<Articulo> fav = listarConSPFavoritos(Convert.ToInt32(userId));

                    if (fav != null) 
                    {
                        foreach (var i in fav)
                        {
                            if (i.artid == (Convert.ToInt32(Artid)))
                                {
                            bandera = true;
                                }
                            else
                                {
                                }
                        }
                    }
                    else
                    {
                     bandera = false;
                    }

            return bandera;
        
        }


        public int agregarconreturnSP(Articulo nuevo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearProcedimiento("StoredAgregarconreturn");
                //Setear parametro o escribirlo directamente en la consulta son dos opciones posibles, ambas funcionan
                datos.setearParametro("@Codigo", nuevo.artcodigo);
                datos.setearParametro("@Nombre", nuevo.artnombre);
                datos.setearParametro("@Descripcion", nuevo.artdescripcion);
                datos.setearParametro("@IdMarca", nuevo.artmarca.Id);
                datos.setearParametro("@IdCategoria", nuevo.artcategoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.artimagen);
                datos.setearParametro("@Precio", nuevo.artprecio);
                datos.setearParametro("@Activo", nuevo.artestado);
                //ejecutamos accion y guardamos el numero que nos devuelve
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

        public void modificarconSP(Articulo articulo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearProcedimiento("StoredModificar");
                datos.setearParametro("@Id", articulo.artid);
                datos.setearParametro("@Codigo", articulo.artcodigo);
                datos.setearParametro("@Nombre", articulo.artnombre);
                datos.setearParametro("@Descripcion", articulo.artdescripcion);
                datos.setearParametro("@IdMarca", articulo.artmarca.Id);
                datos.setearParametro("@IdCategoria", articulo.artcategoria.Id);
                datos.setearParametro("@ImagenUrl", articulo.artimagen);
                datos.setearParametro("@Precio", articulo.artprecio);
                datos.setearParametro("@Activo", articulo.artestado);
                datos.ejecutarAccion();
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



        public void EliminarconSP(int artid)
        {
            AccesoBD datos = new AccesoBD();
            datos.setearProcedimiento("StoredEliminar");
            datos.setearParametro("@IdUser", artid);
            datos.ejecutarLectura();
        }

        public void Agregarafav(int iduser, int idart)
        {
            AccesoBD datos = new AccesoBD();
            datos.setearProcedimiento("StoredAgregarFav");
            //Setear parametro o escribirlo directamente en la consulta son dos opciones posibles, ambas funcionan
            datos.setearParametro("@IdUser", iduser);
            datos.setearParametro("@IdArticulo", idart);
            datos.ejecutarAccion();
        }

        public void Eliminarfav(int iduser, int idart)
        {
            AccesoBD datos = new AccesoBD();
            datos.setearProcedimiento("StoredEliminarFav");
            //Setear parametro o escribirlo directamente en la consulta son dos opciones posibles, ambas funcionan
            datos.setearParametro("@IdUser", iduser);
            datos.setearParametro("@IdArticulo", idart);
            datos.ejecutarAccion();
        }


        //Metodo que devuelve una lista de objetos que obtiene a traves de una consulta a la BD
        public List<Articulo> listar(bool tipo)
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            AccesoBD datos = new AccesoBD();

            try
            {
                //El server lo toma de una appsetting 
                Configuration server = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                conexion.ConnectionString = ("server=" + server.AppSettings.Settings["server"].Value + "; database=CATALOGO_DB; integrated security=true");


                //Use el -OFF para articulos borrados logicamente
                //cuando llamamos al metodo le mandamos la bandera "tipo" prendida o apagada dependiendo de deonde lo estamos llamando (Main o reestablecer)
                comando.CommandType = System.Data.CommandType.Text;
                if (tipo)
                {
                    comando.CommandText = "Select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id AND Codigo not like 'OFF-%'";
                }
                else
                {
                    comando.CommandText = "Select A.Id, SUBSTRING (Codigo, 5, 15), Nombre, A.Descripcion, ImagenUrl, Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id AND Codigo like 'OFF-%'";
                }

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();


                //Con un While cargamos la lista y luego la retornamos
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.artid = (int)lector.GetInt32(0);
                    aux.artcodigo = (string)lector.GetString(1);
                    aux.artnombre = (string)lector.GetString(2);
                    aux.artdescripcion = (string)lector.GetString(3);
                    aux.artimagen = (string)lector.GetString(4);
                    aux.artprecio = (decimal)lector.GetDecimal(5);

                    //Redondeamos a 2 decimales el precio 
                    aux.artprecio = Decimal.Round(aux.artprecio, 2);

                    aux.artmarca = new Marca();
                    aux.artmarca.Id = (int)lector.GetInt32(8);
                    aux.artmarca.Descripcion = (string)lector.GetString(9);

                    aux.artcategoria = new Categoria();
                    aux.artcategoria.Id = (int)lector.GetInt32(6);
                    aux.artcategoria.Descripcion = (string)lector.GetString(7);

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Boton modificar articulos
        public void modificar(Articulo articulo) 
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, ImagenUrl = @imagenurl, Precio = @precio Where Id = @id");
                datos.setearParametro("@id", articulo.artid);
                datos.setearParametro("@codigo", articulo.artcodigo);
                datos.setearParametro("@nombre", articulo.artnombre);
                datos.setearParametro("@descripcion", articulo.artdescripcion);
                datos.setearParametro("@idmarca", articulo.artmarca.Id);
                datos.setearParametro("@idcategoria", articulo.artcategoria.Id);
                datos.setearParametro("@imagenurl", articulo.artimagen);
                datos.setearParametro("@precio", articulo.artprecio);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Boton restablecer, quita el prefijo OFF- de los articulos para que aparezcan / no aparezcan en el listado 
        public void restablecer(Articulo articulo1)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Codigo = replace(Codigo, 'OFF-', '') Where Id = @id"); 
                datos.setearParametro("@id", articulo1.artid);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Eliminar logico Agrega OFF- Al principio del Codigo de cada elemento para dps filtrarlo en los distintos listados
        public void eliminarLogico(int id)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearConsulta("update ARTICULOS set Codigo = 'OFF-' + Codigo Where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Eliminador fisico (Borra totalmente el articulo)
        public void eliminarFisico(int id)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearConsulta("delete from Articulos where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Consulta sql con filtro de listados 
        public List<Articulo> filtrar(string criterio, string condicion, string filtro, string estado, string marca, string categoria)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoBD datos = new AccesoBD();
            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca, A.Activo from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id And ";
                switch (criterio)
                {
                    case "Codigo":
                        consulta += "Codigo";
                        break;
                    case "Nombre":
                        consulta += "Nombre";
                        break;
                    case "Marca":
                       consulta += "M.Descripcion";
                        break;
                    case "Categoria":
                        consulta += "C.Descripcion";
                        break;
                    case "Descripcion":
                        consulta += "A.Descripcion";
                        break;
                    default:

                    break;
                }
                switch (condicion)
                    {
                        case "Comienza con":
                            consulta += " like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += " like '%"+ filtro + "'";
                            break;
                        default:
                            consulta += " like '%"+ filtro + "%'";
                            break;
                    }


                switch (marca)
                {
                    case "Samsung":
                        consulta += " And M.Descripcion = 'Samsung'";
                        break;
                    case "Apple":
                        consulta += " And M.Descripcion = 'Apple'";
                        break;
                    case "Sony":
                        consulta += " And M.Descripcion = 'Sony'";
                        break;
                    case "Huawei":
                        consulta += " And M.Descripcion = 'Huawei'";
                        break;
                    case "Motorola":
                        consulta += " And M.Descripcion = 'Motorola'";
                        break;
                    default:
                        consulta += "";
                        break;
                }


                switch (categoria)
                {
                    case "Celulares":
                        consulta += " And C.Descripcion = 'Celulares'";
                        break;

                    case "Media":
                        consulta += " And C.Descripcion = 'Media'";
                        break;

                    case "Televisores":
                        consulta += " And C.Descripcion = 'Televisores'";
                        break;

                    case "Audio":
                        consulta += " And C.Descripcion = 'Audio'";
                        break;
                    default:
                        consulta += "";
                        break;
                }


                if (estado == "Activo")
                    consulta += " and A.Activo = 1";
                else if (estado == "Inactivo")
                    consulta += " and A.Activo = 0";


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lectorbd.Read())
                {
                    Articulo aux = new Articulo();
                    aux.artid = (int)datos.Lectorbd.GetInt32(0);
                    aux.artcodigo = (string)datos.Lectorbd.GetString(1);
                    aux.artnombre = (string)datos. Lectorbd.GetString(2);
                    aux.artdescripcion = (string)datos.Lectorbd.GetString(3);
                    aux.artimagen = (string)datos.Lectorbd.GetString(4);
                    aux.artprecio = (decimal)datos.Lectorbd.GetDecimal(5);
                    aux.artestado = (bool)datos.Lectorbd.GetBoolean(10);

                    //Redondeamos a 2 decimales el precio 
                    aux.artprecio = Decimal.Round(aux.artprecio, 2);

                    aux.artmarca = new Marca();
                    aux.artmarca.Id = (int)datos.Lectorbd.GetInt32(8);
                    aux.artmarca.Descripcion = (string)datos.Lectorbd.GetString(9);

                    aux.artcategoria = new Categoria();
                    aux.artcategoria.Id = (int)datos.Lectorbd.GetInt32(6);
                    aux.artcategoria.Descripcion = (string)datos.Lectorbd.GetString(7);

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}