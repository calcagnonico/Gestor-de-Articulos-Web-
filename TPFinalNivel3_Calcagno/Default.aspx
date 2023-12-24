<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Iniciar Sesion</h2>

     </section>
        <div class="row">
            <section class="col-md-4">
                <div class="form-floating mb-3">
                <asp:TextBox ID="txtEmail" runat="server" cssclass="form-control" REQUIRED="1" placeholder="usuario@email.com"/>
                <label for="floatingInput">E-mail</label>
        </div>
        <div class="form-floating">
                <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" type="password" TextMode="Password" placeholder="Password"/>
                <label for="floatingPassword" cssclass="form-control">Contraseña</label>
                <p>
        </div>

        <p>

        <asp:Button Text="Ingresar" cssclass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server"/>
        <a href="Registro" class="btn btn-primary btn-md">Crear usuario &raquo;</a>
        </p>
      </section>

      <section class="col-md-4" aria-labelledby="librariesTitle">
      </section>
      <section class="col-md-4" aria-labelledby="hostingTitle">
      </section>
      </div>
    </main>

</asp:Content>
