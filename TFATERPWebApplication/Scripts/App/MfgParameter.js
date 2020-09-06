$(document).ready(function () {
    var lastsel;
    $('#list5').jqGrid({
        url: '/frmMfgBom/Getmfg_Parameter/',
        datatype: "json",      
        colNames: ['Parameter', 'DefaultValue', 'Unit', 'UpperLimit', 'LowerLimit','Value'],//, 'Action'
        colModel: [
              { name: 'Para', index: 'Para', width: 150, stype: 'text', editable: true, editoptions: { size: "20", maxlength: "30" } },
               { name: 'Default', index: 'Default', stype: 'text', editable: true, width: 150 },
                { name: 'Unit', index: 'Unit', stype: 'text', editable: true, width: 150, visible: false },
              { name: 'UpperLimit', index: 'UpperLimit', width: 150, stype: 'text', editable: true, editoptions: { size: "20", maxlength: "30" }, visible: false },
              { name: 'LowerLimit', index: 'LowerLimit', stype: 'text', editable: true, width: 150, visible: false },
              { name: 'Value', index: 'Value', stype: 'text', editable: true, width: 150, visible: false }
              //{ name: 'act', index: 'act', width: 75, sortable: false }
        ],
        pager:'#pager5',
        rowNum: 10,
        height: 'auto',
        width: '1050',
        sortname: 'Unit',
        footerrow: true,
        userDataOnFooter: true,
        sortorder: "desc",
        editurl: '/frmMfgBom/EditMfgParameter/',
        //gridComplete: function () {
        //    var ids = jQuery("#list5").jqGrid('getDataIDs');
        //    for (var i = 0; i < ids.length; i++)
        //    {
        //        var cl = ids[i];
        //        be = "<input style='height:22px;width:20px;' type='button' value='E' onclick=\"jQuery('#list5').editRow('" + cl + "');\" />";
        //        se = "<input style='height:22px;width:20px;' type='button' value='S' onclick=\"jQuery('#list5').saveRow('" + cl + "');\" />";
        //        ce = "<input style='height:22px;width:20px;' type='button' value='C' onclick=\"jQuery('#list5').restoreRow('" + cl + "');\" />";
        //        jQuery("#list5").jqGrid('setRowData', ids[i], { act: be + se + ce });
        //    }
        //},
        caption: "MateriallBom Parameter",
        rowList: [10, 20, 30, 50],
        viewrecords:true
    });
    $("#list5").jqGrid('navGrid', '#pager5',
        {
            edit: false,
            editicon:"ui-icon-pencil",
            add: false,
            addicon: "ui-icon-plus",
            save: true,
            saveicon:"ui-icon-disk",
            cancel: true,
            cancelicon:"ui-icon-cancel",
            addParams: { useFormatter: false }
        });
    jQuery("#list5").jqGrid('inlineNav', "#pager5");
});