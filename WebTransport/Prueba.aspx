<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="WebTransport.Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $("p").click(function () {
                $(this).hide();
            });
            
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:TextBox ID="TextBox" runat="server" CssClass="col-md-offset-4"></asp:TextBox>
    <asp:Button ID="Button" runat="server" Text="Presiona" OnClick="Button_Click" />
    <asp:Button ID="Button1" runat="server" Text="Limpiar" OnClick="Button1_Click" />
    <asp:Label ID="label" runat="server" ForeColor="Red"></asp:Label>
    <p class="col-md-offset-4">Melvin La para</p>
    <p class="col-md-offset-4">El jefe</p>

</asp:Content>
