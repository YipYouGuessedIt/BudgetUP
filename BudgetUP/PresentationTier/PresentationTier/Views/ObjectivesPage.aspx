<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjectivesPage.aspx.cs" Inherits="PresentationTier.Views.ObjectivesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Objective</title>
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

        <div id="currencySelection" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Please select the currency for report</h4>
                    </div>
                    <div class="modal-body">
                        <div class="dropdown">
                            <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown">
                                Dropdown Example
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu">
                                <li><a href="#">HTML</a></li>
                                <li><a href="#">CSS</a></li>
                                <li><a href="#">JavaScript</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-info" data-dismiss="modal">Continue</button>
                        <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>

        <div id="myModal2" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Email confirmation sent</h4>
                    </div>
                    <div class="modal-body">

                        <div id="Div3" runat="server"></div>
                    </div>
                    <div class="modal-footer">
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
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
        <div id="adminnav" runat="server">
            <nav class="navbar navbar-inverse">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <asp:LinkButton runat="server" href="ProjectsPage.aspx" CssClass=" navbar-brand btn btn-link "><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style="padding: 0; border-radius: 0; margin-right: 2px; margin-left: 2px;" src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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
                        <asp:LinkButton runat="server" href="ProjectsPage.aspx" CssClass=" navbar-brand btn btn-link "><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style="padding: 0; border-radius: 0; margin-right: 2px; margin-left: 2px;" src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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

        <div id="tree" runat="server" class="treeView">
        </div>

        <a href="ProjectsPage.aspx" class="back btn-info btn-lg">Back</a>
        <div class="contentArea">
            <br />

            <h1 id="heaserarea" runat="server"></h1>
            <hr />
            <div id="Div1" runat="server"></div>
            <hr />
            <div id="Div2" runat="server"></div>
            <a href="EditProject.aspx" class="btn btn-info btn-lg">Edit Project</a>


            <div id="ObjectiveAdd" class="">
                <hr />


                <asp:LinkButton ID="buttonadd" runat="server" href="AddObjectives.aspx" class="btn btn-info btn-lg ">Add Objective</asp:LinkButton>

                <div id="ObjectiveSearch" runat="server" class="col-lg-2 pull-right serc">
                    <div class="input-group">
                        <asp:TextBox runat="server" autofocus="true" placeholder="Search" ID="searcher" CssClass=" form-control" OnTextChanged="Button1_Click"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton runat="server" ID="Button1" class="btn " Style="background-color: white;" OnClick="Button1_Click"><span class='glyphicon glyphicon-search'></span></asp:LinkButton>
                        </span>
                    </div>
                </div>





            </div>
            <input type="hidden" />
            <div id="ObjectiveList" class="list-group" runat="server">
                <br />
                <asp:PlaceHolder ID="ObjectiveLister" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </form>
</body>
</html>
