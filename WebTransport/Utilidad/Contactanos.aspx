<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="WebTransport.Utilidad.Contactanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-success text-center">
        <div class="panel-heading">Contáctanos</div>

        <div class="panel-body col-md-offset-2">
            <div class="form-horizontal col-md-12" role="form">

                <%--Nombres--%>
                <div class="form-group">
                    <label for="NombresTextBox" class="col-md-3 control-label input-sm">Nombres: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="NombresTextBox" runat="server" Class="form-control input-sm" placeholder="Nombres" MaxLength="40"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NombresRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ContactoForm" ControlToValidate="NombresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-1">
                    </div>
                </div>

                <%--Email--%>
                <div class="form-group">
                    <label for="EmailTextBox" class="col-md-3 control-label input-sm">Email: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="EmailTextBox" runat="server" Class="form-control input-sm" placeholder="Email" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ContactoForm" ControlToValidate="EmailTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                    <div class="auto-style1">
                    </div>
                </div>

                <%--Mensaje--%>
                <div class="form-group">
                    <label for="MensajeTextBox" class="col-md-3 control-label input-sm">Mensaje: </label>
                    <div class="col-md-5">
                        <asp:TextBox ID="MensajeTextBox" runat="server" Class="form-control input-sm" placeholder="Mensaje" MaxLength="500" Rows="5" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="MensajeRequiredFieldValidator" runat="server" ErrorMessage="No puede dejar este campo vacío" ValidationGroup="ContactoForm" ControlToValidate="MensajeTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

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

                    <asp:Button Text="Enviar" class="btn btn-success btn-block" runat="server" ID="EnviarButton" ValidationGroup="ContactoForm" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
