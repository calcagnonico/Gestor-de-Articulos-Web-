<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="TPFinalNivel3_Calcagno.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

         <section class="row" aria-labelledby="aspnetTitle">
            <p></p>


            <h2 id="aspnetTitle">
            <asp:Label ID="Titulo" runat="server" Text="Agregar Articulo"></asp:Label>
            </h2>


     </section>

      <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="TxtId" class="form-label">Id: </label>
                <asp:TextBox runat="server" ID="TxtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="TxtCodigo" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="TxtCodigo" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="TxtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="TxtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="TxtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="TxtPrecio" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>

                <label for="ddlMarca" class="form-label">Marca: </label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="Main.aspx" class="btn btn-primary">Cancelar</a>
                <asp:Button Text="Inactivar" ID="btnInactivar" OnClick="btnInactivar_Click" CssClass="btn btn-warning" runat="server" />
            </div>
        </div>
            <div class="col-6">
            <div class="mb-3">
                <label for="TxtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" height="123px" ID="TxtDescripcion" CssClass="form-control" />

         <label for="ddlEstado" class="form-label">Estado: </label>
         <asp:DropDownList ID="ddlEstado" CssClass="form-select" runat="server"></asp:DropDownList>

         </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>

                        <asp:TextBox runat="server" ID="TxtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgArticulo" Width="60%"/>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>

                    <%if (ConfirmaEliminacion)
                        { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
