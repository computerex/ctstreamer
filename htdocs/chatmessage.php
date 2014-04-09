<?php

require("includes/config.php");

if ( !isloggedin() ) exit;


$username = query("select username from users where users.id=?", $_SESSION["id"])[0]["username"];
$message = strip_tags($_POST["message"]);

query("insert into chatmessages (username, message, streamid, streamofs) SELECT ?, ?, ?, max(streamofs) +1 from chatmessages", 
                                                                 $username, $message, $_POST["id"]);
?>