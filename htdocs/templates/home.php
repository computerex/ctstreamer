
<?php if (empty($streamdata)){ ?>
	<h1>No one streaming!</h1>
	</br>
	<img src="img/sadbaby.jpg" width="20%">
	</br>
	Check back later!
<?php } else {
	foreach($streamdata as $stream)
	{ ?>
	<b><?php echo $stream['title'];?></b><br/>
	<a href="stream.php?id=<?php echo $stream['id'];?>"><img src = "<?php echo $stream['img_url'];?>" width="20%"></a><br/>
	viewers: <?php echo $stream['viewers'];?><br/>
	<br/>
	<div class="inlineblock desc">
		<?php echo $stream['desc'];?>
	</div>
	<br/>
	<br/>
<?php	}
 } ?>
 