<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="WebTransport.Registros.rVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary text-center">

        <div class="panel-heading">Informacion venta</div>
        <div class="panel-body col-md-offset-2">

            <div>

                <%--VentaId--%>

                <div class="form-group">

                    <label for="VentaIdTextBox" class="col-md-1 control-label input-sm">VentaId: </label>

                    <div class="col-md-2 col-sm-2 col-xs-4">

                        <asp:TextBox ID="VentaIdTextBox" runat="server" class="form-control input-sm" type="number"></asp:TextBox>

                    </div>

                    <div class="col-md-1 col-sm-2 col-xs-4">

                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-info btn-md" Text="Buscar" OnClick="BuscarButton_Click" />

                    </div>

                </div>


                <%--Fecha--%>

                <div class="form-group">

                    <label for="FechaTextBox" class="col-md-1 control-label input-sm">Fecha: </label>

                    <div class="col-md-2">

                        <asp:TextBox ID="FechaTextBox" runat="server" Class="form-control input-sm" type="date"></asp:TextBox>

                    </div>

                </div>


                <%--UsuarioId--%>

                <div class="form-group">

                    <label for="UsuarioIdDropDownList" class="col-md-1 control-label input-sm">UsuarioId: </label>

                    <div class="col-md-2">

                        <asp:DropDownList ID="UsuarioIdDropDownList" runat="server" Class="form-control input-sm"></asp:DropDownList>

                    </div>

                </div>


                <%--AutobusId--%>

                <div class="form-group">

                    <label for="AutobusIdDropDownList" class="col-md-7 col-md-pull-3 control-label input-sm">AutobusId: </label>

                    <div class="col-md-2 col-md-pull-6">

                        <asp:DropDownList ID="AutobusIdDropDownList" runat="server" Class="form-control input-sm">
                        </asp:DropDownList>

                    </div>

                </div>


                <%--ChoferId--%>

                <div class="form-group">

                    <label for="ChoferIdDropDownList" class="col-md-1 col-md-pull-5 control-label input-sm">ChoferId: </label>

                    <div class="col-md-2 col-md-pull-5">

                        <asp:DropDownList ID="ChoferIdDropDownList" runat="server" Class="form-control input-sm">
                        </asp:DropDownList>

                    </div>

                </div>



            </div>

        </div>



        <div class="panel-heading panel panel-info">Envios</div>



        <div class="panel-body col-md-offset-2">

            <div>



                <asp:UpdatePanel runat="server">

                    <ContentTemplate>
                        <%--Descripcion--%>

                        <div class="form-group">

                            <label for="DescripcionTextBox" class="col-md-1 control-label input-sm">Descripcion: </label>

                            <div class="col-md-2">

                                <asp:TextBox ID="DescripcionTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>

                            </div>

                        </div>


                        <%--TipoEnvio--%>

                        <div class="form-group">

                            <label for="TipoEnvioTextBox" class="col-md-1 control-label input-sm">Tipo Envio: </label>

                            <div class="col-md-2">

                                <asp:DropDownList ID="TipoEnvioDropDownList" runat="server" Class="form-control input-sm"></asp:DropDownList>

                            </div>

                        </div>


                        <%--Precio--%>

                        <div class="form-group">

                            <label for="PrecioTextBox" class="col-md-1 control-label input-sm">Precio: </label>

                            <div class="col-md-2">

                                <asp:TextBox ID="PrecioTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>

                            </div>

                        </div>


                        <%--Emisor--%>

                        <div class="form-group">

                            <label for="EmisorTextBox" class="col-md-1 control-label input-sm">Emisor: </label>

                            <div class="col-md-2">

                                <asp:TextBox ID="EmisorTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>

                            </div>

                        </div>


                        <%--Receptor--%>

                        <div class="form-group">

                            <label for="ReceptorTextBox" class="col-md-5 col-md-pull-2 control-label input-sm">Receptor: </label>
                            <div class="col-md-2 col-md-pull-4 col-sm-2 col-xs-4">


                                <asp:TextBox ID="ReceptorTextBox" runat="server" class="form-control input-sm"></asp:TextBox>


                            </div>

                            <div class="col-md-1 col-md-pull-4 col-sm-2 col-xs-4">

                                <asp:Button ID="AgregarButton" runat="server" class="btn btn-info btn-md" Text="Agregar" OnClick="AgregarButton_Click" />

                            </div>

                            <div class="col-md-1 col-sm-2 col-xs-4">
                            </div>

                        </div>


                        <%--EnviosGridview--%>

                        <div class="form-group">

                            <label for="EnviosGridView" class="col-md-1 col-md-pull-5 control-label input-sm">Envios: </label>

                            <div class="col-md-2 col-md-pull-5">

                                <asp:GridView ID="EnviosGridView" runat="server" Class="table table-bordered table-hover table-striped" OnRowDeleting="EnviosGridView_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-info btn-sm" CommandName="Delete" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                            </div>

                        </div>


                        <%--Total--%>

                        <div class="form-group">

                            <label for="TotalLabel" class="col-md-3 col-md-pull-1 control-label input-sm">Total: </label>

                            <div class="col-md-2 col-md-pull-3">

                                <asp:Label ID="TotalLabel" runat="server" Class="control-label input-sm"></asp:Label>

                            </div>

                            <div class="col-md-1">
                            </div>

                        </div>
                    </ContentTemplate>

                </asp:UpdatePanel>

            </div>

        </div>



        <div class="panel-heading panel panel-info">Pasajeros</div>



        <div class="panel-body col-md-offset-2">

            <asp:UpdatePanel runat="server">

                <ContentTemplate>
                    <%--Nombres--%>

                    <div class="form-group">

                        <label for="NombresDropDownList" class="col-md-5 col-md-pull-2 control-label input-sm">Nombres: </label>

                        <div class="col-md-2 col-md-pull-4 col-sm-2 col-xs-4">

                            <asp:DropDownList ID="NombresDropDownList" runat="server" class="form-control input-sm" ReadOnly="true"></asp:DropDownList>

                        </div>

                        <div class="col-md-1 col-md-pull-4 col-sm-2 col-xs-4">

                            <asp:Button ID="AgregarPasajerosButton" runat="server" class="btn btn-info btn-md" Text="Agregar" />

                        </div>
                    </div>
                    <%--PasajeroGridview--%>

                    <div class="form-group">
                        <label for="PasajerosGridView" class="col-md-1 col-md-pull-3 control-label input-sm">Pasajeros: </label>
                        <div class="col-md-2 col-md-pull-3">
                            <asp:GridView ID="PasajerosGridView" runat="server" Class="table">
                            </asp:GridView>
                        </div>
                    </div>

                    <%--Total--%>
                    <div class="form-group">
                        <label for="TotalLabel" class="col-md-3 col-md-pull-1 control-label input-sm">Total: </label>
                        <div class="col-md-2">
                            <asp:Label ID="Label1" runat="server" Class="control-label input-sm"></asp:Label>
                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
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
