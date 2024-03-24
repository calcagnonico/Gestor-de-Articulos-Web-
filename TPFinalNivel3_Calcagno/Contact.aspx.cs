using negocio;
using System;
using System.Web.UI;

namespace TPFinalNivel3_Calcagno
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["nuevousuario"]))
            {
                Session.Clear();
            }
            else
            {

            }
        }
    }
}