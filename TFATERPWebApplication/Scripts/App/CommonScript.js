
$(document).ready(function () {
    $('#Code').focusout(function () {
        var mDatda = '';
        $.ajax({
           // url: "/GetCodeName?codeName=" + $('#Code').val() + "&mPara=C",
            url: "/Sales/GetCodeNames?codeName=" + $('#Code').val() + "&mPara=C",
            type: 'post',
            data: {
                Text: $('#Code').val()
            },
            success: function (_result) {
                $("#Name").val(_result);
                mDatda = _result;
            }
        });

        if ($("#Code") === null) {
            $('#Name').attr("disabled", true);
        }
        else {
            $('#Name').attr("disabled", false);
        }
        $("#Name").val(mDatda);
    });

    $('#Name').focusout(function () {
        var mDatda = '';
        $.ajax({
           // url: "/GetCodeName?codeName=" + $('#Name').val() + "&mPara=N",
            url: "/Sales/GetCodeNames?codeName=" + $('#Name').val() + "&mPara=N",
            type: 'post',
            data: {
                Text: $('#Name').val()
            },
            success: function (_result) {
                $("#Code").val(_result);
                mDatda = _result;
            }
        });
        if ($("#Name") === null) {
            $('#Code').attr("disabled", true);
        }
        else {
            $('#Code').attr("disabled", false);
        }
        $("#Code").val(mDatda);

    });

});