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
    <script src="../Scripts/NavigationJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ -->
        
         <!-- <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Small Modal</button>
        <!-- Modal -->

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
        <!-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ -->
            <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                   
                     
                    <img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px;"  src="../Images/logo.png"></img>
                    <a class="navbar-brand" href="#"> BudgetUP</a>
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
                <h1>Login to BudgetUP</h1><hr />
                <asp:Label runat="server" Font-Bold="True">Username</asp:Label><asp:TextBox runat="server" ID="UserEmail" type="Email" name="User" autofocus CssClass="form-control" required></asp:TextBox><br />
                <asp:Label runat="server" Font-Bold="True">Password </asp:Label><asp:TextBox runat="server" ID="Pass" name="Pass" type="password" CssClass="form-control" required></asp:TextBox><br />
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Login" OnClick="Unnamed3_Click" /><asp:HyperLink CssClass="frgt" runat="server" ToolTip="Recover lost password">Forgot Password?</asp:HyperLink>
                 <br /><br />
            </div>
    
    </div>
    </form>
</body>
</html>
