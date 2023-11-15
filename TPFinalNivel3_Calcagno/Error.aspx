<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinalNivel3_Calcagno.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <p></p>
        <h2 id="title"><%: Title %></h2>

        <asp:label text="text" id="lblError" runat="server" />

    </main>



</asp:Content>
