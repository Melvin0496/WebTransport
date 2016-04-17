<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rAutobuses.aspx.cs" Inherits="WebTransport.Registros.rAutobuses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-success text-center">
        <div class="panel-heading">Registro de Autobuses</div>

        <div class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--AutobusId--%>
                <div class="form-group">
                    <label for="AutobusIdTextBox" class="col-md-3 control-label input-sm">AutobusId: </label>
                    <div class="col-md-4 col-sm-2 col-xs-4">
                        <asp:TextBox ID="AutobusIdTextBox" runat="server" placeholder="Introduzca un ID aqui" class="form-control input-sm" type="number"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click"/>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Ficha--%>
                <div class="form-group">
                    <label for="FichaTextBox" class="col-md-3 control-label input-sm">Ficha: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="FichaTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="6"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="FichaRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="AutobusesForm" ControlToValidate="FichaTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Marca--%>
                <div class="form-group">
                    <label for="MarcaTextBox" class="col-md-3 control-label input-sm">Marca: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="MarcaTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="MarcaRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="AutobusesForm" ControlToValidate="MarcaTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Modelo--%>
                <div class="form-group">
                    <label for="ModeloTextBox" class="col-md-3 control-label input-sm">Modelo: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="ModeloTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ModeloRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="AutobusesForm" ControlToValidate="ModeloTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Ano--%>
                <div class="form-group">
                    <label for="AnnoTextBox" class="col-md-3 control-label input-sm">Año: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="AnnoTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="4" type="number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AnnoRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="AutobusesForm" ControlToValidate="AnnoTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-2">
                    </div>
                </div>

                <%--Cantidad Pasajeros--%>
                <div class="form-group">
                    <label for="CantidadPasajerosTextBox" class="col-md-3 control-label input-sm">Cantidad Pasajeros: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="CantidadPasajerosTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="2" type="number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CantidadPasajerosRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="AutobusesForm" ControlToValidate="CantidadPasajerosTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>


                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Aire--%>
                <div class="form-group">
                    <label for="AireCheckBox" class="col-md-3 control-label input-sm">Aire: </label>
                    <div class="col-md-1">
                        <asp:CheckBox ID="AireCheckBox" runat="server"></asp:CheckBox>
                        
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
                    <asp:Button Text="Guardar" class="btn btn-primary btn-md" runat="server" ID="GuadarButton" ValidationGroup="AutobusesForm" OnClick="GuadarButton_Click" />
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>

</asp:Content>
