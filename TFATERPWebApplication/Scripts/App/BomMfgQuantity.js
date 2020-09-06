$(document).ready(function () {
    var lastsel;
    $('#list').jqGrid({
        url: '/frmMfgBom/Getmfg_Quantity/',
        datatype: "json",
        colNames: ["Sr.", "Serials", "Std-Mfg(KGS)", "Gross Wt.", "Net Wt.", "Start-Time", "End-Time", "Mfg-Qty(KGS)", "Variance", "Operation"],
        colModel: [
            { name: "Sno", index: 'Sno', sortable: true, editable: true, visible: false },
             { name: "Srl", index: 'Srl', sortable: true, editable: true },
            { name: "Qty", index: 'Qty', sortable: true, editable: true },
            { name: "GrossWt", index: 'GrossWt', sortable: true, editable: true },
            { name: "NetWt", index: 'NetWt', sortable: true, editable: true },
            {
                name: "TimeFrom", index: 'TimeFrom', sortable: true, editable: true, validate: true, sorttype: "date", editoptions: {
                    dataInit: function (element) {
                        // alert("hi");
                        $(element).datepicker({
                            id: 'jqg6_TimeFrom',
                            dateFormat: 'M/d/yy',
                            maxDate: new Date(2020, 0, 1),
                            showOn: 'focus'
                        });
                    }
                }
            },
            {
                name: "TimeTo", index: 'TimeTo', align: "right", sortable: true, editable: true, edittype: 'text', sorttype: "date", editoptions: {

                    dataInit: function (element) {
                        //alert("hi");
                        $(element).datepicker({
                            id: 'jqg6_TimeTo',
                            dateFormat: 'M/d/yy',
                            maxDate: new Date(2020, 0, 1),
                            showOn: 'focus'
                        });
                    }
                }
            },
            { name: "Qty2", index: 'Qty2', align: "right", sortable: true, editable: true, edittype: 'text' },
            { name: "Type", index: 'Type', align: "right", sortable: true, editable: true, edittype: 'text' },
            {name: "Code", index: 'Code', align: "right", sortable: true, editable: true,
                editoptions: {
                    dataInit: function (element) {
                        window.setTimeout(function () {
                            $(element).autocomplete({
                                id: 'AutoComplete',
                                source: function (request, response) {
                                    this.xhr = $.ajax({
                                        url: '/frmMfgBom/Getmfg_Quantity/',
                                        data: request,
                                        dataType: "json",
                                        success: function (data) {
                                            alert(data);
                                            response(data);
                                        },
                                        error: function (model, response, options) {
                                            alert("Error");
                                            response([]);
                                        }
                                    });
                                },
                                autoFocus: true
                            });
                        }, 100);
                    }
                }
            }
        ],

        pager: '#pager',
        closeOnEscap: true,
        closeAfterAdd: true,
        closeAfterEdit: true,
        rownumbers: true,
        rowNum: 10,
        sortname: 'Unit',
        sortorder: "desc",
        height: 'auto',
        width: '900',
        footerrow: true,
        userDataOnFooter: true,
        editurl: '/frmMfgBom/Getmfg_Quantity/',
        caption: "MateriallBomRejections",
        rowList: [10, 20, 30, 50],
        viewrecords: true,
        onSelectRow: editRow,
        loadonce: true,
    });

    var lastSelection;

    function editRow(id) {
        if (id && id !== lastSelection) {
            var grid = $("#list");
            grid.jqGrid('restoreRow', lastSelection);
            grid.jqGrid('editRow', id, { keys: true, focusField: 4 });
            lastSelection = id;
        }
    }

    $("#list").jqGrid('navGrid', '#pager',
         {
             edit: false,
             editicon: "ui-icon-pencil",
             add: false,
             addicon: "ui-icon-plus",
             save: true,
             saveicon: "ui-icon-disk",
             cancel: true,
             cancelicon: "ui-icon-cancel",
             addParams: { useFormatter: false }
         });
    jQuery("#list").jqGrid('inlineNav', "#pager");
});



//$(document).ready(function () {
//    var lastsel;
//    $('#list').jqGrid({
//        url: '/frmMfgBom/Getmfg_Quantity/',
//        datatype: "json",
//        colNames: ["Sr.", "Serials", "Std-Mfg(KGS)", "Gross Wt.", "Net Wt.", "Start-Time", "End-Time","Mfg-Qty(KGS)","Variance","Operation"],
//        colModel: [
//            { name: "Sno", index: 'Sno', sortable: true, editable: true },//editoptions: { readonly: true, size: 0 }, hidden: false, visible: true
//            { name: "Srl", index: 'Srl', sortable: true, editable: true },//validate: true, editrules: { required: true } editoptions: { dataInit: function (elem) { NameSearch(elem) } }
//            { name: "Qty", index: 'Qty', sortable: true, editable: true },//, validate: true, editrules: { required: true }
//            { name: "GrossWt", index: 'GrossWt', sortable: true, editable: true },//, validate: true, editrules: { required: true }, editoptions: { dataInit: function (elem) { NameSearch(elem) } }
//            { name: "NetWt", index: 'NetWt', sortable: true, editable: true },//, validate: true, editrules: { required: true }, formoptions: {rowpos:1,colpos:1}, editoptions: { dataInit: function (elem) { NameSearch(elem) } } 
//            { name: "TimeFrom", index: 'TimeFrom', sortable: true, editable: true, validate: true, sorttype: "date" },//, editrules: { required: true }, editoptions: { dataInit: function (elem) { NameSearch(elem) } } 
//            { name: "TimeTo", index: 'TimeTo', align: "right", sortable: true, editable: true, edittype: 'text', sorttype: "date" },//, validate: true, editrules: { required: true } 
//            { name: "Qty2", index: 'Qty2', align: "right", sortable: true, editable: true, edittype: 'text' },//, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 1 } 
//            { name: "Type", index: 'Type', align: "right", sortable: true, editable: true, edittype: 'text' },//, editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 2 }
//            {
//                name: "Code", index: 'Code', align: "right", sortable: true, editable: true,
//                editoptions: {
//                    // dataInit is the client-side event that fires upon initializing the toolbar search field for a column
//                    // use it to place a third party control to customize the toolbar
//                    dataInit: function (element) {
//                        window.setTimeout(function () {
                           
//                            $(element).autocomplete({
//                                id: 'AutoComplete',
//                                source: function (request, response) {
                                    
//                                    this.xhr = $.ajax({
                                        
//                                        url: '/frmMfgBom/Getmfg_Quantity/',
//                                        data: request,
//                                        dataType: "json",
//                                        success: function (data) {
//                                            alert(data);

//                                            response(data);
//                                        },
//                                        error: function (model, response, options) {
//                                            alert("Error");
//                                            response([]);
//                                        }
//                                    });
//                                },
//                                autoFocus: true
//                            });
//                        }, 100);
//                    }
//                }
//            }
//        ],
       
//        pager: '#pager',
//        closeOnEscap: true,
//        closeAfterAdd: true,
//        closeAfterEdit: true,
//        rownumbers: true,
//        rowNum: 20,
//        sortname: 'Unit',
//        sortorder: "desc",
//        height: 'auto',
//        width: '900',
//        footerrow: true,
//        userDataOnFooter: true,
//        editurl: '/frmMfgBom/Getmfg_Quantity/',
//        caption: "MateriallBomRejections",
//        rowList: [10, 20, 30, 50],
//        viewrecords: true,
//        onSelectRow: editRow,
//        loadonce : true,
//    });

//var lastSelection;

//function editRow(id) {
//    if (id && id !== lastSelection) {
//        var grid = $("#list");
//        grid.jqGrid('restoreRow',lastSelection);
//        grid.jqGrid('editRow',id, {keys:true, focusField: 4});
//        lastSelection = id;
//    }
//}

//    $("#list").jqGrid('navGrid', '#pager',
//         {
//             edit: false,
//             editicon: "ui-icon-pencil",
//             add: false,
//             addicon: "ui-icon-plus",
//             save: true,
//             saveicon: "ui-icon-disk",
//             cancel: true,
//             cancelicon: "ui-icon-cancel",
//             addParams: { useFormatter: false }
//         });
//    jQuery("#list").jqGrid('inlineNav', "#pager");
//});
