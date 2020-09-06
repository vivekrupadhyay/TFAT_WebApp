$(document).ready(function () {
    var ColN, ColM;
    var lPath = window.location.pathname;
    var arr = lPath.split("/");
    var id = arr[arr.length - 1];
    var sPath = "/ViewList/GetGridStructureRecords/" + id;
    var urlpath = "/ViewList/GetRecords/" + id;
    $.ajax({
        url: sPath,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var obj = $.parseJSON(data);
            ColN = obj[0].split(",");
            ColM = obj[1];
            CreateGrid();
        },
        error: function () {
            alert("Error with AJAX callback");
        }
    });

    function CreateGrid() {
        $('#list').jqGrid({
            url: urlpath,
            datatype: 'json',
            mtype: 'POST',
            sortable: true,
            colNames: ColN,
            colModel: ColM,
            pager: $('#pager'),
            rowNum: 20,
            rowList: [5, 10, 20, 50],
            sortname: 'Code',
            height:450,
            sortorder: 'asc',
            gridview: true,
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true,
            beforeRequest: function () {
                responsive_jqgrid($(".jqGrid"));
            }
        });
        jQuery("#list").jqGrid('navGrid', "#pager",
            { edit: false, add: false, del: false, search: true, refresh: false, searchtext: "Search" });
    };

    function responsive_jqgrid(jqgrid) {
        jqgrid.find('.ui-jqgrid').addClass('clear-margin span12').css('width', '');
        jqgrid.find('.ui-jqgrid-view').addClass('clear-margin span12').css('width', '');
        jqgrid.find('.ui-jqgrid-view > div').eq(1).addClass('clear-margin span12').css('width', '').css('min-height', '0').css('display', 'grid');
        jqgrid.find('.ui-jqgrid-view > div').eq(2).addClass('clear-margin span12').css('width', '').css('min-height', '0').css('display', 'grid');
        jqgrid.find('.ui-jqgrid-sdiv').addClass('clear-margin span12').css('width', '');
        jqgrid.find('.ui-jqgrid-pager').addClass('clear-margin span12').css('width', '');
    };
});