$(document).ready(function () {
    var $tabs = $("#tabs");
    $tabs.tabs();

    var $tabs = $('#tabs1').tabs({ active: 3 });
    //var selected = $tabs.tabs('option', 'active');
    //$(".selector").tabs("disable");m_tb1
    var m_flag = $(location).attr('search');

    switch (m_flag) {
        case "?AB":
            $("#m_tb11").hide(); $("#tabs-11").hide();
            $("#m_tb21").hide(); $("#tabs-21").hide();
            $("#tabs1").tabs("refresh");
            break;
        case "?BC":
            $("#m_tb31").hide(); $("#tabs-31").hide();
            $("#m_tb41").hide(); $("#tabs-41").hide();
            $("#tabs1").tabs("refresh");
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