<?php

    // configuration
    require("includes/config.php"); 

	if ( isloggedin() )
	{
		// log out current user, if any
		logout();
	}
    // redirect user
    redirect("/");

?>
