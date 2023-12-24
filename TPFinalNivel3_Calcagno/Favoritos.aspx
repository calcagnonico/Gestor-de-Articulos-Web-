﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



          <main>
      <section class="row" aria-labelledby="aspnetTitle">
            <p></p>
            <h2 id="aspnetTitle">Gestionar Articulos</h2>
     </section>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" 
                    CssClass="" ID="chkAvanzado" runat="server" 
                    AutoPostBack="true"
                    OnCheckedChanged="chkAvanzado_CheckedChanged"/>

            </div>
        </div>

        <%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" id="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" DataTextField="Seleccione">
                        <asp:ListItem Text="Codigo" />
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Marca" />
                        <asp:ListItem Text="Descripcion" />
                        <asp:ListItem Text="Categoria" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Estado" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" id="btnBuscar" OnClick="btnBuscar_Click"/>
                </div>
            </div>
        </div>
        <%} %>
    </div>
    <asp:GridView ID="dgvlistaArticulos" runat="server" 
                  DataKeyNames="artid"
                  CssClass= "table table-striped table-bordered table-condensed" 
                  AutoGenerateColumns="false"
                  OnSelectedIndexChanged="dgvlistaArticulos_SelectedIndexChanged"
                  OnPageIndexChanging="dgvlistaArticulos_PageIndexChanging"
                  EnableSortingAndPagingCallbacks="false"
                  AllowPaging="True" 
                  PageSize="3">
            <Columns>
            <asp:BoundField HeaderText="Id"            DataField="artid" />
            <asp:BoundField HeaderText="Codigo"        DataField="artcodigo" />
            <asp:BoundField HeaderText="Nombre"        DataField="artnombre" />
            <asp:BoundField HeaderText="Descripcion"   DataField="artdescripcion" />
            <asp:BoundField HeaderText="Marca"         DataField="artmarca.descripcion" />
            <asp:BoundField HeaderText="Categoria"     DataField="artcategoria.descripcion" />
            <asp:BoundField HeaderText="Precio"        DataField="artprecio" />
            <asp:CheckBoxField HeaderText="Estado"     DataField="artestado" />
            <asp:CommandField HeaderText="Gestionar"   ShowSelectButton="true" SelectText="✍" />
            </Columns>
    </asp:GridView>
    <a href="Articulo.aspx" class="btn btn-primary">Agregar</a>
    </main>














</asp:Content>