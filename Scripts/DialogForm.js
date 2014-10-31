﻿$(function () {
 
    $.ajaxSetup({
        cache: false
    });

    // Wire up the click event of any current or future dialog links
    $('.dialogLink').live('click', function () {
        var element = $(this);

        // Retrieve values from the HTML5 data attributes of the link        
        var dialogTitle = element.attr('data-dialog-title');
        var updateTargetId = '#' + element.attr('data-update-target-id');
        var updateUrl = element.attr('data-update-url');

        // Generate a unique id for the dialog div
        var dialogId = 'uniqueName-' + Math.floor(Math.random() * 1000)
        var dialogDiv = "<div id='" + dialogId + "'></div>";

        // Load the form into the dialog div
        $(dialogDiv).load(this.href, function () {
            $(this).dialog({
                modal: true,
                resizable: true,
                title: dialogTitle,
                buttons: {
                    "Save": function () {
                        // Manually submit the form                        
                        var form = $('form', this);
                        $(form).submit();
                    },
                    "Cancel": function () { $(this).dialog('close'); }
                }
            });

            // Enable client side validation
            $.validator.unobtrusive.parse(this);

            // Setup the ajax submit logic
            wireUpForm(this, updateTargetId, updateUrl);
        });
        return false;
    });
});

function wireUpForm(dialog, updateTargetId, updateUrl) {
    $('form', dialog).submit(function () {

        // Do not submit if the form
        // does not pass client side validation
        if (!$(this).valid())
            return false;

        // Client side validation passed, submit the form
        // using the jQuery.ajax form
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                // Check whether the post was successful
                if (result != null) {
                    // Close the dialog 
                    $(dialog).dialog('close');

                    // Reload the updated data in the target div
                    $(updateTargetId).load(updateUrl);
                } else {
                    // Reload the dialog to show model errors                    
                    $(dialog).html(result);

                    // Enable client side validation
                    $.validator.unobtrusive.parse(dialog);

                    // Setup the ajax submit logic
                    wireUpForm(dialog, updateTargetId, updateUrl);
                }
            }
        });
        return false;
    });
}