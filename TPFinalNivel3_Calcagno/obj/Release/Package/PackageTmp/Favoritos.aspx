<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



          <main>
        <main>
     <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Articulos Favoritos</h2>
     </section>

    <div class="row">
        <div class="col-10">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
         </div>

         <div class="col-2">
                    <asp:Label Text="Criterio:" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="CriterioFRapido" DataTextField="Seleccione" OnSelectedIndexChanged="CriterioFRapido_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Codigo" />
                    </asp:DropDownList>
          </div>
        </div>

   <br>
    <asp:GridView ID="dgvlistaArticulos" runat="server" 
                  DataKeyNames="artid"
                  CssClass= "table table-striped table-bordered table-condensed" 
                  AutoGenerateColumns="false"
                  OnSelectedIndexChanged="dgvlistaArticulos_SelectedIndexChanged"
                  OnPageIndexChanging="dgvlistaArticulos_PageIndexChanging"
                  EnableSortingAndPagingCallbacks="false"
                  AllowPaging="True"
                  AllowSorting="True"
                  PageSize="10"
                  OnSorting="dgvlistaArticulos_Sorting"
                  >
            <PagerStyle CssClass="pagination1" />
            <Columns>
            <asp:BoundField HeaderText="ID"            DataField="artid"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="1%" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
            <asp:BoundField HeaderText="Codigo"        DataField="artcodigo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%"  SortExpression="artcodigo"/>
            <asp:BoundField HeaderText="Nombre"        DataField="artnombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50%" SortExpression="artnombre" />
            <asp:BoundField HeaderText="Marca"         DataField="artmarca.descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="15" SortExpression="artmarca"/>
            <asp:BoundField HeaderText="Categoria"     DataField="artcategoria.descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="15" SortExpression="artcategoria"/>
            <asp:BoundField HeaderText="Precio"        DataField="artprecio" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="10%" SortExpression="artprecio"/>
            <asp:CheckBoxField HeaderText="Estado"     DataField="artestado" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width ="3%" SortExpression="artestado"/>
            <asp:BoundField HeaderText="❤️​"            DataField ="artfav" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width ="2%"/>
            <asp:CommandField HeaderText="✏️"          ShowSelectButton="true" SelectText="📝​" ItemStyle-Width="2%" />
            </Columns>

    </asp:GridView>

         <div class="row">
         <div class="col-2">
<a href="Articulo.aspx" class="btn btn-primary">Agregar</a>
         </div>
 <div class="col-9" style="display: grid; align-items: center; text-align:right">
             <asp:Label Text="Articulos por página:" runat="server" style="text-align:right"/>
      </div>
<div class="col-1" style="text-align:right">
<asp:TextBox runat="server" TextMode="Number" ID="Cantidadxpagina" style="float: right" CssClass="form-control" Width="75px" OnTextChanged="Cantidadxpagina_TextChanged" AutoPostBack="true" />
</div>
</div>














</main>
</asp:Content>
