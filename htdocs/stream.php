<?php
	require('includes/config.php');
	
	if ( empty($_GET["id"]) ){
		echo "<h1>Invalid stream link</h1>";
		exit;
	}
	if ( !isstreamlive($_GET["id"]) )
	{
		echo "<h1>Stream offline</h1>";
		exit;
	}
	$id = $_GET["id"];
	$rows = query("select users.username, users.desc, users.title from onlinestreams, users where onlinestreams.id = users.id and users.id = ?", $id);
	$row = $rows[0];
	// [id, username, desc, title, img_url, viewers]	
	$stream = [];
	$stream["id"]=$id;
	// username, desc, title
	foreach($row as $key=>$value)
	{
		$stream[$key] = $value; 
	}
	// img_url, viewers
	$stream["img_url"] = "samples/" . $id . "samplesample.jpg";
	$viewcount = query("select count(*) from usersonline where streamid=?",$id)[0];
	$stream["viewers"] = $viewcount["count(*)"];
    // render
    render("stream_form.php", ["title" => "Stream", "stream" => $stream]);
?>
