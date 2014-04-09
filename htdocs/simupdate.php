<?php
	require('includes/config.php');
	// update sample
	
	// check if logged in_array
	if ( !isloggedin() )
		exit; 
	// check if file uploaded successfully 
	if ( !empty($_FILES["file"]) ){
		if ( $_FILES["file"]["error"] == 0 ){
			$name = sprintf("samples/%dsample%s", $_SESSION["id"], $_FILES["file"]["name"]);
			move_uploaded_file($_FILES["file"]["tmp_name"], $name);

			// set activity flag
			if (empty($_SESSION["CREATED"])){
				$_SESSION["CREATED"]=time();
				$_SESSION["STREAMER"]=true;
				// reset chat
				query("delete from chatmessages where streamid = ?", $_SESSION["id"]);
				// add to database
				query("insert into onlinestreams (id) VALUES(?)", $_SESSION["id"]);
			}/*else{
			    // still online
				// update every 30 seconds
				// housekeeping prunes entries periodically 
				if ( (time()-$_SESSION["CREATED"]) >= 30 ){
					query("insert into onlinestreams (id) VALUES(?) on duplicate key update id=id",
							$_SESSION["id"]);
							$_SESSION["CREATED"]=time();
				}
			}*/
		}else{
			echo "Error uploading sample: " . $_FILES["file"]["error"]; 
		}
	}else{
		echo "no sim update";
	}
?>
