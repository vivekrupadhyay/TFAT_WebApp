$(document).ready(function () {
    $(function () {
        $("#tabs").tabs();
        $("#section1").tabs();
        $("#section3").tabs();
    });

    $(function () {
        $("#accordion").accordion({
            collapsible: true,
            heightStyle: "content"
        });
    });

    $(function () {
        $("input[type=submit],input[type=reset],button,input[type=button]")
        .button();
    });

    $(function () {
        $(this).bind("contextmenu", function (e) {
            return false;
        });
    });
});