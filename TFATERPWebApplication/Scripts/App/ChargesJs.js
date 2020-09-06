
$(document).ready(function () {
    var calculate = {
        TaxAmount: '0.00',

    };
    $("#btn1").click(function () {
        var val1 = parseInt($("#TaxAmount").val());
        var val2 = parseInt($("#txtSurCharge").val());
        var val3 = parseFloat($("#txtAdditTax").val());
        var val4 = parseFloat($("#txtCess").val());

        var Amount = parseFloat($('#txtamont').val());

        $("#txtAdditTax").val(Amount * (val2 / 100));
        //  $("#txtAdditTax") = Val(txtTaxAmt.Text) + Val(txtAddTax.Text) + Val(txtCess.Text) + Val(txtSurCharge.Text)
    });
});