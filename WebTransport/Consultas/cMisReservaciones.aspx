<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cMisReservaciones.aspx.cs" Inherits="WebTransport.Consultas.cMisReservaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-success text-center">
                <div class="panel-heading">Mis Reservaciones</div>

                <div class="panel-body col-md-offset-2">
                    <div class="form-horizontal col-md-12" role="form">
                        <%--DatosGridView--%>
                        <div class="form-group">
                            <div class="col-md-8 col-md-offset-2 col-sm-4 col-xs-2">
                                <asp:GridView ID="DatosGridView" runat="server" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="true">
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
