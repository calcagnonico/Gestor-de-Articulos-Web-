using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using dominio;
using negocio;



namespace TPFinalNivel3_Calcagno
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        public bool modificar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            TxtId.Enabled = false;
            ConfirmaEliminacion = false;
            modificar = false;

            try
			{
                //configuración inicial de la pantalla.
                if (!IsPostBack)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    MarcaNegocio negocio2 = new MarcaNegocio();
                    List<Categoria> listacategorias = negocio.listar();
                    List<Marca> listamarcas = negocio2.listar();

                    ddlMarca.DataSource = listamarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listacategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
                //configuración si estamos modificando.                
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    modificar = true;
                    Titulo.Text = "Modificar Articulo";
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    //Articulo seleccionado = negocio.listarConSP(a);
                    List<Articulo> a = negocio.listarConSP(Convert.ToInt32(id));
                    Articulo seleccionado = a[0];
                    //Articulo seleccionado = (negocio.listarConSP(Convert.ToInt32(id))[0]);


                    //guardo pokemon seleccionado en session
                    Session.Add("ArticuloSeleccionado", seleccionado);

                    //pre cargar todos los campos...
                    TxtId.Text = seleccionado.artid.ToString();
                    TxtCodigo.Text = seleccionado.artcodigo.ToString();
                    TxtNombre.Text = seleccionado.artnombre.ToString();
                    TxtPrecio.Text = seleccionado.artprecio.ToString();
                    TxtDescripcion.Text = seleccionado.artdescripcion.ToString();
                    TxtImagenUrl.Text = seleccionado.artimagen.ToString();
                    estado.Checked = seleccionado.artestado;


                    //CHEQUEAR SI ES FAVORITO
                    Usuario user = (Usuario)Session["usuario"];
                    List<Articulo> fav = negocio.listarConSPFavoritos(Convert.ToInt32(user.Id));
                    checkbox.Checked = negocio.Chequearfav(user.Id, seleccionado.artid);

                    ddlCategoria.SelectedValue = seleccionado.artcategoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.artmarca.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                }
                else
                {
                }
            }
            catch (Exception ex)
			{
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.artmarca = new Marca();
                nuevo.artmarca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.artcategoria = new Categoria();
                nuevo.artcategoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.artcodigo = TxtCodigo.Text;
                nuevo.artnombre = TxtNombre.Text;
                nuevo.artdescripcion = TxtDescripcion.Text;

                nuevo.artprecio = Convert.ToDecimal(TxtPrecio.Text);
                nuevo.artimagen = TxtImagenUrl.Text;

                nuevo.artestado = estado.Checked ? true : false;

        
                if (Request.QueryString["id"] != null)
                {
                    nuevo.artid = int.Parse(Request.QueryString["id"]);
                    negocio.modificarconSP(nuevo); 
                }
                else
                {
                    nuevo.artid = negocio.agregarconreturnSP(nuevo);
                }


                Usuario user = (Usuario)Session["usuario"];
               if (checkbox.Checked)
                {
                    if(!negocio.Chequearfav(user.Id, nuevo.artid))
                    negocio.Agregarafav(user.Id, nuevo.artid);
                }
               else
                {
                    if (negocio.Chequearfav(user.Id, nuevo.artid))
                        negocio.Eliminarfav(user.Id, nuevo.artid);
                }

                Response.Redirect("Main.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = TxtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo art = (Articulo)Session["ArticuloSeleccionado"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.EliminarconSP(art.artid);
                Response.Redirect("Main.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}