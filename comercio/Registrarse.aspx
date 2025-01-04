<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Comercio.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="m-5">Regístrate</h2>

    <div class="row d-flex justify-content-center">

        <div class="row d-flex justify-content-center">
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" Type="Password" CssClass="form-control" ID="txtPass" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
                    <%--<asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />--%>
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="8">
                    </asp:TextBox>
                    <%--<asp:RangeValidator ErrorMessage="Fuera de rango.." ControlToValidate="txtApellido" Type="Integer" MinimumValue="1" MaximumValue="20" runat="server" />--%>
                    <%--<asp:RegularExpressionValidator ErrorMessage="Formato email por favor" ControlToValidate="txtApellido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>

                    <%--<asp:RegularExpressionValidator ErrorMessage="Formato incorrecto..." ControlToValidate="txtApellido" ValidationExpression="^[0-9]+$" runat="server"/>--%>
                </div>

            </div>
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Imagen de Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                    runat="server" CssClass="img-fluid mb-3" />

            </div>

        </div>
        <div class="row d-flex justify-content-center">
            <div class="col-md-4 m-5">
                <asp:Button Text="Registrarse" CssClass="btn btn-primary me-3" ID="btnRegistrarCuenta" runat="server" />
                <a href="Default.aspx">Regresar</a>
            </div>
        </div>
    </div>




</asp:Content>
