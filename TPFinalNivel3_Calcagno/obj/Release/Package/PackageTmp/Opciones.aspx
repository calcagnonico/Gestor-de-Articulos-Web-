<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Opciones.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



     <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Opciones</h2>
     </section>
         <p></p>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

<div class="row">

<label for="ListaCategorias" class="form-label">Categorias: </label>

          <div class="col-2" style="width:100px">
          </div>

          <div class="col-2" style="width:180px">
            <asp:ListBox ID="ListaCategorias" runat="server" Width="150px" Height="170px" CssStyle="list-group">
            </asp:ListBox>
            <br>
          </div>

          <div class="col-2" style="width:80px">
                <div class="row">
                <asp:Button Text="Agregar" ID="AgregarCategoria" Onclick="AgregarCategoria_Click" runat="server" CssClass="btn btn-secondary"/>
                </div>
                <div class="row" style="height:10px">
                </div>
                <div class="row">
                <asp:Button Text="Editar" ID="EditarCategoria" Onclick="EditarCategoria_Click" runat="server" CssClass="btn btn-secondary" />
                </div>
                <div class="row" style="height:10px">
                </div>
                <div class="row" style="height:10px">
                <asp:Button Text="Eliminar" ID="EliminarCategoria" OnClick="EliminarCategoria_Click" runat="server" CssClass="btn btn-danger" />
                </div>
          </div>

          <div class="col-2" style="width:20px">
          </div>

        <div class="col-2">
            <div class="row" style="height:38px">
            <%if (BAgregarCategoria)
            {
            %>
            <asp:Panel ID="Panel3" runat="server" defaultbutton="btnAgregarCategoria">
            <asp:TextBox runat="server" ID="TxtAgregarCategoria" CssClass="form-control"/>
            </asp:Panel > 


             <%}%>
             </div>
            
            <div class="row" style="height:10px">
            </div>

            <div class="row" style="height:38px">
            <%if (BEditarCategoria)
            {
            %>
            <asp:Panel ID="Panel4" runat="server" defaultbutton="btnEditarCategoria">
            <asp:TextBox runat="server" ID="TxtEditarCategoria" CssClass="form-control"/>
            </asp:Panel > 


             <%}%>
            </div>

            <div class="row" style="height:10px">
            </div>

            <div class="row" style="padding: 8px 0; height:38px">
            <%if (BEliminarCategoria)
            {
            %>
            Eliminar Categoria Seleccionada?
            <%}%>
            </div>
        </div>

        <div class="col-3" style="width:20px">
        </div>


    <div class="col-1">

                <div class="row" style="height:38px">
                <%if (BAgregarCategoria)
                {
                %>
                <asp:Button Text="Agregar" ID="btnAgregarCategoria" runat="server" CssClass="btn btn-primary" OnClick="btnAgregarCategoria_Click"/>
                <%}%>
                </div>


                <div class="row" style="height:10px">
                </div>

                <div class="row" style="height:38px">
                <%if (BEditarCategoria)
                {
                %>
                <asp:Button Text="Editar" ID="btnEditarCategoria" runat="server" CssClass="btn btn-primary" OnClick="btnEditarCategoria_Click"/>
                <%}%>
                </div>

                <div class="row" style="height:10px">
                </div>

                <div class="row" style="height:38px">
                <%if (BEliminarCategoria)
                {
                %>
                <asp:Button Text="Eliminar" ID="btnEliminarCategoria" runat="server" CssClass="btn btn-danger" OnClick="btnEliminarCategoria_Click"/>
                <%}%>
                </div>

    </div>

<br>




<div class="row">
            
<label for="ListaMarcas" class="form-label">Marcas: </label>

            <div class="col-2" style="width:100px">
            </div>

            <div class="col-2" style="width:180px" >
                <asp:ListBox ID="ListaMarcas" runat="server" Width="150px" Height="170px">
                </asp:ListBox>
                <br>
            </div>
                 
            <div class="col-2" style="width:80px">

                <div class="row">
                <asp:Button Text="Agregar" ID="AgregarMarca" runat="server" CssClass="btn btn-secondary" OnClick="AgregarMarca_Click" />
                </div>
                <div class="row" style="height:10px">
                </div>
                <div class="row">
                <asp:Button Text="Editar" ID="EditarMarca" runat="server" CssClass="btn btn-secondary" OnClick="EditarMarca_Click"/>
                </div>
                <div class="row" style="height:10px">
                </div>
                <div class="row">
                <asp:Button Text="Eliminar" ID="EliminarMarca" runat="server" CssClass="btn btn-danger" OnClick="EliminarMarca_Click"/>
                </div>

            </div>
     

              <div class="col-2" style="width:20px"> 
              </div>

              <div class="col-2">
                <div class="row" style="height:38px">
                <%if (BAgregarMarca)
                {
                %>

                <asp:Panel ID="Panel1" runat="server" defaultbutton="btnAgregarMarca">
                <asp:TextBox runat="server" ID="TxtAgregarMarca" CssClass="form-control"/>
                </asp:Panel > 

                <%}%>
                </div>

                <div class="row" style="height:10px">
                </div>

                <div class="row" style="height:38px">
                <%if (BEditarMarca)
                {
                %>
                <asp:Panel ID="Panel2" runat="server" defaultbutton="btnEditarMarca">
                <asp:TextBox runat="server" ID="TxtEditarMarca" CssClass="form-control"/>
                </asp:Panel >
                <%}%>
                </div>

                <div class="row" style="height:10px">
                </div>

                <div class="row"  style="padding: 8px 0; height:38px">
                <%if (BEliminarMarca)
                {
                %>
                Eliminar Marca seleccionada?
                <%}%>
                </div>
            </div>

            <div class="col-3" style="width:20px">
            </div>

            <div class="col-1">
                <div class="row" style="height:38px">
                <%if (BAgregarMarca)
                {
                %>
                <asp:Button Text="Agregar" ID="btnAgregarMarca" runat="server" CssClass="btn btn-primary" OnClick="btnAgregarMarca_Click" Autopostback="true"/>
                <%}%>
                </div>
    
                <div class="row" style="height:10px">
                </div>

                <div class="row" style="height:38px">
                <%if (BEditarMarca)
                {
                %>
                <asp:Button Text="Editar" ID="btnEditarMarca" runat="server" CssClass="btn btn-primary" OnClick="btnEditarMarca_Click"/>
                <%}%>
                </div>

                <div class="row" style="height:10px">
                </div>

                <div class="row" style="height:38px">
                <%if (BEliminarMarca)
                {
                %>
                <asp:Button Text="Eliminar" ID="btnEliminarMarca" runat="server" CssClass="btn btn-danger" OnClick="btnEliminarMarca_Click" />
                <%}%>
                </div>
            </div>
 </div>
</div>

   

                                          </ContentTemplate>
            </asp:UpdatePanel>
</main>
</asp:Content>
