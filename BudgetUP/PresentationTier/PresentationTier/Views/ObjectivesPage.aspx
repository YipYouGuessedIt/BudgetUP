<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjectivesPage.aspx.cs" Inherits="PresentationTier.Views.ObjectivesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Objective</title>
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
        
        <div id="tree" runat="server" class="treeView">
             
        </div>
           
            <a href="ProjectsPage.aspx" class="back btn-info btn-lg"  >Back</a>
        <div class="contentArea"><br />
            
            <h1 id="heaserarea" runat="server"></h1>
                        <hr />
            <div id="Div1" runat="server"></div>
            <hr />
            <div id="Div2" runat="server"></div>

            <div id="ObjectiveSearch" runat="server">
                <asp:TextBox runat="server" autofocus="true" placeholder="Search" ID="searcher" CssClass="form-control-static" OnTextChanged="Button1_Click"></asp:TextBox><asp:LinkButton ID="Button1" runat="server" CssClass="ser" Text="" OnClick="Button1_Click" ></asp:LinkButton>
			</div>

            <div id="ObjectiveAdd">
                <hr />
               <a href="EditProject.aspx" class="btn btn-info btn-lg"  >Edit Project</a>
				<a href="AddObjectives.aspx" class="btn btn-info btn-lg"  >Add new Objective</a>
                
                <br />
            </div>

			<div id="ObjectiveList" class="list-group" runat="server">
				
                <asp:PlaceHolder ID="ObjectiveLister" runat="server"></asp:PlaceHolder>			
			</div>
        </div>
    </form>
</body>
</html>
