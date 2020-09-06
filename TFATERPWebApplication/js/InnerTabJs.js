$(document).ready(function () {

    $(".tab_content").hide();
    $(".tab_content:first").show();

    $("ul.myTabs li").click(function () {
        $("ul.myTabs li").removeClass("active");
        $(this).addClass("active");
        $(".tab_content").hide();
        var activeTab = $(this).attr("rel");
        $("#" + activeTab).fadeIn();
    });
});