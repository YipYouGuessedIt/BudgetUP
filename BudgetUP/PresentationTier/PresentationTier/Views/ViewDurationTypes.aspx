<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDurationTypes.aspx.cs" Inherits="PresentationTier.Views.ViewDurationTypes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Duration Types</title>
   	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                     <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link " ><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px; margin-left:2px;"  src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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

        <div class="treeView">
            <a href="ProjectsPage.aspx">Projects</a> &gt <a href="ObjectivesPage.aspx"> Project Name</a> &gt <a href="ActivitiesPage.aspx"> Objective Name</a>
        </div>

        <div class="contentArea"><br />
            <h1 id="heaserarea" runat="server">Durtion Types</h1><hr />
            <!--<h2>Start and end date</h2>-->
            <div class="Incomesection">
                <div id="IncomeorExpenseSearch">
				    <asp:TextBox runat="server" autofocus="true" ID="searcher" CssClass="form-control" placeholder="Search Durations..." ></asp:TextBox>
			    <asp:Button ID="Button1" runat="server" CssClass="btn-info btn-lg btn" Text="Search" /><br />
			    </div>
                <div id="IncomeorExpenseAdd">
                    <br /><br />
                    <a href="Settings.aspx" class="btn btn-info btn-lg"  >Back</a><asp:Button runat="server"  class="btn btn-info btn-lg" Text="Add" ></asp:Button>
                    <br /><br />
                
                    <div runat="server" id="lister">
			            <div id="bl">
                            <h3>Durations</h3>
                            <asp:PlaceHolder ID="BusaryList" runat="server"></asp:PlaceHolder>	
                        </div>
                    </div>
			    </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
