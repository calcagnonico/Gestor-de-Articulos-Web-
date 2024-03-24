using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;

namespace TPFinalNivel3_Calcagno
{
    public partial class WebForm6 : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario user = (Usuario)Session["usuario"];

            if (!user.Admin)
            {
                if (Session["maxi"] != null)
                    {
                   bool maxi = (bool)Session["maxi"];
                       if (!maxi)
                        {
                        Response.Redirect("Main.aspx", false);
                        }
                        else
                        {
                     }
                  }
                 else
                 {
                  Response.Redirect("Main.aspx", false);
                 }
            }
            else
            {
                Response.Redirect("Main.aspx", false);
            }


        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Haceradmin(usuario.Id, 1);
              //Para que funcionen los permisos de admin limpiamos y recargamos
              Session.Clear();
              negocio.Login(usuario);
              Session.Add("usuario", usuario);
              Response.Redirect("Main.aspx", false);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            bool maxi = false;
            Session.Add("maxi", maxi);
            Response.Redirect("Main.aspx", false);

        }
    }
}