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
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtId.Enabled = false;
            ConfirmaEliminacion = false;
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


                    ddlCategoria.SelectedValue = seleccionado.artcategoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.artmarca.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    //configurar acciones
                    //if (!seleccionado.Activo)
                    //    btnInactivar.Text = "Reactivar";
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
                    nuevo.artid = int.Parse(TxtId.Text);
                    negocio.modificarconSP(nuevo);
                }
                else
                {
                    negocio.agregarconSP(nuevo);
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

        }
    }
}