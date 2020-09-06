$(function () {
    $("#DDL_MenuCode_T").change(function () {
        var name = $("#DDL_MenuCode_T :selected").text();  //if user select the tournament 
        var url = 'frmmfgBom/drop';
        var data1 = { "name": name };
        $.post(url, data1, function (data) {    //ajax call
            var items = [];
            items.push("<option value=" + 0 + ">" + "Select" + "</option>"); //first item
            for (var i = 0; i < data.length; i++) {
                items.push("<option value=" + data[i].Value + ">" + data[i].Text + "</option>");
            }                                         //all data from the team table push into array
            $("#var2").html(items.join(' '));
        })                                            //array object bind to dropdown list
    });
});