
$(document).ready(function () {
    var lPath = window.location.pathname;
    var arr = lPath.split("/");
    var id = arr[arr.length - 1];
    var initGrids= [false,false];
    $('#tabs').tabs({
        show: function (event, ui) {
            if (ui.index === 0 && initGrids[ui.index] === false) {

                $("#list1").jqGrid({
                    url: "/Sales/PopulateFromDB/" + id,
                    datatype: "json",
                    contentType: "application/json; charset-utf-8",
                    mtype: "GET",
                    colNames: ["Sr No.", "ProductCode", "ProductDescription", "Quantity", "Unit", "Qty2", "Unit2", "Rate", " RatePer", "Disc%", "Disc.Amt"],
                    colModel: [
                        { name: "Sno", sortable: true },
                        { name: "ProductCode", sortable: true },
                        { name: "ProductDescription", align: "right", sortable: true },
                        { name: "Quantity", align: "right", sortable: true },
                        { name: "Unit", align: "right", sortable: true },
                        { name: "Qty2", align: "right", sortable: false },
                        { name: "Unit2", align: "right", sortable: false },
                        { name: "Rate", align: "right", sortable: false },
                        { name: "RatePer", align: "right", sortable: false },
                        { name: "Disc%", align: "right", sortable: false },
                        { name: "Disc.Amt", align: "right", sortable: false }

                    ],
                    pager: "#pager",
                    rowNum: 10,
                    rownumbers: true,
                    rowList: [5, 10, 15],
                    height: 'auto',
                    width: '927',
                    loadonce: true,

                    caption: "Sales",
                    editurl: '/Sales/Edit/'
                });

                jQuery("#list1").jqGrid('navGrid', '#pager', {
                    edit: true,
                    add: true,
                    del: true,
                    search: true,
                    refresh: true,
                    searchtext: "Search",
                    addtext: "Add",
                    edittext: "Edit",
                    deltext: "Delete",
                    refreshtext: "Refresh"
                }

               );
            }
            else if (ui.index === 1 && initGrids[ui.index] === false) {
                $("#list2").jqGrid({
                    url: "/Sales/PopulateFromDB/" + id,
                    datatype: "json",
                    contentType: "application/json; charset-utf-8",
                    mtype: "GET",
                    colNames: ["Sr No.", "ProductCode", "ProductDescription", "Quantity", "Unit", "Qty2", "Unit2", "Rate", " RatePer", "Disc%", "Disc.Amt"],
                    colModel: [
                        { name: "Sno", sortable: true },
                        { name: "ProductCode", sortable: true },
                        { name: "ProductDescription", align: "right", sortable: true },
                        { name: "Quantity", align: "right", sortable: true },
                        { name: "Unit", align: "right", sortable: true },
                        { name: "Qty2", align: "right", sortable: false },
                        { name: "Unit2", align: "right", sortable: false },
                        { name: "Rate", align: "right", sortable: false },
                        { name: "RatePer", align: "right", sortable: false },
                        { name: "Disc%", align: "right", sortable: false },
                        { name: "Disc.Amt", align: "right", sortable: false }

                    ],
                    pager: "#pager",
                    rowNum: 10,
                    rownumbers: true,
                    rowList: [5, 10, 15],
                    height: 'auto',
                    width: '927',
                    loadonce: true,

                    caption: "Sales",
                    editurl: '/Sales/Edit/'
                });

                jQuery("#list2").jqGrid('navGrid', '#pager', {
                    edit: true,
                    add: true,
                    del: true,
                    search: true,
                    refresh: true,
                    searchtext: "Search",
                    addtext: "Add",
                    edittext: "Edit",
                    deltext: "Delete",
                    refreshtext: "Refresh"
                }
               );
            }
        }
    });
$('.ui-pg-button').on('click', function (ev) {

            ClickEventId = this.id;

        });
    });


//});

