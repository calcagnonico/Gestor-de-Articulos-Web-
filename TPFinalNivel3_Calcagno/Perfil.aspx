<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


        <p></p>
        <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
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
            </div>


           <div class="mb-3">
                <asp:Button Text="Cambiar contraseña" CssClass="btn btn-primary" OnClick="Cambiarclavebtn_Click" ID="Cambiarclavebtn" runat="server" Autopostback="true" formNoValidate="false"/>
            </div>

                <%  
                if (cambiarclave)
                {
                %>
                <div class="mb-3">
                <label class="form-label">Contraseña Actual</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="ClaveActual" type="password" TextMode="Password" required="1" AutoCompleteType="Disabled"/>
                <asp:CustomValidator runat="server" id="CustomValidator1" ControlToValidate="ClaveActual" 
                onservervalidate="controlclaveactual_ServerValidate"   
                ErrorMessage="Contraseña incorrecta" ForeColor="red" />

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
                <asp:FileUpload id="FileUploadControl"  runat="server" CssClass="form-control"/>
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
            <a href="Main.aspx" Class="btn btn-primary" ">Cancelar</a>
        </div>
    </div>




















</asp:Content>



                <%--<asp:RegularExpressionValidator ErrorMessage="Formato email por favor" ControlToValidate="txtApellido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>

                <%--<asp:RegularExpressionValidator ErrorMessage="Formato incorrecto..." ControlToValidate="txtApellido" ValidationExpression="^[0-9]+$" runat="server"/>--%>