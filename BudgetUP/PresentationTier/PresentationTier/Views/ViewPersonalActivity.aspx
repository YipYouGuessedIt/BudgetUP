﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPersonalActivity.aspx.cs" Inherits="PresentationTier.Views.ViewPersonalActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Personel</title>
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


        <div id="myModal2" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Confirm Delete</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div1" runat="server">Are you sure you want to delete the personal activity? All details will be deleted.</div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn-info btn" Text="Delete" OnClick="Button1_Click" ID="Button2" />
                        <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
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
        <a href="IncomeandExpensesPage.aspx" class=" back btn btn-info btn-lg">Back</a>

        <div id="Add" class="contentArea">
            <br />
            <h1>Personnel Involvment</h1>
            <hr />
            <p>Fill in the fields and click the save button to edit the current personnel involvement. Note that all required fields are marked with a *.</p>
            <hr />
            <asp:Label runat="server">Select Post level* </asp:Label>
            <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" OnInit="DropDownList2_Init">
                <asp:ListItem Value="1">Admin</asp:ListItem>
                <asp:ListItem Value="2">Lecturer</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label ID="Label1" runat="server" Text="">Duration of involvement*</asp:Label>
            <asp:TextBox runat="server" ID="numofdays" min="0" type="number" required name="numofdays" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Label runat="server">Subventilation levy* </asp:Label>
            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="1">Yes</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label runat="server">Notes*</asp:Label><asp:TextBox TextMode="multiline" Columns="50" Rows="5" required runat="server" ID="note" name="note" CssClass="form-control"></asp:TextBox><br />
            <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" OnClick="Unnamed4_Click" />
            <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal2">Delete</button>
            <br />
            <br />
        </div>
    </form>

</body>
</html>
