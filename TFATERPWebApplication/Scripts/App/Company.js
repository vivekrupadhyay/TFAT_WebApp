$(document).ready(function () {
    $(function () {

        $("#var1").change(function () {
            var name = $("#var1 :selected").text();
            var url = 'Company/branch';
            var data1 = { "name": name };
            $.post(url, data1, function (data) {
                var items = [];
                items.push("<option value=" + 0 + ">" + "Choose Company" + "</option>");
                for (var i = 0; i < data.length; i++) {

                    items.push("<option value=" + data[i].Value + ">" + data[i].Text + "</option>");
                }
                $("#var2").html(items.join(' '));
            })
        });

        $("#var2").change(function () {
            var name = $("#var2 :selected").text();
            var url = 'Company/Perd';
            var data1 = { "name": name };
            $.post(url, data1, function (data) {
                var items = [];
                items.push("<option value=" + 0 + ">" + "Choose Branch" + "</option>");
                for (var i = 0; i < data.length; i++) {

                    items.push("<option value=" + data[i].Value + ">" + data[i].Text + "</option>");
                }
                $("#var3").html(items.join(' '));
            })
        });

    });
});