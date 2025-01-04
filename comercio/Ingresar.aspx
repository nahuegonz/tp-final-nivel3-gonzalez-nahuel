<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingresar.aspx.cs" Inherits="Comercio.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="ms-5 mt-5">Ingresa a tu cuenta</h2>
    <div class="d-flex row justify-content-center mb-5">

        <div class="form-control d-flex row justify-content-center w-50 mt-5">
            <form class="px-4 py-3">
                <div class="d-flex row mb-3 mt-3">
                    <label for="lblEmail" class="form-label">Correo Electrónico</label>
                    <input type="email" class="form-control" id="txtEmail" placeholder="email@ejemplo.com">
                </div>
                <div class="d-flex row mb-3">
                    <label for="lblPass" class="form-label">Contraseña</label>
                    <input type="password" class="form-control" id="txtPass" placeholder="Contraseña">
                </div>
                <div class="mb-3">
                    <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="chkRecuerdame">
                        <label class="form-check-label" for="chkRecuerdame">
                            Recuérdame
                        </label>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary w-25 m-2">Ingresar</button>
            </form>
            <div class="dropdown-divider"></div>
            <a class="dropdown-item mt-2 mb-3 text-center" href="Registrarse.aspx">¿Eres nuevo? Regístrate aqui.</a>
        </div>

    </div>


</asp:Content>
