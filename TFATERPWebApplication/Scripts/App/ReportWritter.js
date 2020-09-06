$(document).ready(function () {
    var ColN, ColM;
    var lPath = window.location.pathname;
    var arr = lPath.split("/");
    var id = arr[arr.length - 1];
    var sPath = "/ReportWritter/GetReportGrid/" + id;
    var urlpath = "/ReportWritter/GetReportData/";

    $("#tabs").tabs({
        beforeActivate: function (event, ui) {
            if ($.trim($("#txtQuery")[0].value).toString() == "") {
                return;
            }

            var Query = $("#txtQuery")[0].value.replace("\n", " ");
            var ArrQry = Query.split("!!");
            var Qry = $.trim(ArrQry[0]);

            //Create Parameter
            if (ui.oldPanel.selector == "#tabs-1" && ui.newPanel.selector == "#tabs-2") {

                $("#divPara").empty();

                if (ArrQry.length > 1) {
                    var para = $.trim(ArrQry[1].replace("{Para", "").replace("}", "")).split("%");
                    for (var i = 0; i < para.length; i++) {
                        var paras = para[i].split("#");

                        var QryDtResult = {
                            cType: paras[1],
                            Query: paras[3],
                            Para: paras[0]
                        };

                        $.post("/ReportWritter/GetQueryHtmlResult",
                            QryDtResult,
                            function (data, textStatus, jqXHR) {
                                $("#divPara").append(data);
                            }).fail(function (jqXHR, textStatus, errorThrown) {
                                alert(textStatus);
                            });
                    }
                }
            }
                //Execute Query
            else if (ui.oldPanel.selector == "#tabs-2" && ui.newPanel.selector == "#tabs-3") {
                Qry = CreateQuery(ArrQry, Qry);

                var ExecCommand = {
                    Query: Qry
                };

                urlpath = "/ReportWritter/GetQueryDataResult";
                $.post("/ReportWritter/GetQueryStructResult",
                    ExecCommand,
                    function (data, textStatus, jqXHR) {

                        var obj = $.parseJSON(data);
                        ColN = obj[0].split(",");
                        ColM = obj[1];
                        CreateGrid(Qry);

                    }).fail(function (jqXHR, textStatus, errorThrown) {
                        alert(textStatus);
                    });
            }
                //Query Result
            else if (ui.oldPanel.selector == "#tabs-3" && ui.newPanel.selector == "#tabs-4") {
                var str = $(".ui-paging-info")[0].innerHTML;
                var ArrStr = str.split(" ");
                $("#divQueryResult").empty();
                $("#divQueryResult").append("<ul><li>Query for execute: <b>" + CreateQuery(ArrQry, Qry) + "</b></li>" +
                                            "<li> Record found: <b>" + ArrStr[ArrStr.length - 1].replace(",", "") + "</b></li>" +
                                            "<li><b>" + str + "</b></li></ul>");
            }
        }
    });

    function CreateQuery(ArrQry, Qry) {

        if (ArrQry.length > 1) {

            var para = $.trim(ArrQry[1].replace("{Para", "").replace("}", "")).split("%");

            for (var i = 0; i < para.length; i++) {
                var paras = para[i].split("#")
                var ParameterName = paras[0];
                var id = $("#" + ParameterName);
                var idCheck = $("#input" + ParameterName);
                if (idCheck.prop("checked")) {
                    Qry = Qry.replace("~" + ParameterName, id.val());
                }
            }
        }
        return Qry;
    };

    function CreateGrid(Qry) {
        $("#list").GridUnload();
        $('#list').jqGrid({
            url: urlpath,
            postData: {
                ExecCommand: Qry
            },
            datatype: 'json',
            mtype: 'POST',
            sortable: true,
            colNames: ColN,
            colModel: ColM,
            pager: $('#pager'),
            rowNum: 20,
            rowList: [5, 10, 20, 50],
            sortname: ColN.toString().split(",")[0],
            height: 450,
            sortorder: 'asc',
            gridview: true,
            viewrecords: true,
            autowidth: true,
            shrinkToFit: true
        });
        jQuery("#list")
            .navGrid("#pager",
                { edit: false, add: false, del: false, search: false, refresh: false }
            )
            .navButtonAdd('#pager', {
                caption: "Excel",
                title: "Export To Excel",
                onClickButton: function () {
                    jQuery("#list").jqGrid('excelExport', { "url": "/reportwritter/export" });
                },
                position: "last"
            })
            .navButtonAdd('#pager', {
                caption: "CSV",
                title: "Export To CSV",
                onClickButton: function () {
                    jQuery("#list").jqGrid('excelExport', { "url": "/reportwritter/export", tag: "csv" });
                },
                position: "last"
            })
            .navButtonAdd('#pager', {
                caption: "PDF",
                title: "Export To PDF",
                onClickButton: function () {
                    jQuery("#list").jqGrid('excelExport', { "url": "/reportwritter/export", tag: "pdf" });
                },
                position: "last"
            })
            .navButtonAdd('#pager', {
                caption: "Word",
                title: "Export To Word",
                onClickButton: function () {
                    jQuery("#list").jqGrid('excelExport', { "url": "/reportwritter/export", tag: "word" });
                },
                position: "last"
            });
    };
});

function OnCheckClick(para) {
    var Chk = $("#input" + para);
    var ctrl = $("#" + para);
    if (Chk.prop("checked")) {
        ctrl.removeAttr("disabled");
    } else {
        ctrl.attr("disabled", "disabled");
    }
};