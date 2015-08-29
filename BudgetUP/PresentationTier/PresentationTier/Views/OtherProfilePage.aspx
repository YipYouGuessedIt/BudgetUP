<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherProfilePage.aspx.cs" Inherits="PresentationTier.Views.OtherProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

                        <div id="Div1" runat="server">Are you sure you want to delete the project?All items under the project will also be removed.</div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="btn-info btn" Text="Delete" OnClick="Unnamed_Click" ID="Button1" />
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
        <a id="btn" runat="server" href="Settings.aspx" class=" back btn btn-info btn-lg">Back</a>


        <div id="AddActivity" class="contentArea">
            <br />
            <h1>Profile</h1>
            <hr />
            <p>Fill in the fields and click the save button to edit the user. Note that all required fields are marked with a *.</p>
            <hr />
            <br />

            <asp:Label runat="server" Font-Bold="True">Name*</asp:Label><asp:TextBox runat="server" ID="name" required="true" name="name" CssClass="form-control" Height="25px"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="Label2" Font-Bold="True">Surname*</asp:Label><asp:TextBox runat="server" ID="name0" required="true" name="name" CssClass="form-control" Height="25px"></asp:TextBox>
            <br />

            <asp:Label runat="server" ID="Label1" Font-Bold="True">Title*</asp:Label>
            <asp:DropDownList class="form-control" ID="DropDownList4" runat="server" OnInit="DropDownList4_Init">
                <asp:ListItem Value="1">Humanities</asp:ListItem>
                <asp:ListItem Value="2">Education</asp:ListItem>
                <asp:ListItem Value="3">Theology</asp:ListItem>
                <asp:ListItem Value="4">Law</asp:ListItem>
                <asp:ListItem Value="5">Economic and Management Sciences,</asp:ListItem>
                <asp:ListItem Value="6">Veterinary Sciences</asp:ListItem>
                <asp:ListItem Value="7">Health Sciences</asp:ListItem>
                <asp:ListItem Value="8">Natural and Agricultural</asp:ListItem>
                <asp:ListItem Value="9">Engineering Built Environment and IT,</asp:ListItem>
                <asp:ListItem Value="10">Department of Research and Innovation Support</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>

            </asp:DropDownList><br />
            <asp:Label runat="server" Font-Bold="True">Email Address* </asp:Label><asp:TextBox required="true" type="email" runat="server" ID="email" name="email" CssClass="form-control" Height="25px" MaxLength="35"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="Label3" Font-Bold="True">Password*</asp:Label><asp:TextBox required="true" type="password" runat="server" ID="password" name="email" CssClass="form-control" Height="25px" MaxLength="35"></asp:TextBox>
            <br />
            <asp:Label runat="server" ID="Label4" Font-Bold="True">Password*</asp:Label><asp:TextBox required="true" type="password" runat="server" ID="passwordconfirm" name="email" CssClass="form-control" Height="25px" MaxLength="35"></asp:TextBox><br />
            <asp:Label runat="server" Font-Bold="True">Role*</asp:Label>
            <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" OnInit="DropDownList2_Init">
                <asp:ListItem Value="1">Academic</asp:ListItem>
                <asp:ListItem Value="2">Student</asp:ListItem>
                <asp:ListItem Value="3">Support Personel</asp:ListItem>

            </asp:DropDownList><br />

            <asp:Label runat="server" Font-Bold="True">Faculty*</asp:Label>
            <asp:DropDownList class="form-control" ID="DropDownList3" runat="server" OnInit="DropDownList3_Init">
                <asp:ListItem Value="1">Humanities</asp:ListItem>
                <asp:ListItem Value="2">Education</asp:ListItem>
                <asp:ListItem Value="3">Theology</asp:ListItem>

                <asp:ListItem Value="4">Law</asp:ListItem>
                <asp:ListItem Value="5">Economic and Management Sciences,</asp:ListItem>
                <asp:ListItem Value="6">Veterinary Sciences</asp:ListItem>
                <asp:ListItem Value="7">Health Sciences</asp:ListItem>
                <asp:ListItem Value="8">Natural and Agricultural</asp:ListItem>
                <asp:ListItem Value="9">Engineering Built Environment and IT,</asp:ListItem>
                <asp:ListItem Value="10">Department of Research and Innovation Support</asp:ListItem>
                <asp:ListItem>Other</asp:ListItem>

            </asp:DropDownList><br />

            <asp:Label runat="server" Font-Bold="True">Admin*</asp:Label>
            <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" OnInit="DropDownList2_Init">
                <asp:ListItem Value="0">No</asp:ListItem>
                <asp:ListItem Value="1">Yes</asp:ListItem>
            </asp:DropDownList><br />
            <br />
            &nbsp;<asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" OnClick="Unnamed6_Click" />
            <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal2">Delete</button>
        </div>
    </form>
</body>
</html>
