<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PruebaDeMelvin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | WebTransport</title>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- Bootstrap Core CSS -->
    <link href="/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
   <link href="/Content/metisMenu.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="/Content/sb-admin-2.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
    
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" placeholder="E-mail" type="email" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control" placeholder="Password" type="password" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="RemenberMeLabel" runat="server">
                                        <asp:CheckBox ID="RecuerdameCheckBox" runat="server" type="checkbox" /> Remember Me?
                                    </asp:Label>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->
                                <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-lg btn-success btn-block" Text="Login" OnClick="LoginButton_Click" />
                                <asp:LinkButton ID="RegistrarButton" runat="server" CssClass="btn btn-link btn-block" Text="Registrar" OnClick="RegistrarButton_Click" />
                                <asp:Label ID="MansajeErrorLabel" runat="server" />
                            </fieldset>
         
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <!-- jQuery -->
    <script src="/Script/jquery-2.2.0.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="/Bootstrap/js/bootstrap.min.js"></script>

</body>
</html>
