<?php

    // configuration
    require("includes/config.php"); 

	$rows = query("select onlinestreams.id, users.username, users.desc, users.title from onlinestreams, users where onlinestreams.id = users.id");
	// [id, username, desc, title, img_url, viewers]	
	$streams = [];
	for($i = 0; $i<count($rows); $i++)
	{
		$row = $rows[$i];
		$streams[$i]=[];
		// id, username, desc, title
		foreach($row as $key=>$value)
		{
			$streams[$i][$key] = $value; 
		}
		// img_url, viewers
		$streams[$i]["img_url"] = "samples/" . $row["id"] . "samplesample.jpg";
		$viewcount = query("select count(*) from usersonline where streamid=?",$row["id"])[0];
		$streams[$i]["viewers"] = $viewcount["count(*)"];
	}
    // render
    render("home.php", ["title" => "Home", "streamdata" => $streams]);
?>
