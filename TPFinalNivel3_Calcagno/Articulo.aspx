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

            <label for="ddlCategoria" class="form-label">Categoria:</label>
            <div class="columnas1" Cssclass="columnas">
                <asp:DropDownList ID="ddlCategoria" 
                    class="btn btn-secondary btn-sm dropdown-toggle" 
                    type="button" 
                    data-toggle="dropdown" 
                    aria-haspopup="true" 
                    aria-expanded="false" 
                    runat="server">
                </asp:DropDownList>
                <p></p>
                <label for="ddlMarca" class="form-label">Marca:</label>
                <br/>
                <asp:DropDownList ID="ddlMarca" 
                    class="btn btn-secondary btn-sm dropdown-toggle" 
                    type="button" 
                    data-toggle="dropdown" 
                    aria-haspopup="true" 
                    aria-expanded="false" 
                    runat="server">
                </asp:DropDownList>
                </div>
                <p></p>
            <p></p>

            <div class="mb-3">
                <br />
                <br />
                <br />
                <br />
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="Main.aspx" class="btn btn-primary">Cancelar</a>
                <asp:Button Text="Inactivar" ID="btnInactivar" OnClick="btnInactivar_Click" CssClass="btn btn-warning" runat="server" />
                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />     
                            <p></p>

                <div class="mb-3">
                    </div>
                    <%if (ConfirmaEliminacion)
                        { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                    <%} %>
            </div>
        </div>




            <div class="col-6">
            <div class="mb-3">
                <label for="TxtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" style="resize:none" height="138px" resize="none" ID="TxtDescripcion" CssClass="form-control" />
            <p></p>
            <p></p>
                <label for="Estado" class="form-label">Estado</label>
                <div class="form-check form-switch">
                <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault">
                </div>
                </div>
                <p></p>

           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <p></p>
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" 
                        ID="TxtImagenUrl" 
                        CssClass="form-control"
                        AutoPostBack="true" 
                        OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                    runat="server" 
                    ID="imgArticulo"
                    style="Height: 300px"/>
                </ContentTemplate>
            </asp:UpdatePanel>
         </div>


    </div>
</asp:Content>
