﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBursary.aspx.cs" Inherits="PresentationTier.Views.ViewBursary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <h1>Bursary</h1><hr />
                <asp:Label runat="server">Number of Bursaries</asp:Label><asp:TextBox runat="server" ID="numofburs" required name="numofburs" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">Type of bursary</asp:Label>                
                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                    <asp:ListItem Value="1">Master</asp:ListItem>
                    <asp:ListItem Value="2">Doctoral</asp:ListItem>
                    <asp:ListItem Value="3">Post-doctoral fellow</asp:ListItem>
                </asp:DropDownList><br /><br />
                <asp:Label runat="server">Notes</asp:Label><asp:TextBox TextMode="multiline" Columns="50" Rows="5"  required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
                <a href="IncomeandExpensesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" /><br /><br />
            </div>
    </form>
</body>
</html>