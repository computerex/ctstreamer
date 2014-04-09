<?php

require("includes/config.php");

if (empty($_SESSION["streamofs"]))
{
	$_SESSION["streamofs"] = 0;
}

$rows = query("select chatmessages.username, chatmessages.message, chatmessages.streamofs from chatmessages where chatmessages.streamid = ? and chatmessages.streamofs > ?", 
																										$_GET["id"], $_SESSION["streamofs"]);
$len = count($rows);
if ( $len > 0 )																										
   $_SESSION["streamofs"]	= $rows[$len-1]["streamofs"];		

for($i = 0; $i < $len; $i++)
{
   unset($rows[$i]["streamofs"]);
} 
$js = json_encode($rows);

echo $js;
?>