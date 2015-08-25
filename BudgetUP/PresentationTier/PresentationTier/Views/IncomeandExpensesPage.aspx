<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncomeandExpensesPage.aspx.cs" Inherits="PresentationTier.Views.IncomeandExpensesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Income and Expenses</title>
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
             <div id="myModal" class="modal fade"  role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Error has occured</h4>
      </div>
      <div class="modal-body">

        <div id="messageforerror" runat="server"></div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
      </div>
    </div>

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
                     <asp:LinkButton runat="server" href="ActivitiesPage.aspx" CssClass=" navbar-brand btn btn-link " ><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px; margin-left:2px;"  src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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
                     <asp:LinkButton runat="server" href="ActivitiesPage.aspx" CssClass=" navbar-brand btn btn-link " ><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px; margin-left:2px;"  src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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
         <a href="ActivitiesPage.aspx" class="back btn btn-info btn-lg"  >Back</a>
        <div class="contentArea"><br />
            <h1 id="heaserarea" runat="server"></h1>
            <!--<h2>Start and end date</h2>-->
           
               <!-- <p>Select a option from the drop down menu and click add to add a new income or expense</p>
               --> <h1 id="h1" runat="server"></h1>
                        <hr />
            <div id="Div1" runat="server"></div>
            <hr />
            <div id="Div2" runat="server"></div>
             <a href="EditActivity.aspx" class="btn btn-info btn-lg"  >Edit activity</a>
            <hr />
            <div id="IncomeorExpenseAdd">
                
                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                        <asp:ListItem Value="1">Personel involvment(Expense)</asp:ListItem>
                        <asp:ListItem Value="2">Service Provider(Expense)</asp:ListItem>
                        <asp:ListItem Value="3">Operational Expense(Expense)</asp:ListItem>
                        <asp:ListItem Value="4">Equipment(Expense)</asp:ListItem>
                        <asp:ListItem Value="5">Travel (Expense)</asp:ListItem>
                        <asp:ListItem Value="8">Car (Expense)</asp:ListItem>
                        <asp:ListItem Value="6">Bursaries/Scholoarships</asp:ListItem>
                        <asp:ListItem Value="7">Donations(Income)</asp:ListItem>
                    </asp:DropDownList><br /><br />

				    <asp:Button runat="server" id="buttonadd" class="btn btn-info btn-lg" Text="Add a item" OnClick="Unnamed1_Click" ></asp:Button>
                   <div id="ObjectiveSearch"  runat="server" class="col-lg-2 pull-right serc">
                            <div class="input-group">
                                <asp:TextBox runat="server" autofocus="true" placeholder="Search" ID="searcher" CssClass=" form-control" OnTextChanged="Button1_Click"></asp:TextBox> 
                                <span class="input-group-btn">
                                    <asp:LinkButton runat="server" ID="LinkButton1" class="btn " style="background-color:white;" OnClick="Button1_Click"><span class='glyphicon glyphicon-search'></span></asp:LinkButton>
                                </span>
                            </div>
                        </div>
                   <br />
                
			    </div>
         
            <div runat="server" id="lister">
			    <div id="bl" runat="server">
                    <h3>Bursary</h3>
                    <p>Below is a list of all the bursaries associated with the activity.Click to view</p>
                    <asp:PlaceHolder ID="BusaryList" runat="server"></asp:PlaceHolder>	
                </div>
                <div id="il" runat="server">
                    <h3>Income</h3>
                    <p>Below is a list of all the Incomes associated with the activity.Click to view</p>
                    <asp:PlaceHolder ID="IncomeList" runat="server"></asp:PlaceHolder>	
                </div>
                 <div id="el" runat="server">
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
