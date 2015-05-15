﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expenses.aspx.cs" Inherits="PresentationTier.Views.Expenses" %>

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
                        <li> <a href="Settings.aspx">Settings</a></li>  
                        <li> <a href="LoginPage.aspx">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>
        <div class="contentArea">
            <br />
            <h1>Expenses</h1><hr />

            <div id="ProjectSearch">
				<input class="form-control" placeholder="Search Users..." /><br />
			</div>

            <div id="ActivityAdd">
				<a href="AddExpense.aspx" class="btn btn-info btn-lg"  >Add Expense</a>
                <a href="ObjectivesPage.aspx" class="btn btn-info btn-lg"  >Back</a><br /><br />
			</div>

			<div id="ProjectList" class="list-group">
                <h3>Expense List</h3>
				<a class="list-group-item" href="#">Expense One
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
				</a><br />
                <a class="list-group-item" href="#">Expense Two
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
                </a><br />
                <a class="list-group-item" href="#">Expense Three
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
                </a><br />				
			</div>
        </div>
    </div>
    </form>
</body>
</html>