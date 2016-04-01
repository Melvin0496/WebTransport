<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebTransport.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar | WebTransport</title>
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/toastr.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="../../plugins/iCheck/square/blue.css" />
    <script src="../Script/jquery-2.2.0.min.js"></script>
    <script src="../Script/toastr.min.js"></script>
</head>
<body class="hold-transition register-page">
    <div class="register-box">
        <div class="register-logo">
            <a href="Default.aspx"><b>Web</b>Transport</a>
        </div>
        <form id="form" runat="server">

            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">


                    <%--Nombres--%>
                    <div class="form-group">
                        <label for="NombresTextBox" class="col-md-3 control-label input-sm">Nombres: </label>
                        <div class="col-md-9">
                            <asp:TextBox ID="NombresTextBox" runat="server" Class="form-control input-sm" placeholder="Introduce tu Nombre aquí"></asp:TextBox>


                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>

                    <%--Apellidos--%>
                    <div class="form-group">
                        <label for="ApelllidosTextBox" class="col-md-3 control-label input-sm">Apellidos</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="ApellidosTextBox" runat="server" Class="form-control input-sm" placeholder="Introduce tu Apellido aquí"></asp:TextBox>


                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>

                    <%--Email--%>
                    <div class="form-group">
                        <label for="EmailTextBox" class="col-md-3 control-label input-sm">Email:</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="EmailTextBox" runat="server" Class="form-control input-sm" type="email" placeholder="Example@webtransport.com"></asp:TextBox>


                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>

                    <%--Password--%>
                    <div class="form-group">
                        <label for="PasswordTextBox" class="col-md-3 control-label input-sm">Password:</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="PasswordTextBox" runat="server" Class="form-control input-sm" type="password" placeholder="******"></asp:TextBox>


                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>

                    <%--Confirm Password--%>
                    <div class="form-group">
                        <label for="ComfirmPasswordTextBox" class="col-md-3 control-label input-sm">Comfirm Password:</label>
                        <div class="col-md-9">
                            <asp:TextBox ID="ComfirmPasswordTextBox" runat="server" Class="form-control input-sm" type="password" placeholder="******"></asp:TextBox>


                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>


                </div>
            </div>


          

                <asp:Button Text="Registrar  " class="btn btn-primary  col-md-10 col-md-offset-1" runat="server" ID="GuardarButton" OnClick="GuardarButton_Click" /><br /><br />
                <asp:Button Text="Cancelar" class="btn btn-danger  col-md-10 col-md-offset-1 " runat="server" ID="CancelarButton" OnClick="CancelarButton_Click1" />

           
        </form>
    </div>

</body>
</html>
