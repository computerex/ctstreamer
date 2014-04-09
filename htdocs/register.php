<?php

    // configuration
    require("includes/config.php");

    // if form was submitted
    if ($_SERVER["REQUEST_METHOD"] == "POST")
    {
      //  echo "username: " . $_POST["username"] . " password: " . "{$_POST['password']}";
      if ( empty($_POST["password"]) or empty($_POST["username"]) or empty($_POST["confirmation"]) )
      {
        apologize("Please enter a username and matching passwords");
      }
      $pwd=$_POST["password"];
      $conf=$_POST["confirmation"];
      if ( strcmp($pwd,$conf) != 0 )
      {
        apologize("Passowords don't match");
      }
      // add the user in database
      $qr = query("INSERT INTO users (username, hash, users.desc, users.title) VALUES(?, ?, ?, ?)", 
                    $_POST["username"], crypt($_POST["password"]), ' ', $_POST["username"] . ' stream');
      if ( $qr===false )
      {
        apologize("error, pick a different username");
      }
      $rows = query("SELECT LAST_INSERT_ID() AS id");
      $id = $rows[0]["id"];
      $_SESSION["id"]=$id;
      redirect("/");
    }
    else
    {
        // else render form
        render("register_form.php", ["title" => "Register"]);
    }

?>

