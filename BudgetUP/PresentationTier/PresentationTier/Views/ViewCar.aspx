<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCar.aspx.cs" Inherits="PresentationTier.Views.ViewCar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Edit Car expense</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/car.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
    <body>
          <form id="form1" runat="server">
        <div id="adminnav" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                     <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link " ><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px; margin-left:2px;"  src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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
                     <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link " ><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px; margin-left:2px;"  src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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

      
  <div id="myModal2" class="modal fade"  role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <h4 class="modal-title">Confirm Delete</h4>
      </div>
      <div class="modal-body">

        <div id="Div1" runat="server">Are you sure you want to delete the activity? All items under the activity will also be removed.</div>
      </div>
      <div class="modal-footer">
           <asp:Button runat="server" CssClass="btn-info btn" Text="Delete" OnClick="Button1_Click" ID="Button2" />
        <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>
            
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
                    <div id="tree" runat="server" class="treeView">
             
                    </div>
                            <a href="IncomeandExpensesPage.aspx" class=" back btn btn-info btn-lg"  >Back</a>
           
            <div id="Add" class="contentArea"><br />
                <h1>Car Expense</h1><hr />
                		<p>Fill in the fields and click the add button to edit the current car expense.Note that all required fields are marked with a *.</p>
		<hr/>
                 <asp:Label runat="server" ID="Label1" Font-Bold="True">Type of rental*</asp:Label><asp:DropDownList required runat="server" ID="rental" CssClass="form-control" >
                    <asp:ListItem Value="1">UP Fleet</asp:ListItem>
                    <asp:ListItem Value="2">External Rental</asp:ListItem>
                    <asp:ListItem Value="3">Feul claim</asp:ListItem>
                </asp:DropDownList><br />
                            <div id="days" runat="server">   <asp:Label   Font-Bold="True">     Days*</asp:Label><asp:TextBox min="0" required type="number" runat="server" ID="quantity"  name="quantity" CssClass="form-control">0</asp:TextBox><br /></div>
                <div id="kml" runat="server"><asp:Label   Font-Bold="True"> Kilometers*</asp:Label><asp:TextBox required min="0" type="number" runat="server" ID="TextBox1"  name="quantity" CssClass="form-control">0</asp:TextBox><br /></div>

                <asp:Label runat="server" ID="Label2" Font-Bold="True">Notes*</asp:Label><asp:TextBox TextMode="multiline" Columns="50" Rows="5"  required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
                <a href="IncomeandExpensesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" OnClick="Unnamed5_Click" />
                                <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal2">Delete</button>
                <br /><br />
            </div>
        </form>

    </body>
</html>
