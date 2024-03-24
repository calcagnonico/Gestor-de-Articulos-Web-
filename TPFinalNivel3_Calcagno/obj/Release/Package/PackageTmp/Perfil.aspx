<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
                // Funcion q muestra la imagen de error si la ruta no esta correcta
                  function imgError(me) {
                  var AlterNativeImg = "/Images/error.jpeg";
                  if (AlterNativeImg != me.src)
                  me.src = AlterNativeImg;
                    }
    </script>

        <p></p>
<h2>
<asp:Label ID="Titulo" runat="server" Text="Mi Perfil" />
</h2>


 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
             <asp:PostBackTrigger ControlID="btnGuardar" />
            </Triggers>
                <ContentTemplate>

    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RegularExpressionValidator ControlToValidate="txtEmail" ErrorMessage="Campo Inválido" runat="server" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"  ForeColor="Red" 
        Type="Integer" Enabled="True" Display="Dynamic"/>

            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" ForeColor="Red"/>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" MaxLength="20"/>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El apellido es requerido" ControlToValidate="txtApellido" runat="server" ForeColor="Red"/>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="20" required="1"/>
            </div>

            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date"/>
                <asp:CustomValidator runat="server" id="CustomValidator3" ControlToValidate="txtFechaNacimiento" 
                onservervalidate="CustomValidator3_ServerValidate"
                ErrorMessage="Ingrese una fecha válida" ForeColor="red">
                </asp:CustomValidator>
            </div>
  
                <%  
                if (cambiarclave)
                {
                %>
                <div class="mb-3">
                <asp:Label ID="lblClaveActual" CssClass= "form-label" runat="server" Text="Ingrese su Contraseña Actual" />
                <asp:TextBox runat="server" CssClass="form-control" ID="ClaveActual" required="1" AutoCompleteType="Disabled"/>
                <asp:CustomValidator runat="server" id="CustomValidator1" ControlToValidate="ClaveActual" 
                onservervalidate="controlclaveactual_ServerValidate"   
                ErrorMessage="Contraseña incorrecta" ForeColor="red">
                </asp:CustomValidator>
                </div>
                <div class="mb-3">
                <label class="form-label">Nueva Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="NuevaClave" type="password" TextMode="Password" required="1" CausesValidation="true"/>
                </div>
                <div class="mb-3">
                <label class="form-label">Repetir Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="NuevaClave2" type="password" TextMode="Password" required="1" CausesValidation="true"/>
                <asp:CompareValidator runat="server" ControlToCompare="NuevaClave" ControlToValidate="NuevaClave2"
                ErrorMessage="Las claves no coinciden" ForeColor="Red" Display="Dynamic">
                </asp:CompareValidator>
                </div>

                                        <%if ((bool)Session["banderaedicionadmin"])
                                                    {
                                                    %>
                                                    <div class="mb-3">
                                                    <asp:Label ID="txtclaveadmin" CssClass="form-label" runat="server" Text="Ingrese su Contraseña de admin" />
                                                    <asp:TextBox runat="server" CssClass="form-control" ID="claveadmin" required="1" AutoCompleteType="Disabled"/>
                                                    <asp:CustomValidator runat="server" id="CustomValidator2" ControlToValidate="claveadmin" 
                                                    onservervalidate="claveadmin_ServerValidate"   
                                                    ErrorMessage="Contraseña incorrecta" ForeColor="red">
                                                    </asp:CustomValidator>
                                                    </div>
                                                    <%} else{ %> <%} %>
                <%
                }
                else
                {
                %>

                <%
                }
                %>

        </div>
        <div class="col-md-4">
            <div class="mb-3">
            <label class="form-label">Imagen Perfil</label>
            <asp:FileUpload id="FileUploadControl" accept="image/*" multiple="false" runat="server" CssClass="form-control" Onchange="imgNuevoPerfil.src = window.URL.createObjectURL(this.files[0])"/>
         </div>
     
     <img src="~/Images/error.jpeg" id="imgNuevoPerfil" onerror="imgError(this)" CssClass="img-fluid mb-3" runat="server" width="415" ClientIDMode="Static"/>

        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
             <%if ((bool)Session["banderaedicionadmin"]){ %> 
             <%if (!(bool)Session["esadmin"]){ %>
            <%} else{ %> 
            <%} %>
            <a href="Usuarios.aspx" Class="btn btn-primary" ">Cancelar</a>
            <%} else{ %>
            <a href="Main.aspx" Class="btn btn-primary" ">Cancelar</a>
             <%} %>
            <asp:Button Text="Cambiar clave" CssClass="btn btn-primary" OnClick="Cambiarclavebtn_Click" ID="Cambiarclavebtn" runat="server" Autopostback="true" formNoValidate="false" CausesValidation="false" UseSubmitBehavior="false"/>
                </div>
           <div class="col-md-4">
            

            <%if ((bool)Session["banderaedicionadmin"]){ %> 
            
                <%if (!(bool)Session["esadmin"]){ %>
                <asp:Button Text="Hacer admin" CssClass="btn btn-dark" OnClick="Convertir_Click" ID="Convertir" runat="server"  CausesValidation="false" UseSubmitBehavior="false"/>
                <%} else{ %> 
                <asp:Button Text="Borrar admin" CssClass="btn btn-dark" OnClick="EliminarAdmin_Click" ID="EliminarAdmin" runat="server"  CausesValidation="false" UseSubmitBehavior="false"/>
                <%} %>
                <asp:Button Text="Borrar usuario" CssClass="btn btn-danger" OnClick="EliminarUser_Click" ID="Button1" runat="server"  CausesValidation="false" UseSubmitBehavior="false"/>
                               <%if ((bool)Session["confirmareliminacionuser"]){ %>
                            <br />
               <asp:CheckBox Text="" ID="chkConfirmaEliminacion" runat="server" />
               <label class="form-label">Confirmar</label>
               <asp:Button Text="Eliminar" style="margin-top: 10px; margin-right: 20px" ID="btnConfirmaEliminarUser" OnClick="btnConfirmaEliminarUser_Click" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" UseSubmitBehavior="false"/>
               </div>
                     <%} else{ %> 
                    <%} %>      
           </div>
            <%} else{ %>
            </div>
            <%} %>
              </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>