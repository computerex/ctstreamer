<h1><b><?php echo $stream['title'];?></b></h1><br/>
<img id="view" src=""></img>
<h6>viewers: <?php echo $stream['viewers'];?></h6>
</br>
<div id = "chatbox">
</div>
<?php if (isloggedin()) { ?>
       <form action="chatmessage.php" id = "chatsendform" method="post">
			<fieldset>
				<textarea name="message" id="chatmsg" class="form-control" placeholder=""></textarea>
				<input type="hidden" name="id" value="<?php echo $stream['id']; ?>"> </input>
				<div class="control-group">
					<button type="submit" class="btn" id="chatsend">Send</button>
				</div>
			</fieldset>
		</form>
	<?php } ?>
<script type="text/javascript">

jQuery("#chatsendform").submit(function() {

    var url = "chatmessage.php";
	if ( jQuery("#chatmsg").val().length <= 0 ) return false;
    jQuery.ajax({
           type: "POST",
           url: url,
           data: $("#chatsendform").serialize(),
           success: function(data)
           {
           }
         });
    jQuery("#chatmsg").val(""); 
    return false; 
});

var date = new Date(); 

// scrolling chat
window.setInterval(function() {
  var elem = document.getElementById('chatbox');
  elem.scrollTop = elem.scrollHeight;
}, 1000);

function requestFullScreen(element) {
    // Supports most browsers and their versions.
    var requestMethod = element.requestFullScreen || element.webkitRequestFullScreen || element.mozRequestFullScreen || element.msRequestFullScreen;

    if (requestMethod) { // Native full screen.
        requestMethod.call(element);
    } else if (typeof window.ActiveXObject !== "undefined") { // Older IE.
        var wscript = new ActiveXObject("WScript.Shell");
        if (wscript !== null) {
            wscript.SendKeys("{F11}");
        }
    }
}

function getchat(){
   jQuery.ajax({
        url: "chat.php?id=<?php echo $stream['id'];?>",
        success: function(response) {
            processchat(response);

        }
    });
	setTimeout(getchat, 500);
}

function processchat(responseObj){
	var obj = JSON.parse(responseObj);
	var chat = jQuery("#chatbox");
	for(var i = 0; i < obj.length; i++)
	{
	    var e = obj[i];
		var user = e["username"];
		var message = e["message"];
		chat.append("<div class='chatuser'>" + user + ":</div> ");
		chat.append("<div class='chatmessage'>" + message + "</div> ");
	}
}
   
function gofs()
{
	var elem = document.getElementById("view"); // Make the body go full screen.
	requestFullScreen(elem);
}

function update()
{
	jQuery("#view").attr("src", "<?php echo $stream['img_url'];?>?"+date.getTime());
	setTimeout(update, 50);
}
function userpoll()
{
	jQuery.ajax("userpoll.php?id=<?php echo $stream['id']; ?>");
	setTimeout(userpoll, <?php echo POLLTIME*1000;?>);
}

jQuery("#view").click(function(){gofs();});
update(); 
userpoll();
setTimeout(getchat, 500);
</script>