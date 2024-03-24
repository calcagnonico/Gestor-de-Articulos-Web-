using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using static System.Collections.Specialized.BitVector32;

namespace TPFinalNivel3_Calcagno
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Usuario user = (Usuario)Session["usuario"];
                if (user is null)
                { }
                else
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("listaArticulos", negocio.listarConSPFavoritos(user.Id));
                    dgvlistaArticulos.DataSource = Session["listaArticulos"];
                    dgvlistaArticulos.DataBind();
                }

                if (Session["cantxpagina"] != null)
                {
                    int a = (int)Session["cantxpagina"];
                    // int.TryParse(Cantidadxpagina.Text, out a);
                    Cantidadxpagina.Text = Convert.ToString(a);
                    CargarCantidadxPagina();
                }
                else
                {
                    Cantidadxpagina.Text = "10";
                }
            }
        }


        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = new List<Articulo>();

            if (txtFiltro.Text == "")
            {
                Usuario user = (Usuario)Session["usuario"];
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSPFavoritos(user.Id));
                dgvlistaArticulos.DataSource = Session["listaArticulos"];
                dgvlistaArticulos.DataBind();
            }

            else
            {
                switch (CriterioFRapido.SelectedIndex)
                {
                    case 0:
                        listaFiltrada = lista.FindAll(x => x.artnombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                        break;
                    case 1:
                        listaFiltrada = lista.FindAll(x => x.artcodigo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                        break;
                    default:
                        break;
                }
                dgvlistaArticulos.DataSource = listaFiltrada;
                Session.Add("listaArticulos", listaFiltrada);
                dgvlistaArticulos.DataBind();
            }
        }


        protected void dgvlistaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvlistaArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Articulo.aspx?id=" + id);
        }

        protected void dgvlistaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgvlistaArticulos.DataSource = Session["listaArticulos"];
            dgvlistaArticulos.PageIndex = e.NewPageIndex;
            dgvlistaArticulos.DataBind();
        }

        protected void CriterioFRapido_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listarConSPFavoritos(user.Id));
            dgvlistaArticulos.DataSource = Session["listaArticulos"];
            dgvlistaArticulos.DataBind();
        }


        protected void artfavlist(object sender, EventArgs e)
        {
            Session.Add("error", "lalala");
            Response.Redirect("Error.aspx");
        }

        protected void dgvlistaArticulos_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<Articulo> listaordenada = (List<Articulo>)Session["listaArticulos"];
            string sortexp = e.SortExpression.ToString();

            switch (sortexp)
            {
                case "artmarca":
                    if (listaordenada.SequenceEqual(listaordenada.OrderBy(x => x.artmarca.Descripcion)))
                        listaordenada = listaordenada.OrderByDescending(x => x.artmarca.Descripcion).ToList();
                    else
                        listaordenada = listaordenada.OrderBy(x => x.artmarca.Descripcion).ToList();
                    break;

                case "artcategoria":
                    if (listaordenada.SequenceEqual(listaordenada.OrderBy(x => x.artcategoria.Descripcion)))
                        listaordenada = listaordenada.OrderByDescending(x => x.artcategoria.Descripcion).ToList();
                    else
                        listaordenada = listaordenada.OrderBy(x => x.artcategoria.Descripcion).ToList();
                    break;
                default:
                    if (listaordenada.SequenceEqual(listaordenada.OrderBy(x => x.GetType().GetProperty(sortexp).GetValue(x, null))))
                        listaordenada = listaordenada.OrderByDescending(x => x.GetType().GetProperty(sortexp).GetValue(x, null)).ToList();
                    else
                        listaordenada = listaordenada.OrderBy(x => x.GetType().GetProperty(sortexp).GetValue(x, null)).ToList();
                    break;
            }

            Session.Add("listaArticulos", listaordenada);
            dgvlistaArticulos.DataSource = Session["listaArticulos"];
            dgvlistaArticulos.DataBind();

        }


        protected void Cantidadxpagina_TextChanged(object sender, EventArgs e)
        {
            CargarCantidadxPagina();
        }


        protected void CargarCantidadxPagina()
        {
            int a;
            if (int.TryParse(Cantidadxpagina.Text, out a))
            {
                dgvlistaArticulos.PageSize = a;
                dgvlistaArticulos.DataSource = Session["listaArticulos"];
                dgvlistaArticulos.PageIndex = 0;
                Session.Add("cantxpagina", a);
                dgvlistaArticulos.DataBind();
            }
            else
            {
                dgvlistaArticulos.PageSize = 10;
                dgvlistaArticulos.DataSource = Session["listaArticulos"];
                dgvlistaArticulos.PageIndex = 0;
                dgvlistaArticulos.DataBind();
            }
        }

    }
}