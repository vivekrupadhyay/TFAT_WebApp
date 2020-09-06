$(document).ready(function () {

    var filtering = false;
    var thread = null;
    var MenuData;
    var tree = $('#treeReportCenter');
    var filter = $('#txtsearch');
    var sMenuJSONPath = "/ReportCentre/GetReportCenterMenu/";
    $.ajax({
        url: sMenuJSONPath,
        async: false,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            tree.tree('destroy');
            MenuData = $.parseJSON(data.Data);
            tree.tree({
                data: MenuData,
                autoOpen: false,
                autoEscape: false,
                dragAndDrop: false,
                useContextMenu: true,
                onCreateLi: function (node, $li) {
                    if (!node.hasChildren()) {
                        $li.find('.jqtree-element').prepend('<i class="fa fa-dot-circle-o"></i>');
                    }
                },
                onCanMove: function (node) {
                    if (filtering) {
                        return false;
                    } else {
                        return true;
                    };
                }
            });
        },
        error: function () {
            alert("Error with AJAX callback");
        }
    });

    tree.bind('tree.dblclick', function (event) {
        CreateGrid(event.node.name);
    });

    function CreateGrid(id) {
        $("#list").GridUnload();
        $('#list').jqGrid({
            url: "/ReportCentre/GetRecords/" + id,
            datatype: 'json',
            mtype: 'POST',
            sortable: true,
            colNames: ['Format Code', 'Description', 'Parent Form'], //, 'Last Update', 'Time'
            colModel: [{ name: 'Format Code', index: 'Format Code' },
                        { name: 'Description', index: 'Description' },
                        { name: 'Parent Form', index: 'Parent Form' }
                        //,
                        //{ name: 'Last Update', index: 'Last Update' },
                        //{ name: 'Time', index: 'Time' }
            ],
            pager: $('#pager'),
            rowNum: 100,
            rowList: [100, 200, 300],
            sortname: 'Format Code',
            height: 400,
            sortorder: 'asc',
            gridview: true,
            viewrecords: true,
            shrinkToFit: true,
            width: 650,
            onSelectRow: function (rowid, status, e) {
                var row = $('#list').jqGrid('getRowData', rowid);
                if (rowid != null) {
                    window.open("/ReportWritter/Index/" + row["Format Code"], "_self")
                }
            }
        });
        jQuery("#list").jqGrid('navGrid', "#pager",
            { edit: false, add: false, del: false, search: false, refresh: false });
    };

});
