$(document).ready(function () {
    
    var clicker = 0;
   
    


    $('#normalnav a[href = "Settings.aspx"]').hide();

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

    $('#rental').load(



        );
    
    $('#rental').click(function () {
        clicker++;
        //alert(clicker);
        if (clicker == 2) {
            //alert($(this).val());
            if ($(this).val() == "2") {
                //alert(clicker);
                $('#quantity').show();
                $('#TextBox1').hide();
                $('#days').show();
                $('#kml').hide();
            }
            else if ($(this).val() == "3") {
                $('#quantity').hide();
                $('#TextBox1').show();
                $('#days').hide();
                $('#kml').show();
            }
            else
            {
                $('#quantity').show();
                $('#TextBox1').show();
                $('#days').show();
                $('#kml').show();
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

