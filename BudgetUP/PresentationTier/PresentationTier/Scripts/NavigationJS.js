$(document).ready(function () {
    $('#logout').click(function (e) {
        
        //alert('f');
        e.preventDefault();
        $.ajax({ 
            type: "POST", 
            url: "../Views/Logout.ashx",
            success: function () { location.reload() },
            error: function () { }
        });
        
    });
    
});
