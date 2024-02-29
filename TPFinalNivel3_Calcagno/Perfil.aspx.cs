using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using dominio;
using Microsoft.Ajax.Utilities;
using negocio;



namespace TPFinalNivel3_Calcagno
{

    public partial class WebForm3 : System.Web.UI.Page
    {
        public bool cambiarclave;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(user.ImagenPerfil) || File.Exists("~/Images/" + user.ImagenPerfil))
                        imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                    Session.Add("cambiarclave", false);

                }
                else
                {

                  cambiarclave = (bool)Session["cambiarclave"];

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnImagen_Click(object sender, EventArgs e)
        {
            if (this.FileUploadControl.HasFile)
            {
                imgNuevoPerfil.ImageUrl = FileUploadControl.FileName;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Esto tiene que estar si o si para que nos valide todos los campos antes de continuar
                Page.Validate();
                if (!Page.IsValid)
                    return;

                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario user = (Usuario)Session["usuario"];

                //Escribir img si se cargó algo.
                if (FileUploadControl.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    FileUploadControl.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";

                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);


                //guardar datos perfil
                negocio.actualizar(user);
                
                //actualizarclave
                    if ((bool)Session["cambiarclave"] & NuevaClave.Text == NuevaClave2.Text)
                    {
                        negocio.actualizarclave(NuevaClave2.Text, user);
                    }
                     else
                    {
                    }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void Cambiarclavebtn_Click(object sender, EventArgs e)
        {
            if (!(bool)Session["cambiarclave"])
            {
                Session.Add("cambiarclave", true);
                cambiarclave = (bool)Session["cambiarclave"];
            }
            else
            {
                Session.Add("cambiarclave", false);
                cambiarclave = (bool)Session["cambiarclave"];
            }

    }

        protected void controlclave_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value == NuevaClave.Text)
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        protected void controlclaveactual_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            if (ClaveActual.Text == user.Pass)
                e.IsValid = true;
            else
                e.IsValid = false;
        }

}
}