<form action="settings.php" method="post">
    <fieldset>
        <div class="control-group">
            <input autofocus name="title" placeholder="<?php echo $settings["title"]?>" type="text"/>
        </div>
        <textarea name="desc" class="form-control" placeholder="<?php echo $settings["desc"]?>"></textarea>
        <div class="control-group">
            <button type="submit" class="btn">Save</button>
        </div>
    </fieldset>
</form>