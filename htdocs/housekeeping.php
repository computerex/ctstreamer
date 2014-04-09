<?php
	require('includes/config.php');
	
	if ( !isset($_GET["secret"]) )
		exit;
	if ( strcmp($_GET["secret"], SECRET) )
		exit;
	// prune tables
	query("delete from onlinestreams where (polltime+?) < unix_timestamp()", POLLTIME);
	query("delete from usersonline where (time+10) < unix_timestamp()");
?>
