$(document).ready(function () {
    var lPath = window.location.pathname;
    var arr = lPath.split("/");
    var id = arr[arr.length - 1];
    $("#list3").jqGrid({
        url: '/frmMfgBom/GetRecords/',
        datatype: "json",
        //contentType: "application/json; charset-utf-8",
        type: 'POST',
        //mtype: 'GET',
        colNames: ["Sno.", "ProductCode", "Product-Description","Cur-stock", "Substitute", "Partial?", "Mfg.Qty", "Consumed", "Wastage", "Loss", "Store", "Rate", "Unit", "RatePer", "Value", "Narration"],
        colModel: [
            { name: "Sno", index: 'Sno', sortable: true, editable: true, editoptions: { readonly: false, size: 0 }, hidden: false, visible: true },//editoptions: { readonly: true, size: 0 }, hidden: false, visible: true
            { name: "Code", index: 'Code', sortable: true, editable: true, validate: true, editrules: { required: true }, editoptions: { dataInit: function (elem) { NameSearch(elem) } } },//, formoptions: {rowpos:1,colpos:1}
            { name: "Name", index: 'Name', align: "right", sortable: true, editable: true, edittype: 'text', validate: true, editrules: { required: true } },
            { name: "Stock", index: 'Stock', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 4, colpos: 1 } },
            { name: "Substitute", index: 'Substitute', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 2 } },
            { name: "Partial", index: 'Partial', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 3 } },
            { name: "MfgQty", index: 'MfgQty', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 4 } },
            { name: "Qty", index: 'Qty', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 5, colpos: 1 } },// formoptions: { rowpos: 8, colpos: 1 } 

            { name: "Wastage", index: 'Wastage', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },//, formoptions: { rowpos: 8, colpos: 3 }
            { name: "Loss", index: 'Loss', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 6, colpos: 1 } },
            { name: "Store", index: 'Store', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },
            { name: "Rate", index: 'Rate', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },
            { name: "Unit", index: 'Unit', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },
            { name: "RatePer", index: 'RatePer', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },
            { name: "Value", index: 'Value', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },
            { name: "Narration", index: 'Narration', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } }
        ],
        pager: jQuery('#pager3'),
        rowNum: 10,
        zIndex: 100,
        closeOnEscap: true,
        closeAfterAdd: false,
        closeAfterEdit: false,
        rownumbers: true,
        rowList: [5, 10, 20, 50, 100],
        height: 'auto',
        width: '1000',
        overflow: 'auto',
        addParams: { useFormatter: true },
        viewrecords: true,
        multiselect: true,
        // loadonce: true,
        editurl: '/frmMfgBom/EditRecords/',
        // type: 'POST',
        caption: "MateriallDetails",
        datatype: 'json',
        //reloadAfterSubmit: true,
        footerrow: true,
        userDataOnFooter: true,
        afterSubmit: function () {
            $(this).jqGrid("setGridParam", { datatype: 'json' });
            return [true];


            afterEditCell: $(document).ready(function (rowid, cellname, value, iRow, iCol) {
                var select = $(item).find('td.edit-cell select');
             //   alert(optionId);
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
    jQuery("#list3").jqGrid('navGrid', '#pager3', {
        edit: false,
        add: false,
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
