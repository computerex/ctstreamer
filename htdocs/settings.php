<?php

require('includes/config.php');

if ( !isloggedin() ) exit; 

if ( !empty($_POST["desc"]) && !empty($_POST["title"]) )
{
	query("update users set users.desc = ?, users.title = ? where users.id = ?", $_POST["desc"], $_POST["title"], $_SESSION["id"]);
	redirect("/");
}
else
{
    $row = query("select users.title, users.desc from users where users.id = ?", $_SESSION["id"])[0];
	$row["id"] = $_SESSION["id"];
	render("settings_form.php", ["title" => "settings", "settings" => $row]);
}

?>