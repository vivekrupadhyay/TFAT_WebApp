﻿/*!
 * jquery.sumoselect - v1.2.0
 * http://hemantnegi.github.io/jquery.sumoselect
 * 2014-04-08
 * Copyright 2014 Hemant Negi
 * Email : hemant.frnz@gmail.com
 */
(function ($) {
    $.fn.SumoSelect = function (options) {
        var settings = $.extend({
            placeholder: "Select Here",
            csvDispCount: 3,
            captionFormat: "{0} Selected",
            floatWidth: 400,
            forceCustomRendering: false,
            nativeOnDevice: ["Android", "BlackBerry", "iPhone", "iPad", "iPod", "Opera Mini", "IEMobile", "Silk"],
            outputAsCSV: false,
            csvSepChar: ",",
            okCancelInMulti: false,
            triggerChangeCombined: true
        }, options);
        var ret = this.each(function () {
            var selObj = this;
            if (this.sumo || !$(this).is("select")) {
                return
            }
            this.sumo = {
                E: $(selObj),
                is_multi: $(selObj).attr("multiple"),
                select: "",
                caption: "",
                placeholder: "",
                optDiv: "",
                CaptionCont: "",
                is_floating: false,
                is_opened: false,
                backdrop: "",
                mob: false,
                Pstate: [],
                createElems: function () {
                    var O = this;
                    O.E.wrap('<div class="SumoSelect">');
                    O.select = O.E.parent();
                    O.caption = $("<span></span>");
                    O.CaptionCont = $('<p class="CaptionCont"><label><i></i></label></p>').addClass("SlectBox").attr("style", O.E.attr("style")).prepend(O.caption);
                    O.select.append(O.CaptionCont);
                    if (O.E.attr("disabled")) {
                        O.select.addClass("disabled")
                    }
                    if (settings.outputAsCSV && O.is_multi && O.E.attr("name")) {
                        O.select.append($('<input class="HEMANT123" type="hidden" />').attr("name", O.E.attr("name")).val(O.getSelStr()));
                        O.E.removeAttr("name")
                    }
                    if (O.isMobile() && !settings.forceCustomRendering) {
                        O.setNativeMobile();
                        return
                    }
                    O.E.hide();
                    O.optDiv = $('<div class="optWrapper">');
                    O.floatingList();
                    ul = $('<ul class="options">');
                    O.optDiv.append(ul);
                    $(O.E.children("option")).each(function (i, opt) {
                        opt = $(opt);
                        O.createLi(opt)
                    });
                    if (O.is_multi) {
                        O.multiSelelect()
                    }
                    if (!$(".BackdropSelect").length) {
                        $("body").append('<div class="BackdropSelect">')
                    }
                    O.backdrop = $(".BackdropSelect");
                    O.select.append(O.optDiv);
                    O.basicEvents()
                },
                createLi: function (opt, i) {
                    var O = this;
                    li = $('<li data-val="' + opt.val() + '"><label>' + opt.text() + "</label></li>");
                    if (O.is_multi) {
                        li.prepend("<span><i></i></span>")
                    }
                    if (opt.attr("disabled")) {
                        li.addClass("disabled")
                    } else {
                        O.onOptClick(li)
                    }
                    if (opt.attr("selected")) {
                        li.addClass("selected")
                    }
                    ul = O.optDiv.children("ul.options");
                    if (typeof i == "undefined") {
                        ul.append(li)
                    } else {
                        ul.children("li").eq(i).before(li)
                    }
                    return li
                },
                getSelStr: function () {
                    sopt = [];
                    this.E.children("option:selected").each(function () {
                        sopt.push($(this).val())
                    });
                    return sopt.join(settings.csvSepChar)
                },
                multiSelelect: function () {
                    var O = this;
                    O.optDiv.addClass("multiple");
                    okbtn = $('<p class="btnOk">OK</p>').click(function () {
                        if (settings.triggerChangeCombined) {
                            changed = false;
                            if (O.E.children("option:selected").length != O.Pstate.length) {
                                changed = true
                            } else {
                                O.E.children("option:selected").each(function () {
                                    if (O.Pstate.indexOf($(this).val()) < 0) {
                                        changed = true
                                    }
                                })
                            }
                            if (changed) {
                                O.E.trigger("change");
                                O.setText()
                            }
                        }
                        O.hideOpts()
                    });
                    cancelBtn = $('<p class="btnCancel">Cancel</p>').click(function () {
                        O.E.children("option:selected").each(function () {
                            this.selected = false
                        });
                        O.optDiv.find("li.selected").removeClass("selected");
                        for (i = 0; i < O.Pstate.length; i++) {
                            O.E.children('option[value="' + O.Pstate[i] + '"]')[0].selected = true;
                            O.optDiv.find('li[data-val="' + O.Pstate[i] + '"]').addClass("selected")
                        }
                        O.setText();
                        O.hideOpts()
                    });
                    O.optDiv.append($('<div class="MultiControls">').append(okbtn).append(cancelBtn))
                },
                showOpts: function () {
                    var O = this;
                    if (O.E.attr("disabled")) {
                        return
                    }
                    O.is_opened = true;
                    O.backdrop.show();
                    O.optDiv.addClass("open");
                    if (O.is_floating) {
                        H = O.optDiv.children("ul").outerHeight() + 2;
                        if (O.is_multi) {
                            H = H + parseInt(O.optDiv.css("padding-bottom"))
                        }
                        O.optDiv.css("height", H)
                    }
                    if (O.is_multi && (O.is_floating || settings.okCancelInMulti)) {
                        O.Pstate = [];
                        O.E.children("option:selected").each(function () {
                            O.Pstate.push($(this).val())
                        })
                    }
                },
                hideOpts: function () {
                    var O = this;
                    O.is_opened = false;
                    O.backdrop.hide();
                    O.optDiv.removeClass("open")
                },
                basicEvents: function () {
                    var O = this;
                    O.CaptionCont.click(function (evt) {
                        if (O.is_opened) {
                            O.hideOpts()
                        } else {
                            O.showOpts()
                        }
                        O.E.trigger("click")
                    });
                    O.backdrop.click(function () {
                        O.hideOpts()
                    });
                    O.E.on("blur", function () {
                        O.optDiv.removeClass("open")
                    });
                    $(window).on("resize.sumo", function () {
                        O.floatingList()
                    })
                },
                onOptClick: function (li) {
                    var O = this;
                    li.click(function () {
                        var li = $(this);
                        txt = "";
                        if (O.is_multi) {
                            li.toggleClass("selected");
                            O.E.children('option[value="' + li.attr("data-val") + '"]')[0].selected = li.hasClass("selected")
                        } else {
                            li.parent().find("li.selected").removeClass("selected");
                            li.toggleClass("selected");
                            O.E.val(li.attr("data-val"))
                        }
                        if (!(O.is_multi && settings.triggerChangeCombined && (O.is_floating || settings.okCancelInMulti))) {
                            O.setText();
                            O.E.trigger("change")
                        }
                        if (!O.is_multi) {
                            O.hideOpts()
                        }
                    })
                },
                setText: function () {
                    var O = this;
                    O.placeholder = "";
                    if (O.is_multi) {
                        sels = O.E.children(":selected").not(":disabled");
                        for (i = 0; i < sels.length; i++) {
                            if (i >= settings.csvDispCount && settings.csvDispCount) {
                                O.placeholder = settings.captionFormat.replace("{0}", sels.length);
                                break
                            } else {
                                O.placeholder += $(sels[i]).text() + ", "
                            }
                        }
                        O.placeholder = O.placeholder.replace(/,([^,]*)$/, "$1")
                    } else {
                        O.placeholder = O.E.children(":selected").not(":disabled").text()
                    }
                    is_placeholder = false;
                    if (!O.placeholder) {
                        is_placeholder = true;
                        O.placeholder = O.E.attr("placeholder");
                        if (!O.placeholder) {
                            O.placeholder = O.E.children("option:disabled:selected").text()
                        }
                    }
                    O.placeholder = O.placeholder ? O.placeholder : settings.placeholder;
                    O.caption.text(O.placeholder);
                    csvField = O.select.find("input.HEMANT123");
                    if (csvField.length) {
                        csvField.val(O.getSelStr())
                    }
                    if (is_placeholder) {
                        O.caption.addClass("placeholder")
                    } else {
                        O.caption.removeClass("placeholder")
                    }
                    return O.placeholder
                },
                isMobile: function () {
                    var ua = navigator.userAgent || navigator.vendor || window.opera;
                    for (var i in settings.nativeOnDevice) {
                        if (ua.toLowerCase().indexOf(settings.nativeOnDevice[i].toLowerCase()) > 0) {
                            return settings.nativeOnDevice[i]
                        }
                    }
                    return false
                },
                setNativeMobile: function () {
                    var O = this;
                    O.E.addClass("SelectClass");
                    O.mob = true;
                    O.E.change(function () {
                        O.setText()
                    })
                },
                floatingList: function () {
                    var O = this;
                    O.is_floating = $(window).width() <= settings.floatWidth;
                    O.optDiv.toggleClass("isFloating", O.is_floating);
                    if (!O.is_floating) {
                        O.optDiv.css("height", "")
                    }
                    O.optDiv.toggleClass("okCancelInMulti", settings.okCancelInMulti && !O.is_floating)
                },
                vRange: function (i) {
                    var O = this;
                    opts = O.E.children("option");
                    if (opts.length <= i || i < 0) {
                        throw "index out of bounds"
                    }
                    return O
                },
                toggSel: function (c, i) {
                    var O = this.vRange(i);
                    if (O.E.children("option")[i].disabled) {
                        return
                    }
                    O.E.children("option")[i].selected = c;
                    if (!O.mob) {
                        O.optDiv.find("ul.options li").eq(i).toggleClass("selected", c)
                    }
                    O.setText()
                },
                toggDis: function (c, i) {
                    var O = this.vRange(i);
                    O.E.children("option")[i].disabled = c;
                    if (!O.mob) {
                        O.optDiv.find("ul.options li").eq(i).toggleClass("disabled", c)
                    }
                    O.setText()
                },
                unload: function () {
                    var O = this;
                    O.select.before(O.E);
                    O.E.removeClass("SelectClass").show();
                    if (settings.outputAsCSV && O.is_multi && O.select.find("input.HEMANT123").length) {
                        O.E.attr("name", O.select.find("input.HEMANT123").attr("name"))
                    }
                    O.select.remove();
                    delete selObj.sumo;
                    return selObj
                },
                add: function (val, txt, i) {
                    if (typeof val == "undefined") {
                        throw "No value to add"
                    }
                    var O = this;
                    opts = O.E.children("option");
                    if (typeof txt == "number") {
                        i = txt;
                        txt = val
                    }
                    if (typeof txt == "undefined") {
                        txt = val
                    }
                    opt = $("<option></option>").val(val).html(txt);
                    if (opts.length < i) {
                        throw "index out of bounds"
                    }
                    if (typeof i == "undefined" || opts.length == i) {
                        O.E.append(opt);
                        if (!O.mob) {
                            O.createLi(opt)
                        }
                    } else {
                        opts.eq(i).before(opt);
                        if (!O.mob) {
                            O.createLi(opt, i)
                        }
                    }
                    return selObj
                },
                remove: function (i) {
                    var O = this.vRange(i);
                    O.E.children("option").eq(i).remove();
                    if (!O.mob) {
                        O.optDiv.find("ul.options li").eq(i).remove()
                    }
                    O.setText()
                },
                selectItem: function (i) {
                    this.toggSel(true, i)
                },
                unSelectItem: function (i) {
                    this.toggSel(false, i)
                },
                disableItem: function (i) {
                    this.toggDis(true, i)
                },
                enableItem: function (i) {
                    this.toggDis(false, i)
                },
                get disabled() {
                    return this.E.attr("disabled") ? true : false
                },
                set disabled(val) {
                    var O = this;
                    O.select.toggleClass("disabled", val);
                    if (val) {
                        O.E.attr("disabled", "disabled")
                    } else {
                        O.E.removeAttr("disabled")
                    }
                },
                init: function () {
                    var O = this;
                    O.createElems();
                    O.setText();
                    return O
                }
            };
            selObj.sumo.init()
        });
        return ret.length == 1 ? ret[0] : ret
    }
}(jQuery));