<!DOCTYPE html>

<html>

    <head>

        <link href="css/bootstrap.css" rel="stylesheet"/>
        <link href="css/bootstrap-responsive.css" rel="stylesheet"/>
        <link href="css/styles.css" rel="stylesheet"/>

        <?php if (isset($title)): ?>
            <title>Orbiter Remote: <?= htmlspecialchars($title) ?></title>
        <?php else: ?>
            <title>Orbiter Remote</title>
        <?php endif ?>

        <script src="js/jquery-1.8.2.js"></script>
        <script src="js/bootstrap.js"></script>
        <script src="js/scripts.js"></script>

    </head>

    <body>

        <div class="container-fluid">
            <div id="top">
				<div class="navbar navbar-static-top">
					<div class="navbar-inner">
						<ul class="nav" style="width:100%">
							<a class="brand" style="float:right">orbRemote</a>  
							<li><a href="/">Online Streams</a></li>
							<li class="dropdown">
								<a href="/signup/index" class="dropdown-toggle" data-toggle="dropdown">Account<b class="caret"></b></a>
								<ul class="dropdown-menu">
									<?php if(!isloggedin()){ ?>
									<li><a href="/login.php">login</a></li>
									<?php } else { ?>
									<li><a href="/settings.php">settings</a></li>
									<li><a href="/logout.php">logout</a></li>
									<?php }?>
								</ul>
								
							</li>
						</ul>
					</div>
				</div>
			</div>
            <div id="middle">

