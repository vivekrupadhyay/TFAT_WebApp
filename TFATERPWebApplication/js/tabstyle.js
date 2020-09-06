$(document).ready(function () {
    var $tabs = $("#tabs");
    $tabs.tabs();

    var $tabs = $('#tabs').tabs();
    //var selected = $tabs.tabs('option', 'active');
    //$(".selector").tabs("disable");
    var m_flag = $(location).attr('search');

    switch (m_flag) {
        case "?AB":
            $("#m_tb1").hide(); $("#tabs-1").hide();
            $("#m_tb2").hide(); $("#tabs-2").hide();
            $("#tabs").tabs("refresh");
            break;
        case "?BC":
            $("#m_tb3").hide(); $("#tabs-3").hide();
            $("#m_tb4").hide(); $("#tabs-4").hide();
            $("#tabs").tabs("refresh");
            break;
        case "?CD":
            $("#m_tb5").hide(); $("#tabs-5").hide();
            $("#m_tb6").hide(); $("#tabs-6").hide();
            $("#tabs").tabs("refresh");
            break;
        case "?DE":
            $("#m_tb7").hide(); $("#tabs-7").hide();
            $("#m_tb8").hide(); $("#tabs-8").hide();
            $("#tabs").tabs("refresh");
            break;
        default:
            $("#m_tb9").hide(); $("#tabs-9").hide();
            $("#tabs").tabs("refresh");
            break;
    }
});

