<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjectivesPage.aspx.cs" Inherits="PresentationTier.Views.ObjectivesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Objective</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
            <div id="adminnav" runat="server">
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
                        <li> <a id="logout" href="LoginPage.aspx" >Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>
        </div>
        <div id="normalnav" runat="server">        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                    <a class="navbar-brand" href="#">BudgetUP</a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar2">
                    <ul class="nav navbar-nav">
                        <li><a href="ProjectsPage.aspx">My Projects</a></li> 
                        <li> <a href="ProfilePage.aspx">Profile</a></li>                        
                        <li> <a href="Settings.aspx">Settings</a></li>  
                        <li> <a id="logout2" href="LoginPage.aspx">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav></div>
        <div id="tree" runat="server" class="treeView">
            
        </div>
        <div class="contentArea"><br />
            <h1 id="heaserarea" runat="server"></h1><hr />
            <div id="ObjectiveSearch">
                <h2>Search</h2>
                    <p>type in here to filter the list of objectives for the current project</p>
				
				<asp:TextBox runat="server" autofocus="true" ID="searcher" CssClass="form-control" placeholder="Search Objectives..." ></asp:TextBox>
			    <asp:Button ID="Button1" runat="server" CssClass="btn-info btn-lg btn" Text="Search" OnClick="Button1_Click" /><br />
			</div>

            <div id="ObjectiveAdd">
                <hr />
                <p>Click on add objectibe to add a new objective.Click on back to go to the project page.click on edit project to edit the project</p>
				<a href="AddObjectives.aspx" class="btn btn-info btn-lg"  >Add new Objective</a>
                <a href="ProjectsPage.aspx" class="btn btn-info btn-lg"  >Back</a><br /><br />
                <a href="EditProject.aspx" class="btn btn-info btn-lg"  >Edit Project</a><br /><br />
			    <hr />
            </div>

			<div id="ObjectiveList" class="list-group">
                <h3>Objective List</h3>
                
                    <p>Below is the list of objectives for this Project</p>
				
				<%--<a class="list-group-item" href="ActivitiesPage.aspx">Item one
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
				</a><br />
                <a class="list-group-item" href="ActivitiesPage.aspx">Item two
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
                </a><br />
                <a class="list-group-item" href="ActivitiesPage.aspx">Item Three(Admin Option to delete)
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
                </a><br />--%>	
                <asp:PlaceHolder ID="ObjectiveLister" runat="server"></asp:PlaceHolder>			
			</div>
        </div>
        
    </div>
    </form>
</body>
</html>
