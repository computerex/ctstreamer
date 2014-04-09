<?php
	require('includes/config.php');
	
		$file = fopen("out.txt", "w");
	fwrite($file, "stream poll");
	fclose($file);
	if ( !isloggedin() )
		exit;
	if ( empty($_SESSION["id"]) )
		exit;
	$t = time(); 
	query("insert into onlinestreams (id, polltime) values(?, ?) on duplicate key update polltime=?", 
																						$_SESSION["id"],
																						$t, $t);

?>
