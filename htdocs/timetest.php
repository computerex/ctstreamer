<?php

require("includes/config.php");

$t = microtime(true)*1000;
$file=fopen("out.txt","a");
fwrite($file, "candy" . PHP_EOL);
fclose($file);
$t2 = microtime(true)*1000;
echo ($t2-$t);
if ( empty($_SESSION["lasttime"]) )
	$_SESSION["lasttime"]=$t;
//echo $t-$_SESSION["lasttime"];
//$file=fopen("out.txt","a");
//fwrite($file,((string)($t-$_SESSION["lasttime"])) . PHP_EOL);
//fclose($file);
$_SESSION["lasttime"] = $t;
			
?>