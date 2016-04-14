<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rTipoEnvios.aspx.cs" Inherits="WebTransport.Registros.rTipoEnvios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-success text-center">
        <div class="panel-heading">Registro de Tipo envios</div>

        <div id="Form" class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--TipoEnvioId--%>
                <div class="form-group">
                    <label for="TipoEnvioIdTextBox" class="col-md-3 control-label input-sm">TipoEnvioId: </label>
                    <div class="col-md-4 col-sm-2 col-xs-4">
                        <asp:TextBox ID="TipoEnvioIdTextBox" runat="server" placeholder="Introduzca un ID aqui" class="form-control input-sm" type="number"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Descripcion--%>
                <div class="form-group">
                    <label for="DescripcionTextBox" class="col-md-3 control-label input-sm">Descripcion: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="DescripcionTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="100"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="DescripcionRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="TipoEnvioForm" Display="Dynamic" Font-Bold="True" ForeColor="Red" ControlToValidate="DescripcionTextBox"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-1">
                    </div>
                </div>
            </div>
        </div>

        <%--Botones--%>
        <div class="panel-footer col-md-offset-1">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo  " class="btn btn-warning btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-primary btn-md" runat="server" ID="GuardarButton" OnClick="GuardarButton_Click" ValidationGroup="TipoEnvioForm" />
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>


</asp:Content>
