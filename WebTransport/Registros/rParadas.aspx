<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rParadas.aspx.cs" Inherits="WebTransport.Registros.rParadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-success text-center">
        <div class="panel-heading">Registro de Paradas</div>

        <div id="Form" class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--ParadaId--%>
                <div class="form-group">
                    <label for="ParadaIdTextBox" class="col-md-3 control-label input-sm">ParadaId: </label>
                    <div class="col-md-4 col-sm-2 col-xs-4">
                        <asp:TextBox ID="ParadaIdTextBox" runat="server" placeholder="0" class="form-control input-sm" type="number"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Lugar--%>
                <div class="form-group">
                    <label for="LugarTextBox" class="col-md-3 control-label input-sm">Lugar: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="LugarTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="LugarRequiredFieldValidator" runat="server" ControlToValidate="LugarTextBox" ErrorMessage="No puede dejar este campo vacío" ForeColor="Red" ValidationGroup="A" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Telefono--%>
                <div class="form-group">
                    <label for="TelefonoTextBox" class="col-md-3 control-label input-sm">Telefono: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="TelefonoTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="12"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="TelefonoRequiredFieldValidator" runat="server" ControlToValidate="TelefonoTextBox" ErrorMessage="No puede dejar este campo vacío" ForeColor="Red" ValidationGroup="A" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>
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
                    <asp:Button Text="Guardar" class="btn btn-primary btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" ValidationGroup="A" />
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>
</asp:Content>
