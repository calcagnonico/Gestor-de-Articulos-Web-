using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public bool cambiarclave = false;
        public bool banderaedicionadmin = false;
        public bool confirmareliminacionuser = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    Page.Form.Enctype = "multipart/form-data";
                    //Usamos esta bool para mostrar u ocultar el cambio de contraseña
                    Session.Add("cambiarclave", cambiarclave);
                    Session.Add("banderaedicionadmin", banderaedicionadmin);
                    Session.Add("confirmareliminacionuser", confirmareliminacionuser);

                    //Traemos nuestro usuario actual
                    Usuario user = (Usuario)Session["usuario"];

                    //Buscamos si tenemos una string de usuario a editar proveniente de una cuenta admin
                    string iduseredicionId = Request.QueryString["idusuarioedicion"] != null ? Request.QueryString["idusuarioedicion"].ToString() : "";

                    //Si venimos con la edicion vamos a chequear que sea admin tambien y tambien como ultima condicion chequeamos q el id no sea el del usuario actual
                    if (iduseredicionId != "" && !IsPostBack && Seguridad.esAdmin(user) && user.Id != Convert.ToInt32((Request.QueryString["idusuarioedicion"])))
                    {
                        try
                        {
                        banderaedicionadmin = true;
                        Session.Add("banderaedicionadmin", banderaedicionadmin);
                        Titulo.Text = "Editar Usuario";
                        UsuarioNegocio usernegocio = new UsuarioNegocio();
                        Usuario useredicion = new Usuario();
                        usernegocio.CargarUser(iduseredicionId, useredicion);

                        ClaveActual.ReadOnly = true;
                        ClaveActual.Enabled = false;
                        ClaveActual.TextMode = TextBoxMode.SingleLine;
                        lblClaveActual.Text = "Contraeña del usuario";
                        ClaveActual.Text = useredicion.Pass;
                        txtEmail.Text = useredicion.Email;
                        txtNombre.Text = useredicion.Nombre;
                        txtApellido.Text = useredicion.Apellido;
                        txtFechaNacimiento.Text = useredicion.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(useredicion.ImagenPerfil) || File.Exists("~/Images/" + user.ImagenPerfil))
                        imgNuevoPerfil.Src = "~/Images/" + useredicion.ImagenPerfil + "?img=" + numrandom();

                        Session.Add("useredicion", useredicion);
                        Session.Add("esadmin", useredicion.Admin);
                        }
                        catch (Exception)
                        {
                        throw;
                        }
                    }
                    else
                    {
                        if (Seguridad.sesionActiva(Session["usuario"]))
                        {
                            banderaedicionadmin = false;
                            Session.Add("banderaedicionadmin", banderaedicionadmin);
                            Titulo.Text = "Mi Perfil";
                            lblClaveActual.Text = "Ingrese su contraseña actual";
                            txtEmail.Text = user.Email;
                            txtNombre.Text = user.Nombre;
                            txtApellido.Text = user.Apellido;
                            txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                            if (!string.IsNullOrEmpty(user.ImagenPerfil) || File.Exists("~/Images/" + user.ImagenPerfil))
                            imgNuevoPerfil.Src = "~/Images/" + user.ImagenPerfil + "?img=" + numrandom();
                            ClaveActual.TextMode = TextBoxMode.Password;
                        }
                        else
                        {
                        }
                        Session.Add("cambiarclave", false);
                    }
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
                int rdm = numrandom();
                imgNuevoPerfil.Src = FileUploadControl.FileName + "?img=" + rdm;
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
                Usuario useredit = new Usuario(); 

                string iduseredicionId = Request.QueryString["idusuarioedicion"] != null ? Request.QueryString["idusuarioedicion"].ToString() : "";
                //actualizarclave
                if (iduseredicionId != "" && Seguridad.esAdmin(user))
                {
                    useredit = (Usuario)Session["useredicion"];
                }
                else
                {
                    useredit = (Usuario)Session["usuario"];
                }

                
               //Escribir img si se cargó algo.
                if (FileUploadControl.PostedFile.FileName != "" & FileUploadControl.PostedFile.FileName != null)
                {
                    string ruta = Server.MapPath("./Images/");
                    FileUploadControl.PostedFile.SaveAs(ruta + "perfil-" + useredit.Id + ".jpg");
                    useredit.ImagenPerfil = "perfil-" + useredit.Id + ".jpg";

                }


                useredit.Nombre = txtNombre.Text;
                useredit.Apellido = txtApellido.Text;
                useredit.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                useredit.Email = txtEmail.Text;

                //guardar datos perfil
                negocio.actualizar(useredit);
                
                //actualizarclave
                    if ((bool)Session["cambiarclave"] & NuevaClave.Text == NuevaClave2.Text)
                    {
                        negocio.actualizarclave(NuevaClave2.Text, useredit);
                    }
                     else
                    {
                    }
                
                limpiarsession();

                if (user.Id == useredit.Id )
                {
                    Response.Redirect("Main.aspx", false);
                }
                else
                {
                    Response.Redirect("Usuarios.aspx", false);
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
            if ((bool)(Session["banderaedicionadmin"]) == true)
            {
                e.IsValid = true;
            }
            else
            {
                Usuario user = (Usuario)Session["usuario"];
                if (ClaveActual.Text == user.Pass)
                    e.IsValid = true;
                else
                    e.IsValid = false;
            }
        }

        protected void claveadmin_ServerValidate(object source, ServerValidateEventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];
            if (e.Value == user.Pass)
                e.IsValid = true;
            else
                e.IsValid = false;
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime testDate = DateTime.MinValue;
            DateTime minDateTime = DateTime.MaxValue;
            DateTime maxDateTime = DateTime.MinValue;

            minDateTime = new DateTime(1753, 1, 1);
            maxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 997);

            if (DateTime.TryParse(args.Value, out testDate))
            {
                if (testDate >= minDateTime && testDate <= maxDateTime)
                {
                    args.IsValid = true;
                }
                else { args.IsValid = false; }
            }

        }

        protected void Convertir_Click(object sender, EventArgs e)
        {
            Usuario useredit = (Usuario)Session["useredicion"];
            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.Haceradmin(useredit.Id, 1);
            limpiarsession();
            Response.Redirect("Usuarios.aspx", false);
        }

        protected void EliminarAdmin_Click(object sender, EventArgs e)
        {
            Usuario useredit = (Usuario)Session["useredicion"];
            UsuarioNegocio negocio = new UsuarioNegocio();
            negocio.Haceradmin(useredit.Id, 0);
            limpiarsession();
            Response.Redirect("Usuarios.aspx", false);
        }

        protected void EliminarUser_Click(object sender, EventArgs e)
        {
            if (!(bool)Session["confirmareliminacionuser"])
            {
                Session.Add("confirmareliminacionuser", true);
                confirmareliminacionuser = (bool)Session["confirmareliminacionuser"];
            }
            else
            {
                Session.Add("confirmareliminacionuser", false);
                confirmareliminacionuser = (bool)Session["confirmareliminacionuser"];
            }

        }

        protected void btnConfirmaEliminarUser_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario useredit = (Usuario)Session["useredicion"];
            negocio.eliminarusuario(useredit.Id);

            limpiarsession();
            Response.Redirect("Usuarios.aspx", false);

        }

        protected void limpiarsession()
        {
            Session.Remove("useredicion");
          //  Session.Remove("confirmareliminacionuser");
          //  Session.Remove("banderaedicionadmin");
            Session.Remove("cambiarclave");
            Session.Remove("idusuarioedicion");
        }

        public int numrandom()
        {
            int min = 00000;
            int max = 99999;
            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }


    }
}