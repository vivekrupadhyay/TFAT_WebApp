$(document).ready(function () {
    var ColN, ColM;
    var lPath = window.location.pathname;
    var arr = lPath.split("/");
    var id = arr[arr.length - 3];
    var sPath = "/Home/GetGridStructure/" + id;
    var urlpath = "/Home/GetGridData/" + id;
    var editpath = "/Home/SaveGridData/" + id;
    $.ajax({
        url: sPath, type: "POST",
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

    $(":submit").click(function () {
        var griddata = JSON.stringify($("#list").getRowData());
        $("#hdn")[0].value = griddata;
        alert(griddata);
    });

    function CreateGrid() {
        $.jgrid.nav.addtext = "Add";
        $.jgrid.nav.edittext = "Edit";
        $.jgrid.nav.deltext = "Delete";
        $.jgrid.edit.addCaption = "Add";
        $.jgrid.edit.editCaption = "Edit";
        $.jgrid.del.caption = "Delete";
        $.jgrid.del.msg = "Do you want to Delete selected record?";
        $("#list").jqGrid({
            url: urlpath,
            editurl: editpath,
            datatype: "json",
            mtype: "GET",
            sortable: true,
            colNames: ColN,
            colModel: ColM,
            pager: $("#pager"),
            rowNum: 100,
            rowList: [100],
            sortname: ColM[0].index,
            sortorder: "asc",
            viewrecords: true,
            imgpath: "/Content/Themes/Redmond/Images",
            caption: "Master",
            autowidth: true,
            ondblClickRow: function (rowid, iRow, iCol, e) {
                $("#list").editGridRow(rowid, prmGridDialog);
            },
            beforeRequest: function () {
                responsive_jqgrid($(".jqGrid"));
            }
        });
        jQuery("#list").jqGrid('navGrid', '#pager',
         { add: true, edit: true, del: true, search: true, refresh: true },
       updateDialog,
       updateDialog,
       updateDialog
       );
    };

    function responsive_jqgrid(jqgrid) {
        jqgrid.find('.ui-jqgrid').addClass('clear-margin span12').css('width', '');
        jqgrid.find('.ui-jqgrid-view').addClass('clear-margin span12').css('width', '');
        jqgrid.find('.ui-jqgrid-view > div').eq(1).addClass('clear-margin span12').css('width', '').css('min-height', '0').css('display', 'grid');
        jqgrid.find('.ui-jqgrid-view > div').eq(2).addClass('clear-margin span12').css('width', '').css('min-height', '0').css('display', 'grid');
        jqgrid.find('.ui-jqgrid-sdiv').addClass('clear-margin span12').css('width', '');
        jqgrid.find('.ui-jqgrid-pager').addClass('clear-margin span12').css('width', '');
    };

    var updateDialog = {
        url: editpath,
        closeAfterAdd: true,
        closeAfterEdit: true,
        modal: true,
        onclickSubmit: function (params) {
            var ajaxData = {};
            var list = $("#list");
            var selectedRow = list.getGridParam("selrow");
            rowData = list.getRowData(selectedRow);
            ajaxData = { CatNo: rowData.CatNo };
            return ajaxData;
        }, width: "400"
    };
});