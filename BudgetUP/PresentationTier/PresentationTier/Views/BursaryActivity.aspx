﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BursaryActivity.aspx.cs" Inherits="PresentationTier.Views.BursaryActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Bursary</title>
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="../Scripts/script.js"></script>
    <script src="../Scripts/moment.min.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.min.js"></script>
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
        <a href="ActivitiesPage.aspx" class="back btn btn-info btn-lg">Back</a>
        <div id="Add" class="contentArea">
            <br />
            <h1>Bursary</h1>
            <hr />
            <p>Fill in the fields and click the add button to add a new Bursary. Note that all required fields are marked with a *.</p>
            <hr />
            <asp:Label runat="server" Font-Bold="True">Type of bursary*</asp:Label>
            <asp:DropDownList class="form-control" ID="bursaryType" runat="server" OnInit="bursaryType_Init">
                <asp:ListItem Value="1">Master</asp:ListItem>
                <asp:ListItem Value="2">Doctoral</asp:ListItem>
                <asp:ListItem Value="3">Post-doctoral fellow</asp:ListItem>
            </asp:DropDownList><br />
            <br />
            <asp:Label runat="server" Font-Bold="True">Start of bursary*</asp:Label>
            <div class="input-group datetimepicker5 col-lg-6 col-md-6 col-sm-6 col-xs-6 " style="margin-left: 25%">
                <asp:TextBox required runat="server" ID="sdate" name="sdate" CssClass="form-control">2015-01-01</asp:TextBox>
                <span class="input-group-addon" style="background-color: white">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
            <br />
            <asp:Label runat="server" Font-Bold="True">Notes</asp:Label><asp:TextBox TextMode="multiline" Columns="50" Rows="5" required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
            <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" OnClick="Unnamed4_Click" /><br />
            <br />
        </div>
    </form>

</body>
</html>
