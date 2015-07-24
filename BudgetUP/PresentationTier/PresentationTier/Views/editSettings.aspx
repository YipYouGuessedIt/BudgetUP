﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editSettings.aspx.cs" Inherits="PresentationTier.Views.editSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Projec Settings</title>
   	<link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
        <link rel="stylesheet" href="../Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    			<div runat="server" id="errormsg">
                <div id="errorinner">
                    <asp:Label ID="messageforerror" runat="server" ></asp:Label>
                    <asp:Button runat="server" UseSubmitBehavior="false" CssClass="btn-info btn-lg btn" Text="OK" OnClick="Unnamed1_Click" Font-Size="10px" Height="33px" />
                </div>
            </div>
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
            <div id="AddActivity" class="contentArea"><br />
                <h1>Project Settings</h1><hr />
                		<p>Fill in the fields and click the edit button to edit the current settings for the project.Note that all required fields are marked with a *.</p>
		<hr/>
                <asp:Label runat="server">Escalation Rate*</asp:Label><asp:TextBox runat="server"  type="number"  ID="EscalationRate" step="0.001" required="true" name="name" CssClass="form-control"></asp:TextBox><br />
                <asp:Label runat="server">Subvention Rate*</asp:Label><asp:TextBox runat="server" type="number" ID="Subvention" step="0.001" required="true" name="name" CssClass="form-control"></asp:TextBox><br />
                
                <asp:Label runat="server">Indirect/instutional Cost*</asp:Label><asp:TextBox runat="server" type="number" step="0.001" ID="InstutionalCost" required="true" name="name" CssClass="form-control"></asp:TextBox><br />
            <a href="ObjectivesPage.aspx" class="btn btn-info btn-lg"  >Back</a>
            <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" OnClick="addBursaryType"/><br /><br />
        </div>
    </form>
</body>
</html>