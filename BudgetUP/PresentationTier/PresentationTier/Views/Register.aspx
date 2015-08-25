<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PresentationTier.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="../bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	<script src="../bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <script src="../Scripts/NavigationJS.js"></script>
    <link rel="stylesheet" href="../Styles/Global.css"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">

        <div id ="regDiv" runat="server">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                    <a class="navbar-brand" href="ProjectsPage.aspx">BudgetUP</a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav">
                    </ul>
                </div>
            </div>
        </nav>
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
                     <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link " ><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px; margin-left:2px;"  src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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
                     <asp:LinkButton runat="server" CssClass=" navbar-brand btn btn-link " ><span class="glyphicon glyphicon-menu-left"></span></asp:LinkButton><img class=" navbar-brand img-responsive img-rounded" style=" padding:0; border-radius:0; margin-right:2px; margin-left:2px;"  src="../Images/logo.png"></img><a class="navbar-brand" href="#">BudgetUP</a>
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

              <div id="myModal" class="modal fade"  role="dialog">
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
         <a id="btn" runat="server" href="Settings.aspx" class=" back btn btn-info btn-lg"  >Back</a>

                <div id="AddActivity" class="contentArea"><br />
                <h1>Register</h1><hr />
                <asp:Label runat="server" Font-Bold="True">Name</asp:Label><asp:TextBox autofocus runat="server" ID="name" required name="name" placeholder="" CssClass="form-control" MaxLength="35" ></asp:TextBox><br />
                <asp:Label runat="server" Font-Bold="True">Surname</asp:Label><asp:TextBox runat="server" ID="surname" required name="surname" placeholder="" CssClass="form-control" MaxLength="35" ></asp:TextBox><br />
                <asp:Label runat="server" Font-Bold="True">Title </asp:Label><asp:DropDownList required runat="server" ID="title" name="title"  CssClass="form-control" OnInit="title_Init"></asp:DropDownList><br />
                <asp:Label runat="server" Font-Bold="True">Email Address </asp:Label><asp:TextBox required type="email" runat="server" ID="email"  name="email" CssClass="form-control" MaxLength="35"></asp:TextBox><br />
                    
                <asp:Label runat="server" Font-Bold="True">Password</asp:Label><asp:TextBox required type="password" runat="server" ID="Password" name="email" CssClass="form-control" MaxLength="35" ></asp:TextBox><br />
                    
                <asp:Label runat="server" Font-Bold="True">Confirm password</asp:Label><asp:TextBox required type="password" runat="server"  ID="PasswordConfirm" name="email" CssClass="form-control" MaxLength="35" ></asp:TextBox><br />
                <asp:Label runat="server" Font-Bold="True">Role</asp:Label> 
                <asp:DropDownList class="form-control" ID="roles" runat="server" OnInit="DropDownList4_Init" OnSelectedIndexChanged="roles_SelectedIndexChanged">
                    <asp:ListItem Value="1">Academic</asp:ListItem>
                    <asp:ListItem Value="2">Student</asp:ListItem>
                    <asp:ListItem Value="3">Support Personel</asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label runat="server" Font-Bold="True">Faculty</asp:Label> 
                <asp:DropDownList class="form-control" ID="faculty" runat="server" OnInit="DropDownList3_Init">
                    <asp:ListItem Value="1">Humanities</asp:ListItem>
                    <asp:ListItem Value="2">Education</asp:ListItem>
                    <asp:ListItem Value="3">Theology</asp:ListItem>
                    <asp:ListItem Value="4">Law</asp:ListItem>
                    <asp:ListItem Value="5">Economic and Management Sciences</asp:ListItem>
                    <asp:ListItem Value="6">Veterinary Sciences</asp:ListItem>
                    <asp:ListItem Value="7">Health Sciences</asp:ListItem>
                    <asp:ListItem Value="8">Natural and Agricultural</asp:ListItem>
                    <asp:ListItem Value="9">Engineering, Built Environment and IT</asp:ListItem>
                    <asp:ListItem Value="10">Department of Research and Innovation Support</asp:ListItem>
                    <asp:ListItem Value="11">GIBs</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>

                </asp:DropDownList><br />
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" OnClick="Unnamed8_Click" /><br /><br />
            </div>
    </form>
</body>
</html>
