<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncomeandExpensesPage.aspx.cs" Inherits="PresentationTier.Views.IncomeandExpensesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Income and Expenses</title>
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
        <div class="contentArea"><br />
            <h1>Activity Name</h1>
            <h2>Start and end date</h2>
            <div class="Incomesection">
            <div id="IncomeorExpenseSearch">
				<input class="form-control" placeholder="Search Objectives..." />
                <br />
			</div>
            <div id="IncomeorExpenseAdd">
                
                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                    <asp:ListItem Value="1">Personel involvment(Expense)</asp:ListItem>
                    <asp:ListItem Value="2">Service Provider(Expense)</asp:ListItem>
                    <asp:ListItem Value="3">Operational Expense(Expense)</asp:ListItem>
                    <asp:ListItem Value="4">Equipment(Expense)</asp:ListItem>
                    <asp:ListItem Value="5">Travel</asp:ListItem>
                    <asp:ListItem Value="6">Bursaries/Scholoarships(Income)</asp:ListItem>
                    <asp:ListItem Value="7">Donations(Income)</asp:ListItem>
                </asp:DropDownList><br /><br />
				<asp:Button runat="server"  class="btn btn-info btn-lg" Text="Add" OnClick="Unnamed1_Click" ></asp:Button>
                <a href="ActivitiesPage.aspx" class="btn btn-info btn-lg"  >Back</a><br /><br />
                
			</div>
			<div id="IncomeList" class="list-group">
                <h3>Income</h3>
				<a class="list-group-item" href="IncomeandExpensesPage.aspx">Item one
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
				</a><br />			
			</div>
            <div id="ExpenseList" class="list-group"><br />
                <h3>Expense</h3><hr />
				<a class="list-group-item" href="#">Item one 
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
				</a><br />
                <a class="list-group-item" href="#">Item two
                    <span class="glyphicon glyphicon-menu-right pull-right" aria-hidden="true"></span>
                </a><br />
                <a class="list-group-item" href="#">Item three (Admin Option to delete)
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
                </a><br />	
                <a class="list-group-item" href="#">Item four (Admin Option to delete)
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
                </a><br />
                <a class="list-group-item" href="#">Item five (Admin Option to delete)
                    <span class="glyphicon glyphicon-remove-sign pull-right" hidden="hidden" aria-hidden="true"></span>
                </a><br />				
			</div>
        </div>
    </div>
    </form>
</body>
</html>
