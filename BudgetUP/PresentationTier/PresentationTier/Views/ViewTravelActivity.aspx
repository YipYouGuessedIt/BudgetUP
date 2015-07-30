<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTravelActivity.aspx.cs" Inherits="PresentationTier.Views.ViewTravelActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Travel</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
    </head>
    <body>        

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

        <form id="form1" runat="server">
            			<div runat="server" id="errormsg">
                <div id="errorinner">
                    <asp:Label ID="messageforerror" runat="server" ></asp:Label>
                    <asp:Button runat="server" UseSubmitBehavior="false" CssClass="btn-info btn-lg btn" Text="OK" OnClick="Unnamed1_Click" Font-Size="10px" Height="33px" />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
            </div>
            <div id="Add" class="contentArea"><br />
                <h1>Travel Expenses</h1>
                <hr />

                <h3>General</h3>
                <hr />
                <p>Fill in the fields and click the save button to edit the current travel expense.Note that all required fields are marked with a *.</p>
		<hr/>
                <br />
                                <asp:Label ID="Label1" runat="server" Text="Name of Traveler"></asp:Label>
                <asp:TextBox runat="server" ID="TextBox1" required type="number" name="numofdays" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Number of days*"></asp:Label>
                <asp:TextBox runat="server" ID="numofdays" required type="number" name="numofdays" CssClass="form-control"></asp:TextBox>
                <br />

                <asp:Label runat="server">Estimated date of depature* </asp:Label>
                <asp:TextBox required type="date" runat="server" ID="sdate" name="sdate" CssClass="form-control"></asp:TextBox>
                <br />
                
                <asp:Label runat="server" ID="Label3">Destination(Country,Capital)*</asp:Label>
                <asp:TextBox required type="text" runat="server" ID="destination" name="sdate" CssClass="form-control"></asp:TextBox><br />
                
                <asp:Label runat="server" ID="Label10">Departure Location(Country,Capital)*</asp:Label>
                <asp:TextBox required runat="server" ID="destination0" name="sdate" CssClass="form-control"></asp:TextBox>
                
                
                <h3>Visa</h3>
                <hr />
                <asp:DropDownList required runat="server" ID="fleet4" CssClass="form-control" OnInit="oppType_Init">
                    <asp:ListItem Value="0">Yes</asp:ListItem>
                    <asp:ListItem Value="1">No</asp:ListItem>
                </asp:DropDownList>
                <br />
                
                <h3>Gautrain</h3>
                <hr />
                <asp:DropDownList required runat="server" ID="fleet3" CssClass="form-control" OnInit="oppType_Init">
                    <asp:ListItem Value="0">Yes</asp:ListItem>
                    <asp:ListItem Value="1">No</asp:ListItem>
                </asp:DropDownList>
                <br />
                
                <h3>Per diem</h3>
                <hr />
                <asp:DropDownList required runat="server" ID="fleet2" CssClass="form-control" OnInit="oppType_Init">
                    <asp:ListItem Value="0">Yes</asp:ListItem>
                    <asp:ListItem Value="1">No</asp:ListItem>
                </asp:DropDownList>
                <br />                

                <h3>Airlines</h3>
                <hr />
                <asp:DropDownList required runat="server" ID="fleet11" CssClass="form-control" OnInit="oppType_Init">
                    <asp:ListItem Value="0">Yes</asp:ListItem>
                    <asp:ListItem Value="1">No</asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                </asp:UpdatePanel>

                <asp:Label runat="server">Return Ticket </asp:Label>
                <asp:DropDownList class="form-control" ID="returnTicket" runat="server">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
                <br />

                <h3>Accommodation</h3>
                <hr />
                <asp:DropDownList required runat="server" ID="fleet0" CssClass="form-control" OnInit="oppType_Init">
                    <asp:ListItem Value="0">Yes</asp:ListItem>
                    <asp:ListItem Value="1">No</asp:ListItem>
                </asp:DropDownList>
                <br />
               
                <h3>Notes</h3>
                <hr />
                <asp:TextBox TextMode="multiline" Columns="50" Rows="5"  required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
                <a href="IncomeandExpensesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" OnClick="Unnamed4_Click" />
                <asp:Button ID="Button1" runat="server" CssClass="btn-info btn-lg btn" OnClick="Button1_Click" Text="Remove" />
                <br /><br />
            </div>
        </form>

    </body>
</html>

