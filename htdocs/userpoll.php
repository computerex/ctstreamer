<?php

require('includes/config.php');

if ( empty($_GET["id"]) )
	exit;
	
// check if stream is online
if(!query("select * from onlinestreams where id = ?", $_GET["id"]))
{
	echo "<h1><center>error, stream offline</center></h1>";
	exit;
}
$t = time();
query("insert into usersonline (streamid, time, sessid) values(?,?,?) on duplicate key update time=?", $_GET["id"],
																			$t, session_id(), $t);
?>