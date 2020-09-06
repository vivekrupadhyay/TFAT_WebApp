$(document).ready(function () {
    var lastsel;
    $('#list2').jqGrid({
        url: '/frmMfgBom/mfg_TimeLoss/',
        datatype: "json",
        colNames: ["Sr", "Time-Form", "Time-To", "ReasonForTime-Loss"],
        colModel: [
            { name: "Sno", index: 'Sno', sortable: true, editable: false, visible: false },
            {
                name: "TimeForm", index: 'TimeForm', sortable: true, editable: true, sorttype: "date", edittype: 'text',editoptions: {
                    dataInit: function (element) {
                       // alert("hi");
                        $(element).datepicker({
                            id: 'jqg1_TimeForm',
                            dateFormat: 'M/d/yy',                        
                            maxDate: new Date(2020, 0, 1),
                            showOn: 'focus'
                        });
                    }
                }
            },
            { name: "TimeTo", index: 'TimeTo', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: {

                    dataInit: function (element) {
                        //alert("hi");
                        $(element).datepicker({
                            id: 'jqg1_TimeTo',
                            dateFormat: 'M/d/yy',
                            maxDate: new Date(2020, 0, 1),
                            showOn: 'focus'
                        });
                    }
                }
            },
            { name: "ReasonCode", index: 'ReasonCode', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 4, colpos: 1 } },
        ],
        pager: '#pager2',
        rowNum: 10,
        closeOnEscap: true,
        closeAfterAdd: true,
        closeAfterEdit: true,
        rownumbers: true,
        sortname: 'Unit',
        sortorder: "desc",
        height: 'auto',
        width: '540',
        footerrow: true,
        userDataOnFooter: true,
        editurl: '/frmMfgBom/Editmfg_TimeLoss/',
        caption: "MateriallBomTimeLoss",
        rowList: [10, 20, 30, 50],
        viewrecords: true
    });
    $("#list2").jqGrid('navGrid', '#pager2',
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
    jQuery("#list2").jqGrid('inlineNav', "#pager2");
  
});