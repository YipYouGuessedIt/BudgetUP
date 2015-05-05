<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MyProfile.aspx.vb" Inherits="PresentationTier.MyProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
         <title>Project Adder</title>
        <link href="bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="Styles/Global.css"/>
       <meta name="viewport" content="width=device-width, initial-scale=1"/>
    </head>
    <body>
        <form id="form1" runat="server">            
            <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>                        
                    </button>
                    <a class="navbar-brand" href="./Hme.aspx">BudgetUP</a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav">
                        <li><a href="./Hme.aspx">My Projects</a></li> 
                        <li> <a href="./MyProfile.aspx">Profile</a></li> 
                        <li> <a href="f">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>

            <div id="ProfileContent" class="contentArea">
                <h1>Lectures Name Profile</h1>   <hr /> 
                <br /> 
            </div>
        </form>

         <div class="navbar navbar-inverse navbar-fixed-bottom">
            <ul class="nav navbar-nav">
              <li> This is our awesome footer</li> 
            </ul>
        </div>
    </body>
</html>
