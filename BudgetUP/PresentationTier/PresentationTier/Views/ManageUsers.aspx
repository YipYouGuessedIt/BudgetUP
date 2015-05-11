﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="PresentationTier.Views.ManageUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>My Projects</title>
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
                        <li> <a href="Setting.aspx">Settings</a></li>  
                        <li> <a href="LoginPage.aspx">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>
        <div class="contentArea">
            <h1>Project</h1>

            <div id="ProjectSearch">
				<input class="form-control" placeholder="Search Users..." /><br />
			</div>

            <div id="admin">
				<asp:Button name="enableAdmin" runat="server" CssClass="btn-info btn-lg btn" Text="Edit (AC)" /><br />
			</div>

			<div id="ProjectList" class="list-group">
                <h3>Project List</h3>
				<a class="list-group-item" href="ObjectivesPage.aspx">David Tennent
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
				</a><br />
                <a class="list-group-item" href="ObjectivesPage.aspx">Matt Smith
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
                </a><br />
                <a class="list-group-item" href="ObjectivesPage.aspx">Jame Cameron
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
                </a><br />				
			</div>
        </div>
    </div>
    </form>
</body>
</html>
