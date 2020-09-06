$(document).ready(function () {
    var filtering = false;
    var thread = null;
    var MenuData;
    var tree = $('#tree1');
    var filter = $('#txtsearch');
    var ddlProject = $("#DDL_MenuCode_T");
    var sMenuJSONPath = "/Home/GetTfatMenuJSON?mProjectCode=";

    $(function () {
        $("input[type = 'radio']").click(function () {
            $(this).parents("form").submit(); // post form
        });
    });

    ddlProject.change(function () {
        $.ajax({
            url: sMenuJSONPath + ddlProject.val(),
            async: false,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                tree.tree('destroy');
                MenuData = $.parseJSON(data.Data);
                tree.tree({
                    data: MenuData,
                    autoOpen: false,
                    autoEscape: false,
                    dragAndDrop: false,
                    useContextMenu: true,
                    onCreateLi: function (node, $li) {
                        if (!node.hasChildren()) {
                            $li.find('.jqtree-element').prepend('<i class="fa fa-dot-circle-o"></i>');
                        }
                        var title = $li.find('.jqtree-title'),
                            search = filter.val().toLowerCase(),
                            value = title.text().toLowerCase();

                        if (search !== '') {
                            $li.hide();
                            if (value.indexOf(search) > -1) {
                                $li.show();
                                var parent = node.parent;
                                while (typeof (parent.element) !== 'undefined') {
                                    $(parent.element)
                                        .show()
                                        .addClass('jqtree-filtered');
                                    parent = parent.parent;
                                }
                            }
                            if (!filtering) {
                                filtering = true;
                            };
                            if (!tree.hasClass('jqtree-filtering')) {
                                tree.addClass('jqtree-filtering');
                            };
                        } else {
                            if (filtering) {
                                filtering = false;
                            };
                            if (tree.hasClass('jqtree-filtering')) {
                                tree.removeClass('jqtree-filtering');
                            };
                        };
                    },
                    onCanMove: function (node) {
                        if (filtering) {
                            return false;
                        } else {
                            return true;
                        };
                    }
                });
            },
            error: function () {
                alert("Error with AJAX callback");
            }
        });
    });

    filter.keyup(function () {
        clearTimeout(thread);
        thread = setTimeout(function () {
            tree.tree('loadData', MenuData);
        }, 50);
    });

    $("#btnMenu").click(function () {
        $("#divMenu").fadeToggle();
        $("#divMenu").height($(window).height());
    });

    $("#DDL_MenuCode_T").change(function () {
        if (this.options[this.selectedIndex].text == 'Select Project') {
            $("#btnMenu").text('Suchan Software');
            $("#btnMenu").attr('style', 'position: fixed; top: 60px; left: -50px; padding: 5px; /* Rotate div */ transform:rotate(90deg); -ms-transform:rotate(90deg); /* IE 9 */ -webkit-transform:rotate(90deg); /* Opera, Chrome, and Safari */ z-index: 3;  width:auto !important;');
        }
        else {
            $("#btnMenu").text(this.options[this.selectedIndex].text);
            if (this.options[this.selectedIndex].text.length < 12) {
                $("#btnMenu").attr('style', 'position: fixed; top: 60px; left: -30px; padding: 5px; /* Rotate div */ transform:rotate(90deg); -ms-transform:rotate(90deg); /* IE 9 */ -webkit-transform:rotate(90deg); /* Opera, Chrome, and Safari */ z-index: 3;');
            } else {
                $("#btnMenu").attr('style', 'position: fixed; top: 60px; left: -50px; padding: 5px; /* Rotate div */ transform:rotate(90deg); -ms-transform:rotate(90deg); /* IE 9 */ -webkit-transform:rotate(90deg); /* Opera, Chrome, and Safari */ z-index: 3;');
            }
        }
    })
});