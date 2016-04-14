<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rReservaciones.aspx.cs" Inherits="WebTransport.Registros.rReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="panel panel-success text-center">
        <div class="panel-heading">Registro de Reservaciones</div>

        <div class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--ReservacionId--%>
                <div class="form-group">
                    <label for="ReservacioIdTextBox" class="col-md-3 control-label input-sm">ReservacionId: </label>
                    <div class="col-md-4 col-sm-2 col-xs-4">
                        <asp:TextBox ID="ReservacionIdTextBox" runat="server" placeholder="Introduzca un ID aqui" class="form-control input-sm" type="number"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--UsuarioId--%>
                <div class="form-group">
                    <label for="UsuarioIdDropDownList" class="col-md-3 control-label input-sm">UsuarioId: </label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="UsuarioIdDropDownList" runat="server" Class="form-control btn-info input-sm"></asp:DropDownList>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                 <%--Lugar--%>
                <div class="form-group">
                    <label for="LugarTextBox" class="col-md-3 control-label input-sm">Lugar: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="LugarTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="100" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="LugarRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ReservacionForm" ControlToValidate="LugarTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                 <%--Cantidad de Asientos--%>
                <div class="form-group">
                    <label for="CantidadAsientoTextBox" class="col-md-3 control-label input-sm">Cantidad de Asientos: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="CantidadAsientoTextBox" runat="server" Class="form-control input-sm" placeholder="(Requerido)" MaxLength="2"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="CantidadRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ReservacionForm" ControlToValidate="CantidadAsientoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="auto-style1">
                    </div>
                </div>

                 <%--Fecha--%>
                <div class="form-group">
                    <label for="FechaTextBox" class="col-md-3 control-label input-sm">Fecha: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="FechaTextBox" runat="server" Class="form-control input-sm" type="date" ></asp:TextBox>


                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                 <%--esActiva--%>
                <div class="form-group">
                    <label for="esActivaCheckBox" class="col-md-3 control-label input-sm">esActiva: </label>
                    <div class="col-md-1">
                        <asp:CheckBox ID="esActivaCheckBox" runat="server" Class="checkbox" ></asp:CheckBox>


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
                    <asp:Button Text="Guardar" class ="btn btn-primary btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" ValidationGroup="ReservacionForm" />
                    <asp:Button Text="Eliminar" class ="btn btn-danger btn-md" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>

</asp:Content>
