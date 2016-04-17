<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cVentas.aspx.cs" Inherits="WebTransport.Consultas.cVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-success text-center">
                <div class="panel-heading">Consulta de Autobuses</div>

                <div class="panel-body col-md-offset-2">
                    <div class="form-horizontal col-md-12" role="form">

                        <%--CamposDropDownList--%>
                        <div class="form-group">
                            <label for="CamposCheckBox" class="col-md-4 col-xs-3 control-label input-sm">Buscar por: </label>
                            <div class="col-md-1 col-sm-3 col-xs-3">
                                <asp:CheckBox ID="CamposCheckBox" runat="server" class="input-sm"></asp:CheckBox>
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-3">
                                <asp:DropDownList ID="CamposDropDownList" runat="server" class="form-control input-sm btn-info">
                                    <asp:ListItem>VentaId</asp:ListItem>
                                    <asp:ListItem>ChoferId</asp:ListItem>
                                    <asp:ListItem>UsuarioId</asp:ListItem>
                                    <asp:ListItem>AutobusId</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-3 col-xs-3">
                                <asp:TextBox ID="CamposTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-3">
                                <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click"/>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-4">
                            </div>
                            <div class="col-md-1">
                            </div>
                        </div>

                        <%--Fecha--%>
                        <div class="form-group">
                            <label for="FechaCheckBox" class="col-md-4 col-xs-3 control-label input-sm">Fecha: </label>
                              <div class="col-md-1 col-sm-2 col-xs-3">
                                <asp:CheckBox ID="FechaCheckBox" runat="server" class="input-sm"></asp:CheckBox>
                            </div>
                            <div class="col-md-2 col-sm-2 col-md-offset-1 col-xs-3">
                                <asp:TextBox ID="FechaDesdeTextBox" runat="server" class="form-control input-sm" placeholder="Fecha desde"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-3 col-xs-3">
                                <asp:TextBox ID="FechaHastaTextBox" runat="server" class="form-control input-sm" placeholder="Fecha hasta"></asp:TextBox>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-4">
                            </div>
                            <div class="col-md-1">
                            </div>
                        </div>

                        <%--DatosGridView--%>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-2 col-sm-4 col-xs-2">
                                <asp:GridView ID="DatosGridView" runat="server" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="true">
                                    <Columns>
                                        <asp:HyperLinkField DataNavigateUrlFields="VentaId" DataNavigateUrlFormatString="~/Registros/rVentas.aspx?Id={0}" Text="Editar" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-md-1 col-sm-2 col-xs-4">
                            </div>
                            <div class="col-md-1">
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
