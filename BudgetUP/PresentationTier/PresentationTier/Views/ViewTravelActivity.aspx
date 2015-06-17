<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTravelActivity.aspx.cs" Inherits="PresentationTier.Views.ViewTravelActivity" %>

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
            <div id="Add" class="contentArea"><br />
                <h1>Travel Expenses</h1>
                <hr />

                <h3>General</h3>
                <hr />

                <asp:Label ID="Label1" runat="server" Text="">Number of travelers</asp:Label>
                <asp:TextBox runat="server" ID="numoftrav" type="number" required name="numoftrav" CssClass="form-control"></asp:TextBox>
                <br />

                <asp:Label ID="Label2" runat="server" Text="Number of days"></asp:Label>
                <asp:TextBox runat="server" ID="numofdays" required type="number" name="numofdays" CssClass="form-control"></asp:TextBox>
                <br />

                <asp:Label runat="server">Estimated date of depature </asp:Label>
                <asp:TextBox required type="date" runat="server" ID="sdate" name="sdate" CssClass="form-control"></asp:TextBox>
                <br />
                
                <asp:Label runat="server" ID="Label3">Destination</asp:Label>
                <asp:TextBox required type="date" runat="server" ID="destination" name="sdate" CssClass="form-control"></asp:TextBox><br />
                <br />
                
                
                <h3>Visa</h3>
                <hr />
                <asp:Label runat="server" ID="Label4">Visa Amount</asp:Label>
                <asp:TextBox required type="number" runat="server" ID="visaAmount" name="sdate" CssClass="form-control" value="0"></asp:TextBox>
                <br />
                
                <h3>Gautrain</h3>
                <hr />
                <asp:Label runat="server" ID="Label5">Gautrain Amount</asp:Label>
                <asp:TextBox required type="number" runat="server" ID="gautrainAmount" name="sdate" CssClass="form-control" value="0"></asp:TextBox>
                <br />
                
                <h3>Cars</h3>
                <hr />
                <asp:Label runat="server" ID="Label6">Car Expense Amount</asp:Label>
                <asp:TextBox required type="number" runat="server" ID="CarAmount" name="sdate" CssClass="form-control" value="0"></asp:TextBox>
                <br />
                
                <asp:Label runat="server">University of Pretoria Fleet </asp:Label>
                <asp:DropDownList class="form-control" ID="UPFleet" runat="server">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
                <br />
                
                <h3>Allowances</h3>
                <hr />
                <asp:Label runat="server" ID="Label7">Allowances Amount</asp:Label>
                <asp:TextBox required type="number" runat="server" ID="AllowanceAmount" name="sdate" CssClass="form-control" value="0"></asp:TextBox>
                <br />                

                <h3>Airlines</h3>
                <hr />
                <asp:Label runat="server" ID="Label8">Airline Expense Amount</asp:Label>
                <asp:TextBox required type="number" runat="server" ID="AirlineAmount" name="sdate" CssClass="form-control" value="0"></asp:TextBox>
                <br />

                <asp:Label runat="server">Return Ticket </asp:Label>
                <asp:DropDownList class="form-control" ID="returnTicket" runat="server">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
                <br />

                <h3>Accommodation</h3>
                <hr />
                <asp:Label runat="server" ID="Label9">Accommodation Amount</asp:Label>
                <asp:TextBox required type="number" runat="server" ID="AccommodationAmount" name="sdate" CssClass="form-control" value="0"></asp:TextBox>
                <br />
               
                <h3>Notes</h3>
                <hr />
                <asp:TextBox TextMode="multiline" Columns="50" Rows="5"  required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
                <a href="IncomeandExpensesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Edit" OnClick="Unnamed4_Click" /><br /><br />
            </div>
        </form>

    </body>
</html>

