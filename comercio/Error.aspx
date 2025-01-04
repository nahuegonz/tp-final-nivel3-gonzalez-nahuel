<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Comercio.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="m-5">Error</h2>
    <div class="m-5">
        <asp:label text="Ha ocurrido un error." id="lblError" runat="server" />

    </div>
    <div class="m-5">
        <a href="Default.aspx" runat="server" Class="btn btn-primary">Regresar</a>
    </div>


</asp:Content>
