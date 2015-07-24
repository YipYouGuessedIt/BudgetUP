<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="PresentationTier.Styles.Settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Settings</title>
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
        			<div runat="server" id="errormsg">
                <div id="errorinner">
                    <asp:Label ID="messageforerror" runat="server" ></asp:Label>
                    <asp:Button runat="server" UseSubmitBehavior="false" CssClass="btn-info btn-lg btn" Text="OK" OnClick="Unnamed1_Click" Font-Size="10px" Height="33px" />
                </div>
            </div>
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
        <div id="AddActivity" class="contentArea"><br />
            <h1>Settings</h1>
            <hr />
            <h3> Users</h3>
            <hr />
            <a class="list-group-item" href="Register.aspx">Add Users
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ManageUsers.aspx">Edit Users
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h3> Incomes </h3>
            <hr />
            <h5> Bursaries </h5>
            <hr />
            <a class="list-group-item" href="AddBursaryType.aspx">Add Bursary Type
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ViewBursaryTypes.aspx">Edit Bursary Type
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h3> Expenses </h3>
            <hr />
            <h5> Operational Types </h5>
            <hr />

            <a class="list-group-item" href="AddOperationalType.aspx">Add Operational Type
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ViewOperationalType.aspx">Edit Operational Type
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h3> Other </h3>
            <hr />
            <h5> Faculties </h5>
            <hr />

            <a class="list-group-item" href="AddFaculty.aspx">Add Faculty
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ViewFaculties.aspx">Edit Faculty
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h5> Roles </h5>
            <hr />

            <a class="list-group-item" href="AddRole.aspx">Add Role
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ViewRoles.aspx">Edit Role
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h5> Domain </h5>
            <hr />

            <a class="list-group-item" href="AddDomains.aspx">Add Domain
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ViewDomain.aspx">Edit Domain
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h5> Post </h5>
            <hr />

            <a class="list-group-item" href="AddPost.aspx">Add Post
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ViewPost.aspx">Edit Post
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h5> Titles </h5>
            <hr />

            <a class="list-group-item" href="AddTitle.aspx">Add Titles
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            <a class="list-group-item" href="ViewTitles.aspx">Edit Titles
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>

            <hr />
            <h3> General</h3>
            <hr />

            <a class="list-group-item" href="GeneralSettings.aspx">General Settings
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
            </a>
            
            <br />
            <a href="ProjectsPage.aspx" class="btn btn-info btn-lg"  >Back</a>

        </div>
    </form>
</body>
</html>
