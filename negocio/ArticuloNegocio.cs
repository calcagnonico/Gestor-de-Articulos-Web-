using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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

        public List<Articulo> listarConSP(int artid, int userid)
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoBD datos = new AccesoBD();

            try
            {
                //Seteamos procedimiento almacenado
                if (artid == 0)
                {
                    datos.setearProcedimiento("StoredListar");
                }
                else
                {
                    datos.setearProcedimiento("StoredListarId");
                    datos.setearParametro("@Id", artid);
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

                    if (Chequearfav(userid, aux.artid))
                    {
                        aux.artfav = "❤️";
                    }
                    else
                    {
                        aux.artfav = "🤍";
                    }

                lista.Add(aux);
                }
                return lista;
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

                    aux.artfav = "❤️";
                    lista.Add(aux);
                }
                return lista;
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
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredEliminar");
                datos.setearParametro("@IdUser", artid);
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregarafav(int iduser, int idart)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredAgregarFav");
                //Setear parametro o escribirlo directamente en la consulta son dos opciones posibles, ambas funcionan
                datos.setearParametro("@IdUser", iduser);
                datos.setearParametro("@IdArticulo", idart);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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


        public void AgregarMarca(string marca)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredAgregarMarca");
                datos.setearParametro("@Marca", marca);
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarCategoria(string categoria)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredAgregarCategoria");
                datos.setearParametro("@Categoria", categoria);
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarCategoria(int id)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredEliminarCategoria");
                datos.setearParametro("@IdCategoriaEliminada", id);
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarMarca(int id)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredEliminarMarca");
                datos.setearParametro("@IdMarcaEliminada", id);
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EditarMarca(int id, string nombre)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredModificarMarca");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Marca", nombre);
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EditarCategoria(int id, string nombre)
        {
            try
            {
                AccesoBD datos = new AccesoBD();
                datos.setearProcedimiento("StoredModificarCategoria");
                datos.setearParametro("@Id", id);
                datos.setearParametro("@Categoria", nombre);
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Articulo> filtrar(string criterio, string condicion, string filtro, string estado, string marca, string categoria, string precioentre, string preciohasta, int userid, string favoritos)
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

                if (marca != "Todas")
                {
                    consulta += " And M.Descripcion = " + "'" + marca + "'";
                }
                else
                {

                }

                if(categoria !="Todas")
                {
                    consulta += " And C.Descripcion = " + "'" + categoria + "'";
                }
                else
                {

                }



            if (estado == "Activo")
                    consulta += " and A.Activo = 1";
                else if (estado == "Inactivo")
                    consulta += " and A.Activo = 0";

                   if(IsFloatOrInt(precioentre) && IsFloatOrInt(preciohasta))
                    consulta += " And Precio BETWEEN " + precioentre + " and " + preciohasta;
                    else
                    {
                    }



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


                    if (Chequearfav(userid, aux.artid))
                    {
                        aux.artfav = "❤️";
                    }
                    else
                    {
                        aux.artfav = "🤍";
                    }



                    switch (favoritos)
                    {
                        case "Todos":
                            lista.Add(aux);
                            break;

                        case "Favoritos":
                            if (aux.artfav == "❤️")
                                lista.Add(aux);
                            ;
                            break;
                        case "No favoritos":
                            if (aux.artfav == "🤍")
                                lista.Add(aux);
                            ;
                            break;
                        default:
                            break;
                    }

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsFloatOrInt(string value)
        {
            int intValue;
            float floatValue;
            return Int32.TryParse(value, out intValue) || float.TryParse(value, out floatValue);




        }
    }
}