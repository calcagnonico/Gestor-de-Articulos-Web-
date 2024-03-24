<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Crea tu perfil</h2>
     </section>

     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>

    <div class="row">
     <section class="col-md-4">

        <div class="mb-3">
        <div class="form-floating mb-3" placeholder="usuario@email.com">
        <asp:TextBox ID="txtEmail" runat="server" Cssclass="form-control" REQUIRED="1" placeholder="usuario@email.com"/>
        <label for="floatingEmail" cssclass="form-control">E-Mail
        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ErrorMessage="Campo Inválido" runat="server" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"  ForeColor="Red" 
        Type="Integer" Enabled="True" Display="Dynamic"/>
        <asp:CustomValidator runat="server" id="Validaemailexistente" ControlToValidate="txtEmail" 
        onservervalidate="Validaemailexistente_ServerValidate"   
        ErrorMessage="El usuario ya existe" ForeColor="red"/>
        </label>
       </div>
        </div>
            <div class="mb-3">
            <div class="form-floating">
                <asp:TextBox runat="server" cssclass="form-control" ID="txtNombre" REQUIRED="1" placeholder="Nombre" />
                <label for="floatingNombre" cssclass="form-control">Nombre
    <asp:RegularExpressionValidator ControlToValidate="txtNombre" 
    ErrorMessage="Minimo 4 caracteres" 
    runat="server" ValidationExpression="^[\s\S]{4,20}$"
    ForeColor="Red" Type="Integer" Enabled="True" 
    Display="Dynamic"/>
                </label>
            </div>
              </div>
<div class="mb-3">
            <div class="form-floating">
                <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" REQUIRED="1" type="password" TextMode="Password" placeholder="Contraseña" />
                <label for="floatingPassword" cssclass="form-control">Contraseña
                <asp:RegularExpressionValidator ControlToValidate="txtPassword" 
                                                ErrorMessage="Minimo 6 caracteres" 
                                                runat="server" 
                                                ValidationExpression="^[\s\S]{6,20}$"
                                                ForeColor="Red" 
                                                Type="Integer" 
                                                Enabled="True" 
                                                Display="Dynamic"/>
                </label>
           </div>
</div>
            <div class="mb-3">
            <asp:Button Text="Continuar" cssclass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="Default" class="btn btn-primary btn-md">Salir</a>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
</main>
</asp:Content>
