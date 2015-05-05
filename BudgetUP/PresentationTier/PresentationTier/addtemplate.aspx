<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="addtemplate.aspx.vb" Inherits="PresentationTier.addtemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project Adder</title>
    <link href="bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"/>
	<script src="bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Styles/Global.css"/>
   <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>

        
    <nav class="navbar navbar-inverse navbar-fixed-top">
  <div class="container">
    <div class="navbar-header">
      <a class="navbar-brand" href=""><img class="" src="Images/UP_Logo.PNG" /></a>
      <ul class="nav navbar-nav">
        <li><a href="./Hme.aspx">My Projects</a></li> 
        <li> <a href="./MyProfile.aspx">Profile</a></li> 
          <li> <a href="f">Logout</a></li> 
      </ul>
        </div>
      </div>
        </nav>

    <form id="form1" runat="server">


    <div id="AddProjects" class="contentArea">
        <h1>Prodject</h1>

        <asp:Label runat="server">Project Name</asp:Label><asp:TextBox runat="server" ID="Name" name="Name" CssClass="form-control"></asp:TextBox>
        <asp:Label runat="server">Project Head </asp:Label><asp:TextBox runat="server" ID="Prof" name="Prof" CssClass="form-control"></asp:TextBox>
        <asp:Label runat="server">Start date</asp:Label><asp:TextBox runat="server" ID="Date" name="Date" type ="date" CssClass="form-control"></asp:TextBox>
        <asp:Button runat="server" CssClass="btn-info btn-lg btn" Text="Add" />
    </div>
    </form>

     <div class="navbar navbar-inverse navbar-fixed-bottom">
                   <ul class="nav navbar-nav">

          <li> This is our awesome footer</li> 
      </ul>
        </div>
</body>
</html>
