(function ($) {
    // Shell for your plugin code
    $.fn.tabmenu = function () {
        // Plugin code
        return this.each(function () {
            $(this).addClass("ui-tabs ui-widget ui-widget-content ui-corner-all");
            $(this).find("ul").addClass("ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all");
            $(this).find("li")
            .addClass("ui-state-default ui-corner-top")
            .one('mouseenter', function () {
                $(this).addClass("ui-state-hover");
            }, 'fast')
            .one('mouseexit', function () {
                $(this).removeClass("ui-state-hover");
            }, 'fast');
        });
    }
})(jQuery);