<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="PresentationTier.Views.ProfilePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <h1>Profile</h1><hr />
                    		<p>Fill in the fields and click the add button to edit your profile.Note that all required fields are marked with a *.</p>
		<hr/>
                    <br />

                <asp:Label runat="server" ID="Label1">Title*</asp:Label> 
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
                    <br />
                <asp:Label runat="server">Name*</asp:Label><asp:TextBox runat="server" ID="name" required="true" name="name" CssClass="form-control" Height="25px">John Smith</asp:TextBox>
                    <br />
                <asp:Label runat="server" ID="Label2">Surname*</asp:Label><asp:TextBox runat="server" ID="name0" required="true" name="name" CssClass="form-control" Height="25px">John Smith</asp:TextBox><br />
                <asp:Label runat="server">Email Address* </asp:Label><asp:TextBox required="true"  type="email" runat="server" ID="email" name="email" CssClass="form-control" Height="25px"></asp:TextBox>
                    <br />
                <asp:Label runat="server" ID="Label3">Password*</asp:Label><asp:TextBox required="true"  type="password" runat="server" ID="password"  name="email" CssClass="form-control" Height="25px"></asp:TextBox>
                    <br />
                    <br />
                <asp:Label runat="server">Role*</asp:Label> 
                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" OnInit="DropDownList2_Init">
                    <asp:ListItem Value="1">Academic</asp:ListItem>
                    <asp:ListItem Value="2">Student</asp:ListItem>
                    <asp:ListItem Value="3">Support Personel</asp:ListItem>

                </asp:DropDownList><br /><br />

                <asp:Label runat="server">Faculty*</asp:Label> 
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

                </asp:DropDownList><br /><br />
                <a href="ProjectsPage.aspx" class="btn btn-info btn-lg"  >Back</a>
                <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Save" OnClick="Unnamed6_Click" /><br /><br />
            </div>
    </form>
</body>
</html>
