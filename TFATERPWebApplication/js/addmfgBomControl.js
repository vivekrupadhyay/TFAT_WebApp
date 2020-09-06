
    $(document).ready(function () {
        $("#Unit").focusout(function () {
            var val1 = parseInt($("#Qty").val());
            var val2 = parseInt($("#Rate").val());
            var val3 = parseFloat($("#Unit").val());
            var val5 = (val1 * val2) / val3;
            $("#Value").val(val5);

        });
        $("#Qty").focusout(function () {
            var val1 = parseInt($("#Qty").val());
            var val2 = parseInt($("#Rate").val());
            var val3 = parseFloat($("#Unit").val());
            var val5 = (val1 * val2) / val3;
            $("#Value").val(val5);

        })
        $("#Rate").focusout(function () {
            var val1 = parseInt($("#Qty").val());
            var val2 = parseInt($("#Rate").val());
            var val3 = parseFloat($("#Unit").val());
            var val5 = (val1 * val2) / val3;
            $("#Value").val(val5);

        })


    });
