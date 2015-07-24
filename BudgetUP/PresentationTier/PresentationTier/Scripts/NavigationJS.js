$(document).ready(function () {
var clicker = 0;
    $('#fleet11').click(function () 
	{ 
	clicker++ ;
	//alert(clicker);
	if(clicker == 2)
	{
		//alert($(this).val());
		if($(this).val() == "1")
		{
			//alert(clicker);
			$('#returnTicket').hide();
			$('#ReturnLabeler').hide();
		}
		else
		{
			$('#returnTicket').show();
			$('#ReturnLabeler').show();
		}
		clicker = 0;
	}
		
	});

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

    $('#logout2').click(function (e) {

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
