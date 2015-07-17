<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivitiesPage.aspx.cs" Inherits="PresentationTier.Views.ActivitiesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Activities</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
    <        <div id="adminnav" runat="server">
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
        <div class="contentArea">
            <br />
            <h1 id="heaserarea" runat="server"></h1><hr />
            <div id="ActivitySearch">
                <hr />
                <h2>Search</h2>
                <p>type in here to filter the list of activities for this objective</p>
				<asp:TextBox runat="server"  ID="searcher" CssClass="form-control" placeholder="Search Activities..." ></asp:TextBox>
			    <asp:Button ID="Button1" runat="server" CssClass="btn-info btn-lg btn" Text="Search" OnClick="Button1_Click" /><br />
                <hr />
			</div>

            <div id="ActivityAdd">
                <p>Click on add to add a new activity or click back to go to the objectives page</p>
				<a href="AddActivities1.aspx" class="btn btn-info btn-lg"  >Add new Activity</a>
                <a href="ObjectivesPage.aspx" class="btn btn-info btn-lg"  >Back</a><br /><br />
			</div>

			<div id="n" class="list-group">
                <h3>Activity Lists</h3>
                <p>Bellow is a list for all the activities that are associated with the current objective</p>
                <asp:PlaceHolder ID="ActivityList" runat="server"></asp:PlaceHolder>

               <br />				
			</div>
            <div>
        </div>
     </div>
     </div>
    </form>
</body>
</html>
