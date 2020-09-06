$(document).ready(function () {
    var lastsel;
    $('#list1').jqGrid({
        url: '/frmMfgBom/GetMfg_Rejection/',
        datatype: "json",
        colNames: ["Sr.", "Start-Time", "End-Time", "Resion for Rejection", "Rej.Qty.Unit1"],
        colModel: [
            { name: "Sno", index: 'Sno', sortable: true, editable: false , visible: false },
            {name: "Start-Time", index: 'Start-Time', sortable: true, editable: true, editoptions: {
                    dataInit: function (element) {
                        $(element).datepicker({
                            id: 'jqg1_Start-Time',
                            dateFormat: 'M/d/yy',
                            maxDate: new Date(2020, 0, 1),
                            showOn: 'focus'
                        });
                    }
                }
            },
            { name: "End-Time", index: 'End-Time', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: {
                    dataInit: function (element) {
                        $(element).datepicker({
                            id: 'jqg1_End-Time',
                            dateFormat: 'M/d/yy',
                            maxDate: new Date(2020, 0, 1),
                            showOn: 'focus'
                        });
                    }
                }
            },
            { name: "ReasonCode", index: 'ReasonCode', align: "right", sortable: true, editable: true, edittype: 'text' },
            { name: "Qty", index: 'Qty', align: "right", sortable: true, editable: true, edittype: 'text' },
        ],
        pager: '#pager1',
        closeOnEscap: true,
        closeAfterAdd: true,
        closeAfterEdit: true,
        rownumbers: true,
        rowNum: 10,
        sortname: 'Unit',
        sortorder: "desc",
        height: 'auto',
        width: '550',
        footerrow: true,
        userDataOnFooter: true,
        editurl: '/frmMfgBom/Editmfg_MfgRejection/',
        caption: "MateriallBomRejections",
        rowList: [10, 20, 30, 50],
        viewrecords: true
    });
    $("#list1").jqGrid('navGrid', '#pager1',
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
    jQuery("#list1").jqGrid('inlineNav', "#pager1");
});