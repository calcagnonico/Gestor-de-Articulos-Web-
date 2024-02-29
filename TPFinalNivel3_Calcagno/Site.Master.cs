using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPFinalNivel3_Calcagno
{
    public partial class SiteMaster : MasterPage
    {
        public bool banderaadmin = false;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Seguridad.sesionActiva(Session["usuario"]))
            {
                if (!(Page is Error || Page is Default || Page is About || Page is Contact || Page is Registro))
                {
                    Response.Redirect("Default.aspx", false);
                }
                else
                {

                }
            }
            else
            {
                Usuario user = (Usuario)Session["usuario"];
                lblUser.Text = user.Nombre;
                     if (!string.IsNullOrEmpty(user.ImagenPerfil) || File.Exists("~/Images/" + user.ImagenPerfil))
                {
                    imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
                else
                {
                    imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
                }

            if (Seguridad.esAdmin(user))
                { banderaadmin = true; }
                else
                {
                }
            }
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        protected void btnAvatar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

    }
}