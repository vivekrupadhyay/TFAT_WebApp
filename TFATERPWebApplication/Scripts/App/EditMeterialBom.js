

    function getSelectedRow() {
        var appenddata = '';
       
        var rowId = $("#list3").jqGrid('getGridParam', 'selrow');
        var rowData = jQuery("#list3").getRowData(rowId);
        var colData = rowData['Sno'];

        $.ajax({
            url: "/frmMfgBom/Edit?Id=" + colData,
            type: 'Get',
            datatype: 'json',
            success: function (result) {
                // alert(result);
                $("#dialog1").empty();
                $("#dialog1").html(result);
                $("#dialog1").dialog("open");


            }

        });

    }
