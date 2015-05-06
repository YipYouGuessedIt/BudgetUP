<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PresentationTier.LoginPage" %>

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
            </div>
        </nav>
    <div>

             <div id="AddProjects" class="contentArea">
                <h1>Login to BudgetUP</h1><hr />
                <asp:Label runat="server">Username</asp:Label><asp:TextBox runat="server" ID="User" name="User" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">Password </asp:Label><asp:TextBox runat="server" ID="Pass" name="Pass" CssClass="form-control"></asp:TextBox><br />
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Login" OnClick="Unnamed3_Click" /><br /><br />
            </div>
    
    </div>
    </form>
</body>
</html>
