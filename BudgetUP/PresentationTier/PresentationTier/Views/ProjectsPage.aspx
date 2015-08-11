<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsPage.aspx.cs" Inherits="PresentationTier.Views.ProjectsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>My Projects</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
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
    <div>
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

        <div class="contentArea">

            <div id="wecomemsg" runat="server"></div>
           
            <hr />
            <div id="Div1" runat="server"></div>
            <hr />

            <div id="ProjectSearch" runat="server" >
                		
                <asp:TextBox runat="server" autofocus="true" placeholder="Search" ID="searcher" CssClass="form-control-static"></asp:TextBox><asp:LinkButton ID="Button1" runat="server" CssClass="btn-info btn-lg btn gl" Text="" OnClick="Button1_Click" ></asp:LinkButton>
			</div>
            
            <div id="ProjectAdd">
                <br />
				<a href="AddProject.aspx" class="btna btn btn-info btn-lg pull-left "  >Add new project</a> <br /><br />
			</div>
            <br />
			<div id="ProjectList" class="list-group">
                <asp:PlaceHolder ID="projectList" runat="server"></asp:PlaceHolder>
			</div>
              <div id="AllProjects" class="list-group" runat="server">
                <h3>Other users projects</h3>
                  
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                  <br />
			</div>
        </div>
    </div>
    </form>
</body>
</html>
