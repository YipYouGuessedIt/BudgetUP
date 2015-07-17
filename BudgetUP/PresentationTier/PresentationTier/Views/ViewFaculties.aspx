﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFaculties.aspx.cs" Inherits="PresentationTier.Views.ViewFaculties" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Operational Types</title>
   	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
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


        <div class="contentArea"><br />
            <h1 id="heaserarea" runat="server">Faculties</h1><hr />
            <!--<h2>Start and end date</h2>-->
            <div class="Incomesection">
                <div id="IncomeorExpenseSearch">
                    		<h2>Search</h2>
                    <p>type in here to filter the list of faculties</p>
				    <asp:TextBox runat="server" autofocus="true" ID="searcher" CssClass="form-control" placeholder="Search Faculties..." ></asp:TextBox>
			        <asp:Button ID="Button1" runat="server" CssClass="btn-info btn-lg btn" Text="Search" /><br />
			    </div>

                <div id="IncomeorExpenseAdd">
                    <br /><br />
                    <a href="Settings.aspx" class="btn btn-info btn-lg"  >Back</a><asp:Button runat="server"  class="btn btn-info btn-lg" Text="Add" OnClick="Unnamed1_Click" ></asp:Button>
                    <br /><br />
                
                    <div runat="server" id="lister">
			            <div id="bl">
                            <h3>Faculty</h3>
                            <p>Below are a list of the faculties on the system</p>
                            <asp:PlaceHolder ID="BursaryList" runat="server"></asp:PlaceHolder>	
                        </div>
                    </div>
			    </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

