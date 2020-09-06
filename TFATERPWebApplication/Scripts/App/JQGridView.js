$(document).ready(function () {
    var lPath = window.location.pathname;
    var arr = lPath.split("/");
    var id = arr[arr.length - 1];
    $("#list").jqGrid({
        url: '/Sales/GetRecords/',
        datatype: "json",
        //contentType: "application/json; charset-utf-8",
        type: 'POST',
        //mtype: 'GET',
        colNames: ["Sr No.", "ProductCode", "ProductDescription", "Quantity", "Unit", "Qty2", "Unit2", "Rate", "Per", " RatePer", "Disc%", "Disc.Amt", "TotalDisc", "Value", " Narration", "Order", "VenderID"],
        colModel: [
            { name: "Sno", index: 'Sno', sortable: true, editable: true, editoptions: { readonly: false, size: 0 }, hidden: false, visible: true },//editoptions: { readonly: true, size: 0 }, hidden: false, visible: true
            { name: "Code", index: 'Code', sortable: true, editable: true, validate: true, editrules: { required: true }, editoptions: { dataInit: function (elem) { NameSearch(elem) } } },//, formoptions: {rowpos:1,colpos:1}
            { name: "DCCode", index: 'DCCode', align: "right", sortable: true, editable: true, edittype: 'text', validate: true, editrules: { required: true } },
            { name: "Qty", index: 'Qty', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 4, colpos: 1 } },
            { name: "Unit", index: 'Unit', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 2 } },
            { name: "Qty2", index: 'Qty2', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 3 } },
            { name: "Unit2", index: 'Unit2', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 4, colpos: 4 } },
            { name: "Rate", index: 'Rate', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 5, colpos: 1 } },// formoptions: { rowpos: 8, colpos: 1 } 
            {
                name: "Per", index: 'Per', align: "right", sortable: true, editable: true, edittype: 'select',formatter: 'select', formoptions: { rowpos: 5, colpos: 2 },
                editoptions: { value: getAllSelectOptions() }
            },// multiple: true,
            { name: "RatePer", index: 'RatePer', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 5, colpos: 3 } },//, formoptions: { rowpos: 8, colpos: 3 }
            { name: "Disc", index: 'Disc', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true }, formoptions: { rowpos: 6, colpos: 1 } },
            { name: "DiscAmt", index: 'DiscAmt', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 6, colpos: 2 } },
            { name: "TotalDisc", index: 'TotalDisc', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true } },
            { name: "Value", index: 'Value', align: "right", sortable: true, editable: true, edittype: 'text', editoptions: { size: 10 }, editrules: { required: true }, formoptions: { rowpos: 6, colpos: 3 } },
            { name: "Narration", index: 'Narration', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true } },
            { name: "Order", index: 'Order', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true } },
            { name: "VenderID", index: 'VenderID', align: "right", sortable: true, editable: true, edittype: 'text', editrules: { required: true } }
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
        width: '936',
        overflow: 'auto',
        addParams: { useFormatter: true },
        viewrecords: true,
        multiselect: true,
        // loadonce: true,
        editurl: '/Sales/EditRecords/',
        // type: 'POST',
        caption: "Sales",
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
   
    $('.ui-pg-button').on('click', function (ev) {
        //ClickEventId = this.id;   
    });
    function NameSearch(elem) {
        //   debugger;
        $(elem).autocomplete({
            source: '/Sales/AutocompleteBranch',
            dataType: "json",
            minLength: 3, autosearch: true,
            select: function (event, ui) {
                $("#elem").val(ui.item.value);
                $(elem).focus().trigger({ type: 'keypress', charCode: 13 });
            }
        })//$(elem).autocomplete
        $(elem).keypress(function (e) {
            if (!e) e = window.event;
            if (e.keyCode == '13') {
                setTimeout(function () { $(elem).autocomplete('close'); }, 500);
                return false;
            }
        })//$(elem).keypress(function (e){    
    }
    //---------------- Populate DropDown---------------------------

    function getAllSelectOptions() {
        var appenddata = '';
        $.ajax({
            url: '/Sales/Category',
            type: 'post',
            datatype: 'json',
            success: function (result) {
                $.each(result, function (key, value) {
                    if (value != 'undefined') {
                        appenddata = appenddata + "'" + key + "':'" + value + "',";
                    }
                 
                });
             // alert(appenddata);
               return { '0': 'Select', '000342': 'dfhgn', '000655': 'dfhgn657567', '001': 'TFAT WEB ERP Demo', '002': 'TFAT WEB ERP ', '02299': 'Suchan software', '02324': 'new delhi', '087': 'fgh', '08852': 'software comp', '100636': 'taftcompany', '1224': 'hhhjgk', '122457': 'hhhjgk', '1224sd': 'hhhjgk', '17': 'tfatnew', '2': 'company new', '23': 'fgvfg', '231': 'gdsfg', '32': 'dhrt', '33': 'gdgdsg', '33767': 'gdgdsgdfgrseg', '4': 'test ', '457547': 'hgfjh', '53': 'cghnfghn', '53gfh': 'fgjh', '565456': 'Suchan', '56765': 'fghfghj', '6003': 'company', '6555': 'gdsfg456', '664': 'fghjfgyj', '6646': 'fghjfgyj', '76': 'tfatcompanynew', '786': 'tfatnewcompany', '789': 'cvncgn', '80036': 'company', 'ddf': 'dipti sky', 'ddfs': 'diptinew sky', 'g': 'test new', 'HHH': 'Harshal Pvt ltd' };
             //  return appenddata 
              //  return (appenddata = "{'" + appenddata.substring(1, appenddata.length - 1) + "}");
            }

        });
       
    }



    $('#txtCode_Master1').focusout(function () {
       
        var mDatda = {};
        $.ajax({
            url: "/Sales/XGetCalData?mPrcType=" + $('#txtCode_Master1').val() + "&mAmount=" + $('#txtamont').val(),
            type: 'post',
            data: 'local',
            success: function (_result) {
                mDatda = _result.split('~');
                $('#TaxAmount').val(mDatda[0]);
                $('#txtAdditTax').val(mDatda[1]);
                $('#txtSurCharge').val(mDatda[2]);
                $('#txtCess').val(mDatda[3]);
            }
        });
    });
});

