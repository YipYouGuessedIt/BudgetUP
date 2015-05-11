﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personelactivity.aspx.cs" Inherits="PresentationTier.Views.Personelactivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Personel</title>
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
                        <li> <a href="Setting.aspx">Settings</a></li>  
                        <li> <a href="LoginPage.aspx">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>

        <form id="form1" runat="server">
            <div id="Add" class="contentArea">
                <h1>Personel Involvment</h1>
                <hr />
                <asp:Label runat="server">Select Post level </asp:Label>
                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                    <asp:ListItem Value="1">Admin</asp:ListItem>
                    <asp:ListItem Value="2">Lecturer</asp:ListItem>
                </asp:DropDownList><br />
                <asp:Label ID="Label1" runat="server" Text="">Duration of involvement</asp:Label>
                <asp:TextBox runat="server" ID="numofdays" type="number" required name="numofdays" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label runat="server">Subventilation levy </asp:Label>
               <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="2">No</asp:ListItem>
                   <asp:ListItem Value="2">I am not sure</asp:ListItem>
                </asp:DropDownList><br /><br />
                
                <asp:Label runat="server">Note</asp:Label><asp:TextBox required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
                
                <a href="IncomeandExpensesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" /><br /><br />
            </div>
        </form>

    </body>
</html>