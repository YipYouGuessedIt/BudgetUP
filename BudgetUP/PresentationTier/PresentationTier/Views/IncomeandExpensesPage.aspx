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
            <!--<h2>Start and end date</h2>-->
            <div class="Incomesection">
                <div id="IncomeorExpenseSearch">
                    <h2>Search</h2>
                    <p>type in here to filter the list of incomes and expenses for this Activity</p>
				    <asp:TextBox runat="server" autofocus="true" ID="searcher" CssClass="form-control" placeholder="Search Incomes and Expenses..." ></asp:TextBox>
			    <asp:Button ID="Button1" runat="server" CssClass="btn-info btn-lg btn" Text="Search" OnClick="Button1_Click" /><br />
			    </div>
                <p>Select a option from the drop down menu and click add to add a new income or expense</p>
                <div id="IncomeorExpenseAdd">
                
                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                        <asp:ListItem Value="1">Personel involvment(Expense)</asp:ListItem>
                        <asp:ListItem Value="2">Service Provider(Expense)</asp:ListItem>
                        <asp:ListItem Value="3">Operational Expense(Expense)</asp:ListItem>
                        <asp:ListItem Value="4">Equipment(Expense)</asp:ListItem>
                        <asp:ListItem Value="5">Travel (Expense)</asp:ListItem>
                        <asp:ListItem Value="8">Car Expense</asp:ListItem>
                        <asp:ListItem Value="6">Bursaries/Scholoarships(Income)</asp:ListItem>
                        <asp:ListItem Value="7">Donations(Income)</asp:ListItem>
                    </asp:DropDownList><br /><br />
				    <asp:Button runat="server"  class="btn btn-info btn-lg" Text="Add" OnClick="Unnamed1_Click" ></asp:Button>
                    <a href="ActivitiesPage.aspx" class="btn btn-info btn-lg"  >Back</a><br /><br />
                
			    </div>
            </div>
            <div runat="server" id="lister">
			    <div id="bl">
                    <h3>Bursary</h3>
                    <p>Below is a list of all the bursaries associated with the activity.Click to view</p>
                    <asp:PlaceHolder ID="BusaryList" runat="server"></asp:PlaceHolder>	
                </div>
                <div id="il">
                    <h3>Income</h3>
                    <p>Below is a list of all the Incomes associated with the activity.Click to view</p>
                    <asp:PlaceHolder ID="IncomeList" runat="server"></asp:PlaceHolder>	
                </div>
                 <div id="el">
                    <h3>Expense</h3>
                     <p>Below is a list of all the Expenses associated with the activity.Click to view</p>
                    <asp:PlaceHolder ID="Expenselist" runat="server"></asp:PlaceHolder>	
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
