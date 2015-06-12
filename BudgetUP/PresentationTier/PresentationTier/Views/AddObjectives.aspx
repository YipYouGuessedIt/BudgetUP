<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddObjectives.aspx.cs" Inherits="PresentationTier.Views.AddObjectives" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Objective Adder</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
    </head>
    <body>        

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
                        <li><a href="ProjectsPage.aspx">My Projects</a></li> 
                        <li> <a href="ProfilePage.aspx">Profile</a></li>                    
                        <li> <a href="ManageUsers.aspx">Manage Users</a></li>                    
                        <li> <a href="Settings.aspx">Settings</a></li>  
                        <li> <a href="LoginPage.aspx">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>

        <form id="form1" runat="server"><br />
            <div id="AddObjectives" class="contentArea">
                <h1>Project</h1><hr />
                <asp:Label runat="server">Objective Name</asp:Label><asp:TextBox runat="server" ID="ObjName" required name="ObjName" CssClass="form-control"></asp:TextBox><br />
                <!--<asp:Label runat="server">Milestone</asp:Label><asp:TextBox required runat="server" ID="milestone" name="milestone" CssClass="form-control"></asp:TextBox><br />-->
                <a href="ObjectivesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" OnClick="Unnamed3_Click" /><br /><br />
            </div>
        </form>

    </body>
</html>
