<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rChoferes.aspx.cs" Inherits="WebTransport.Registros.rChoferes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="panel panel-success text-center">
        <div class="panel-heading">Registro de Choferes</div>

        <div class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--ChoferId--%>
                <div class="form-group">
                    <label for="ChoferIdTextBox" class="col-md-3 control-label input-sm">ChoferId: </label>
                    <div class="col-md-4 col-sm-2 col-xs-4">
                        <asp:TextBox ID="ChoferIdTextBox" runat="server" placeholder="Introduzca un ID aqui" class="form-control input-sm" type="number"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                 <%--AutobusId--%>
                <div class="form-group">
                    <label for="AutobusIdDropDownList" class="col-md-3 control-label input-sm">AutobusId: </label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="AutobusIdDropDownList" runat="server" Class="form-control input-sm btn-bitbucket" ></asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Nombres--%>
                <div class="form-group">
                    <label for="NombresTextBox" class="col-md-3 control-label input-sm">Nombres: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="NombresTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NombresRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ChoferesForm" ControlToValidate="NombresTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                 <%--Apellidos--%>
                <div class="form-group">
                    <label for="ApellidosTextBox" class="col-md-3 control-label input-sm">Apellidos: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="ApellidosTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ApellidosRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ChoferesForm" ControlToValidate="ApellidosTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                 <%--Cedula--%>
                <div class="form-group">
                    <label for="CedulaTextBox" class="col-md-3 control-label input-sm">Cedula: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="CedulaTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="14" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CedulaRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ChoferesForm" ControlToValidate="CedulaTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-2">
                    </div>
                </div>

                 <%--Anos Servicios--%>
                <div class="form-group">
                    <label for="AnoServicioTextBox" class="col-md-3 control-label input-sm">Años en servicio: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="AnoServicioTextBox" runat="server" Class="form-control input-sm" placeholder="(Opcional)" MaxLength="2" type="number"></asp:TextBox>


                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                 <%--Telefono--%>
                <div class="form-group">
                    <label for="TelefonoTextBox" class="col-md-3 control-label input-sm">Telefono: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="TelefonoTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" TextMode="Phone" MaxLength="12"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="TelefonoRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ChoferesForm" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" Font-Bold="True"></asp:RequiredFieldValidator>

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

                    <asp:Button Text="Nuevo  " class ="btn btn-warning btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class ="btn btn-primary btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" ValidationGroup="ChoferesForm" />
                    <asp:Button Text="Eliminar" class ="btn btn-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>

</asp:Content>
