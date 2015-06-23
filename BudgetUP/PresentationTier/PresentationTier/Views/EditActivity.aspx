<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditActivity.aspx.cs" Inherits="PresentationTier.Views.EditActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Activities Viewer</title>
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
                        <li> <a href="LoginPage.aspx">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>

        <form id="form1" runat="server">
            <div id="AddActivity" class="contentArea">
                <br />
                <h1>Add Activity</h1><hr />
                <asp:Label runat="server">Activity Name</asp:Label><asp:TextBox runat="server" ID="ActName" required name="ActName" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">Start Date </asp:Label><asp:TextBox required type="date" runat="server" ID="sdate" name="sdate" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">End Date </asp:Label><asp:TextBox required type="date" runat="server" ID="edate" name="edate" CssClass="form-control"></asp:TextBox><br />
                <a href="ActivitiesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Edit" OnClick="Unnamed4_Click" />
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Remove" OnClick="Unnamed4_Click2" ID="Button1" /><br /><br />
            </div>
        </form>

    </body>
</html>
