<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelActivity.aspx.cs" Inherits="PresentationTier.Views.TravelActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Travel</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
    </head>
    <body>        

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

        <form id="form1" runat="server">
            <div id="Add" class="contentArea">
                <h1>Travel</h1>
                <hr />
                <asp:Label ID="Label1" runat="server" Text="">Number of travellers</asp:Label>
                <asp:TextBox runat="server" ID="numoftrav" type="number" required name="numoftrav" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="">Number of travellers</asp:Label>
                <asp:TextBox runat="server" ID="numofdays" required type="number" name="numofdays" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label runat="server">Estimated date of depature </asp:Label><asp:TextBox required type="date" runat="server" ID="sdate" name="sdate" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">Airline tickets Required </asp:Label>
                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">No</asp:ListItem>
                </asp:DropDownList><br />
                                <asp:Label runat="server">Acomidation Required </asp:Label>
                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">No</asp:ListItem>
                </asp:DropDownList><br />
                                <asp:Label runat="server">Car Rental Required </asp:Label>
                <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                    <asp:ListItem Value="1">No</asp:ListItem>
                    <asp:ListItem Value="2">Yes from UP fleet</asp:ListItem>
                    <asp:ListItem Value="3">Yes from a car rental company</asp:ListItem>
                </asp:DropDownList><br />
                                <asp:Label runat="server">Gautrain Required </asp:Label>
                <asp:DropDownList class="form-control" ID="DropDownList4" runat="server">
                    <asp:ListItem Value="1">No</asp:ListItem>
                    <asp:ListItem Value="2">Yes,return ticket</asp:ListItem>
                    <asp:ListItem Value="3">Yes,single ticket</asp:ListItem>
                </asp:DropDownList><br />
                                <asp:Label runat="server">Visa Required </asp:Label>
                <asp:DropDownList class="form-control" ID="DropDownList5" runat="server">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">No</asp:ListItem>
                </asp:DropDownList><br />
                <asp:Label runat="server">Notes</asp:Label><asp:TextBox TextMode="multiline" Columns="50" Rows="5"  required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
                <a href="IncomeandExpensesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" /><br /><br />
            </div>
        </form>

    </body>
</html>

