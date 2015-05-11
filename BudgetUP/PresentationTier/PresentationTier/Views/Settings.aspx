﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="PresentationTier.Styles.Settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Settings</title>
   	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
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
            <div id="AddActivity" class="contentArea">
                <h1>Profile</h1><hr />
                <asp:Label runat="server">Annual Increase</asp:Label><asp:TextBox runat="server" ID="AnnualIncrease" required="true" name="name" CssClass="form-control">6.5</asp:TextBox><br />
                <asp:Label runat="server">Indirect/instutional Cost</asp:Label><asp:TextBox runat="server" ID="TextBox1" required="true" name="name" CssClass="form-control">10</asp:TextBox><br />
            <a href="ProjectsPage.aspx" class="btn btn-info btn-lg"  >Back</a>
            <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" /><br /><br />
        </div>
    </form>
</body>
</html>