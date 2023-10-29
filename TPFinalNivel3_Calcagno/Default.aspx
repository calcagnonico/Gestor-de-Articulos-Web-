<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Calcagno._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Iniciar Sesion</h2>

     </section>
        <div class="row">
            <section class="col-md-4">
                <div class="form-floating mb-3">
                <input type="email" class="form-control" id="floatingInput" placeholder="usuario@email.com">
                <label for="floatingInput">E-mail</label>
        </div>
        <div class="form-floating">
                <input type="password" class="form-control" id="floatingPassword" placeholder="Password" aria-describedby="form-floating-sizing-sm">
                <label for="floatingPassword">Contraseña</label>
                <p>
        </div>
        <p>
        <a href="http://www.asp.net" class="btn btn-primary btn-md">Ingresar &raquo;</a>
        <a href="http://www.asp.net" class="btn btn-primary btn-md">Crear usuario &raquo;</a>
        </p>
      </section>

      <section class="col-md-4" aria-labelledby="librariesTitle">
      </section>

      <section class="col-md-4" aria-labelledby="hostingTitle">
      </section>
      </div>
    </main>

</asp:Content>
