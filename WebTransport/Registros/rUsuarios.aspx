<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="WebTransport.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-success text-center">
        <div class="panel-heading">Registro de Usuarios</div>

        <div class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--UsuarioId--%>
                <div class="form-group">
                    <label for="UsuarioIdTextBox" class="col-md-3 control-label input-sm">UsuarioId: </label>
                    <div class="col-md-4 col-sm-2 col-xs-4">
                        <asp:TextBox ID="UsuarioIdTextBox" runat="server" class="form-control input-sm" type="number" placeholder="Introduzca el ID aqui"></asp:TextBox>
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
                        <asp:TextBox ID="NombresTextBox" runat="server" Class="form-control input-sm" placeholder="Introduzca su Nombre aqui"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Apellidos--%>
                <div class="form-group">
                    <label for="ApellidosTextBox" class="col-md-3 control-label input-sm">Apellidos: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="ApellidosTextBox" runat="server" Class="form-control input-sm" placeholder="Introduzca su Apellido aqui"></asp:TextBox>


                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Email--%>
                <div class="form-group">
                    <label for="EmailTextBox" class="col-md-3 control-label input-sm">Email: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="EmailTextBox" runat="server" Class="form-control input-sm" placeholder="Introduzca su Email aqui" type="email"></asp:TextBox>


                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Contraseña--%>


                <div class="form-group">
                    <label for="ContrasenaTextBox" class="col-md-3 control-label input-sm">Contraseña: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="ContrasenaTextBox" runat="server" class="form-control input-sm" placeholder="Introduzca su contraseña aqui" type="password"></asp:TextBox>

                    </div>
                    <div class="col-md-1">
                    </div>
                </div>


                <%--TipoUsuario--%>
                <div class="form-group">
                    <label for="TipoUsuarioDropDownList" class="col-md-3 control-label input-sm">Tipo de Usuario: </label>
                    <div class="col-md-5">
                        <asp:DropDownList ID="TipoUsuarioDropDownList" runat="server" Class="form-control input-sm">
                            <asp:ListItem>Administrador</asp:ListItem>
                            <asp:ListItem>Empleado</asp:ListItem>
                            <asp:ListItem>Normal</asp:ListItem>
                        </asp:DropDownList>


                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Fecha de nacimiento--%>
                <div class="form-group">
                    <label for="FechaDeNacimientoTextBox" class="col-md-3 control-label input-sm">Fecha de nacimiento: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="FechaDeNacimientoTextBox" runat="server" Class="form-control datepicker-dropdown input-sm" type="date" ></asp:TextBox>


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

                    <asp:Button Text="Nuevo" class="btn btn-warning btn-md" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-primary btn-md" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-md" runat="server" ID="EliminarButton" />

                </div>
            </div>

        </div>
    </div>

</asp:Content>
