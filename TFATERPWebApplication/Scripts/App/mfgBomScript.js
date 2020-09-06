﻿$(document).ready(function () {
    var lPath = window.location.pathname;
    var arr = lPath.split("/");
    var id = arr[arr.length - 1];
    $("#list").jqGrid({
        url: '/frmMfgBom/GetRecords/',
        datatype: "json",
        //contentType: "application/json; charset-utf-8",
        type: 'POST',
        //mtype: 'GET',
        colNames: ["Sr.No.","Time From","Time To","Mfg.Qty Unit-1","Avg.Conv","Mfg.Qty Unit-2","Std.Cycle Time","Std.PartWT","Std.MfgHr","Operator"],
        colModel: [
            { name: "SrNo", index: 'SrNo', sortable: true, editable: true, editoptions: { readonly: false, size: 0 }, hidden: false, visible: true },//editoptions: { readonly: true, size: 0 }, hidden: false, visible: true
            { name: "TimeFrom", index: 'TimeFrom', sortable: true, editable: true, validate: true, editrules: { required: true }, editoptions: { dataInit: function (elem) { NameSearch(elem) } } },//, formoptions: {rowpos:1,colpos:1}
            { name: "TimeTo", index: 'TimeTo', align: "right", sortable: true, editable: true, edittype: 'text', validate: true, editrules: { required: true } },
            { name: "Mfg.Qty Unit-1", index: 'Mfg.Qty Unit-1', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 4, colpos: 1 } },
            { name: "Avg.Conv", index: 'Avg.Conv', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 2 } },
            { name: "Mfg.Qty Unit-2", index: 'Mfg.Qty Unit-2', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 3 } },
            { name: "Std.Cycle Time", index: 'Std.Cycle Time', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 4 } },
            { name: "Std.PartWT", index: 'Std.PartWT', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 5, colpos: 1 } },// formoptions: { rowpos: 8, colpos: 1 } 
           
            { name: "Std.MfgHr", index: 'Std.MfgHr', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },//, formoptions: { rowpos: 8, colpos: 3 }
            { name: "Operator", index: 'Operator', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 6, colpos: 1 } }
            
        ],
        pager: jQuery('#pager'),
        rowNum: 10,
        zIndex: 100,
        closeOnEscap: true,
        closeAfterAdd: true,
        closeAfterEdit: true,
        rownumbers: true,
        rowList: [5, 10, 20, 50, 100],
        height: 'auto',
        width: '900',
        overflow: 'auto',
        addParams: { useFormatter: true },
        viewrecords: true,
        multiselect: true,
        // loadonce: true,
        editurl: '/frmMfgBom/EditRecords/',
        // type: 'POST',
        caption: "FrmMfgBOM",
        datatype: 'json',
        //reloadAfterSubmit: true,
        footerrow: true,
        userDataOnFooter: true,
        afterSubmit: function () {
            $(this).jqGrid("setGridParam", { datatype: 'json' });
            return [true];


            afterEditCell: $(document).ready(function (rowid, cellname, value, iRow, iCol) {
                var select = $(item).find('td.edit-cell select');
                $(item).find('td.edit-cell select option').each(function () {
                    var option = $(this);
                    var optionId = $(this).val();
                    $(lookupData.ListingCategory).each(function () {
                        if (this.Id == optionId) {
                            if (this.OnlineName != $(item).getCell(rowid, 'OnlineName')) {
                                option.remove();
                                return false;
                            }
                        }
                    });
                });
            });

        }
    });
    jQuery("#list").jqGrid('navGrid', '#pager', {
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
    }, {}, { width: 600 }, { top: 0 }, { height: 'auto' }
    );
    $.extend($.jgrid.edit, {
        beforeSubmit: function () {
            $(this).jqGrid("setGridParam", {// datatype: "json" 
            });
            return [true, "", ""];
        }
    });
});