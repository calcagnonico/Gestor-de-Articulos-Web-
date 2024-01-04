using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPFinalNivel3_Calcagno
{
    public partial class Main : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSP());
                dgvlistaArticulos.DataSource = Session["listaArticulos"];
                dgvlistaArticulos.DataBind();
            }
        }

 

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = new List<Articulo>();
            switch (CriterioFRapido.SelectedIndex)
            {
                case 0:
                    listaFiltrada = lista.FindAll(x => x.artcodigo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    break;
                case 1:
                    listaFiltrada = lista.FindAll(x => x.artnombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    break;
                case 2:
                    listaFiltrada = lista.FindAll(x => x.artdescripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                    break;
                default:
                    break;
            }
            dgvlistaArticulos.DataSource = listaFiltrada;
            dgvlistaArticulos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

         protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    dgvlistaArticulos.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedItem.ToString(),
                    DropDownMarca.SelectedItem.ToString(),
                    DropDownCategoria.SelectedItem.ToString()
                    );
                    dgvlistaArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
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

        protected void TipodeFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipodeFiltro.SelectedItem.Text == "Avanzado")
            {
                txtFiltro.Enabled = false;
                CriterioFRapido.Enabled = false;

                //REVISAR ESTO SI PUEDO LLAMAR AL EVENTO
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedItem.ToString() == "Número")
                {
                    ddlCriterio.Items.Add("Igual a");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                }
                else
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                }

            }
            else 
            {
                txtFiltro.Enabled = true;
                CriterioFRapido.Enabled = true;
            }
        }
    }
}