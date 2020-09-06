$(document).ready(function () {
    var lPath = window.location.pathname;
    var marr = lPath.split('/');
    var id = marr[marr.length - 1];

    $('#list').jqgrid({
        url: '/bankpayment/populatefromdb/' + id,
        colnames: ['sno', 'branch', 'code', 'bankcode', 'subldgr', 'debit', 'credit', 'costcenter', 'profitcenter', 'cheque', 'narr'],
        colmodel: [
            { name: 'Sno', index: '1' },
            { name: 'Branch', index: '2', sortable: false, editable: true, edittype: 'text' },
            { name: 'Code', index: '3', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'Bankcode', index: '4', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'SubLdgr', index: '5', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'Debit', index: '6', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'Credit', index: '7', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'CostCenter', index: '8', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'ProfitCenter', index: '9', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'Cheque', index: '10', align: 'right', sortable: false, editable: true, edittype: 'text' },
            { name: 'Narr', index: '11', align: 'right', sortable: false, editable: true }
        ],
        rownum: 5,
        rownumbers: true,
        rowlist: [5, 10, 15],
        height: '200',
        width: 'auto',
        datatype: 'json',
        mtype: 'post',
        gridview: true,
        viewrecords: true,
        caption: 'bank payment',
        pager: $('#pager')
    });
    $('#list').jqgrid('navgrid', '#pager', { edit: true, add: true, del: true });
});