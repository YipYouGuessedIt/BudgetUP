<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Hme.aspx.vb" Inherits="PresentationTier.Hme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    	<title>BudgetUp</title>
	    <link href="bootstrap/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet"/>
	    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap-theme.min.css"/>
	    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
	    <script src="bootstrap/bootstrap-3.3.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="Styles/Global.css"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
    </head>
    <body>    
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
                        <li><a href="./Hme.aspx">My Projects</a></li> 
                        <li> <a href="./MyProfile.aspx">Profile</a></li> 
                        <li> <a href="f">Logout</a></li> 
                    </ul>
                </div>
            </div>
        </nav>
        <div class="contentArea">
            <h1>Project</h1>

            <div id="ProjectSearch">
				<input class="form-control" placeholder="Search..." /><br />
			</div>

            <div id="ProjectAdd">
				<a href="./addtemplate.aspx" class="btn btn-info btn-lg"  >Add new project</a><br /><br />
			</div>

			<div id="ProjectList" class="list-group">
				<a class="list-group-item" href="">Item one</a><br />
                <a class="list-group-item" href="">Item two</a><br />
                <a class="list-group-item" href="">Item Three</a><br />				
			</div>
        </div>

        <div class="navbar navbar-inverse navbar-fixed-bottom">
            <ul class="nav navbar-nav">
                <li> This is our awesome footer</li> 
            </ul>
        </div>
    </body>
</html>
