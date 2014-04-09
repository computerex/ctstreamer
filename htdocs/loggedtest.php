<?php
	require('includes/config.php');
	$logged = var_export(isloggedin(), true);
	echo $logged . "<br/>";
?>
