﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBursaryType.aspx.cs" Inherits="PresentationTier.Views.AddBursary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Bursary</title>
    <link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
    <link rel="stylesheet" href="../Styles/Global.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
                        <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link "><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton>
                        <img class=" navbar-brand img-responsive img-rounded" style="padding: 0; border-radius: 0; margin-right: 2px; margin-left: 2px;" src="../Images/logo.png"></img>


                        <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link "><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style="padding: 0; border-radius: 0; margin-right: 2px; margin-left: 2px;" src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
                    </div>
                    <div class="collapse navbar-collapse" id="myNavbar">
                        <ul class="nav navbar-nav">
                            <li><a href="ProjectsPage.aspx">My Projects</a></li>
                            <li><a href="ProfilePage.aspx">Profile</a></li>
                            <li><a href="ManageUsers.aspx">Manage Users</a></li>
                            <li><a href="Settings.aspx">Settings</a></li>
                            <li><a id="logout" href="LoginPage.aspx">Logout</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>
        <div id="normalnav" runat="server">
            <nav class="navbar navbar-inverse">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link "><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton>
                        <img class=" navbar-brand img-responsive img-rounded" style="padding: 0; border-radius: 0; margin-right: 2px; margin-left: 2px;" src="../Images/logo.png"></img>


                        <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link "><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style="padding: 0; border-radius: 0; margin-right: 2px; margin-left: 2px;" src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
                    </div>
                    <div class="collapse navbar-collapse" id="myNavbar2">
                        <ul class="nav navbar-nav">
                            <li><a href="ProjectsPage.aspx">My Projects</a></li>
                            <li><a href="ProfilePage.aspx">Profile</a></li>
                            <li><a href="Settings.aspx">Settings</a></li>
                            <li><a id="logout2" href="LoginPage.aspx">Logout</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>


        <div id="myModal" class="modal fade" role="dialog">
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
        <a href="Settings.aspx" class="back btn btn-info btn-lg">Back</a>
        <div id="Add" class="contentArea">
            <br />
            <h1>Create Bursary type</h1>
            <hr />
            <br />
            <asp:Label runat="server" Font-Bold="True">Bursary Name*</asp:Label>
            <br />
            <asp:TextBox ID="BursaryDescription" runat="server" CssClass="form-control" MaxLength="199"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Annual cost*" Font-Bold="True"></asp:Label>
            <br />
            <asp:TextBox ID="AnnualCost" runat="server" type="number" min="0" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Years*" Font-Bold="True"></asp:Label>
            <br />
            <asp:TextBox ID="Years" runat="server" type="number" min="0" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" OnClick="addBursary" /><br />
            <br />
        </div>
    </form>
</body>
</html>
