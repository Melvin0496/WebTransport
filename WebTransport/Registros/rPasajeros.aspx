<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPasajeros.aspx.cs" Inherits="WebTransport.Registros.rPasajeros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-success text-center">
        <div class="panel-heading">Registro de Pasajeros</div>

        <div class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--PasajeroId--%>
                <div class="form-group">
                    <label for="PasajeroIdTextBox" class="col-md-3 control-label input-sm">PasajeroId: </label>
                    <div class="col-md-4 col-sm-2 col-xs-4">
                        <asp:TextBox ID="PasajeroIdTextBox" runat="server" placeholder="0" class="form-control input-sm" type="number"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Nombres--%>
                <div class="form-group">
                    <label for="NombresTextBox" class="col-md-3 control-label input-sm">Nombres: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="NombresTextBox" runat="server" Class="form-control input-sm" placeholder="'Melvin Santiago'"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Botones--%>
                <div class="panel-footer col-md-offset-1">
                    <div class="text-center">
                        <div class="form-group" style="display: inline-block">

                            <asp:Button Text="Nuevo  " class="btn btn-warning btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                            <asp:Button Text="Guardar" class="btn btn-primary btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                            <asp:Button Text="Eliminar" class="btn btn-danger btn-md" runat="server" ID="EliminarButton" />

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
