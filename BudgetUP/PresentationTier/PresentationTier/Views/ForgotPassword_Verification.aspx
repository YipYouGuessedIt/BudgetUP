﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword_Verification.aspx.cs" Inherits="PresentationTier.Views.ForgotPassword_Verification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Login</title>
	    <link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">        

        <div id="myModal" class="modal fade"  role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Error has occured</h4>
      </div>
      <div class="modal-body">

        <div id="messageforerror" runat="server"></div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>


        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                    <a class="navbar-brand" href="#">BudgetUP</a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav">
                        <li><a href="Register.aspx">Register</a></li> 
                    </ul>
                </div>
            </div>
        </nav>
    <div>
            
    <div id="AddProjects" class="contentArea"><br />
        <h1>Password Recovery</h1><hr />
        <h3>Please enter the verification password that was sent to your email.Please change your password at your profile page.</h3>
            <asp:Label runat="server">Username</asp:Label><asp:TextBox runat="server" ID="UserEmail" type="email" name="User" autofocus CssClass="form-control" required></asp:TextBox><br />
                
        <asp:Label runat="server">Verification code</asp:Label><asp:TextBox runat="server" ID="veriCode" type="text" name="User" autofocus CssClass="form-control" required></asp:TextBox><br />
        <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Login" OnClick="Unnamed3_Click" />
            <br /><br />
    </div>
    
    </div>
    </form>
</body>
</html>
