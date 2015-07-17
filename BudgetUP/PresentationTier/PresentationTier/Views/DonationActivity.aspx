<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DonationActivity.aspx.cs" Inherits="PresentationTier.Views.DonationActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Donation</title>
    	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
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
            <div id="Add" class="contentArea"><br />
                <h1>Donation</h1><hr />
                		<p>Fill in the fields and click the add button to add a new Donation.Note that all required fields are marked with a *.</p>
		<hr/>
                <asp:Label runat="server">Name of doner/funding agency</asp:Label><asp:TextBox runat="server" ID="name" required name="name" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">Value(in rands)*</asp:Label><asp:TextBox required runat="server" ID="amount" name="amount" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">Notes*</asp:Label><asp:TextBox TextMode="multiline" Columns="50" Rows="5"  required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
                <a href="IncomeandExpensesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" OnClick="Unnamed4_Click" /><br /><br />
            </div>
        </form>

    </body>
</html>

