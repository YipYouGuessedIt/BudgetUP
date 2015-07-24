﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOperationalType.aspx.cs" Inherits="PresentationTier.Views.AddOperationalType" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Operational Type</title>
    <link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
    <link rel="stylesheet" href="../Styles/Global.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
                </div>
            </div>
        <div id="Add" class="contentArea">
            <br />
            <h1>Add Operational Type</h1><hr />
            <p>Fill in the fields and click the add button to add a new operational type.Note that all required fields are marked with a *.</p>
		    <hr/>
            <br />
            <asp:label runat="server">Operational Type Name*</asp:label>
            <br/>
            <asp:TextBox ID="OperationName" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <a href="Settings.aspx" class="btn btn-info btn-lg">Back</a>
            <asp:button runat="server" cssclass="btn-info btn-lg btn" text="Add" onclick="addOperationalType" /><br /><br />
        </div>
    </form>
</body>
</html>
