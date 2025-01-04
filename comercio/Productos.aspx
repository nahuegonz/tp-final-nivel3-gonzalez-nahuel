<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Comercio.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .hiddencol {
            display: none;
        }
    </style>

    <h2 class="m-5">Productos</h2>

    <asp:GridView ID="dgvProductos" class="table table-hover" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
        OnPageIndexChanging="dgvProductos_PageIndexChanging" AllowPaging="true" PageSize="10" OnRowCommand="dgvProductos_RowCommand">
        <%--OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged"--%>
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="Id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="📝" />
            <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="🗑️" />
            <%--<asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="📝" />--%>
            <%--<asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="🗑️" />--%>
        </Columns>
    </asp:GridView>
    <a href="Modificar.aspx" class="btn btn-primary">Agregar</a>






</asp:Content>
