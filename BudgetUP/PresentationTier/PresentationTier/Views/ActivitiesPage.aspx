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
                        <li> <a href="LoginPage.aspx">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>
        <div class="contentArea">
            <h1>Objective Name</h1>
            <h2>Milestone</h2>
            <div id="ActivitySearch">
				<input class="form-control" placeholder="Search Objectives..." /><br />
			</div>

            <div id="ActivityAdd">
				<a href="AddActivities1.aspx" class="btn btn-info btn-lg"  >Add new Activity</a><br /><br />
                <a href="ObjectivesPage.aspx" class="btn btn-info btn-lg"  >Back</a><br /><br />
			</div>

			<div id="ActivityList" class="list-group">
                <h3>Activity List</h3>
				<a class="list-group-item" href="IncomeandExpensesPage.aspx">Item one</a><br />
                <a class="list-group-item" href="IncomeandExpensesPage.aspx">Item two</a><br />
                <a class="list-group-item" href="IncomeandExpensesPage.aspx">Item Three</a><br />				
			</div>
        </div>
    </div>
    </form>
</body>
</html>
