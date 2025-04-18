! function (a, b) {
    "use strict";
    "function" == typeof define && define.amd ? define(["jquery"], b) : "object" == typeof exports ? module.exports = b(require("jquery")) : a.bootbox = b(a.jQuery)
}(this, function a(b, c) {
    "use strict";

    function d(a) {
        var b = q[o.locale];
        return b ? b[a] : q.en[a]
    }

    function e(a, c, d) {
        a.stopPropagation(), a.preventDefault();
        var e = b.isFunction(d) && d.call(c, a) === !1;
        e || c.modal("hide")
    }

    function f(a) {
        var b, c = 0;
        for (b in a) c++;
        return c
    }

    function g(a, c) {
        var d = 0;
        b.each(a, function (a, b) {
            c(a, b, d++)
        })
    }

    function h(a) {
        var c, d;
        if ("object" != typeof a) throw new Error("Please supply an object of options");
        if (!a.message) throw new Error("Please specify a message");
        return a = b.extend({}, o, a), a.buttons || (a.buttons = {}), c = a.buttons, d = f(c), g(c, function (a, e, f) {
            if (b.isFunction(e) && (e = c[a] = {
                callback: e
            }), "object" !== b.type(e)) throw new Error("button with key " + a + " must be an object");
            e.label || (e.label = a), e.className || (2 >= d && f === d - 1 ? e.className = "btn-primary" : e.className = "btn-default")
        }), a
    }

    function i(a, b) {
        var c = a.length,
            d = {};
        if (1 > c || c > 2) throw new Error("Invalid argument length");
        return 2 === c || "string" == typeof a[0] ? (d[b[0]] = a[0], d[b[1]] = a[1]) : d = a[0], d
    }

    function j(a, c, d) {
        return b.extend(!0, {}, a, i(c, d))
    }

    function k(a, b, c, d) {
        var e = {
            className: "bootbox-" + a,
            buttons: l.apply(null, b)
        };
        return m(j(e, d, c), b)
    }

    function l() {
        for (var a = {}, b = 0, c = arguments.length; c > b; b++) {
            var e = arguments[b],
                f = e.toLowerCase(),
                g = e.toUpperCase();
            a[f] = {
                label: d(g)
            }
        }
        return a
    }

    function m(a, b) {
        var d = {};
        return g(b, function (a, b) {
            d[b] = !0
        }), g(a.buttons, function (a) {
            if (d[a] === c) throw new Error("button key " + a + " is not allowed (options are " + b.join("\n") + ")")
        }), a
    }
    var n = {
        dialog: "<div class='bootbox modal' tabindex='-1' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-body'><div class='bootbox-body'></div></div></div></div></div>",
        header: "<div class='modal-header'><h4 class='modal-title'></h4></div>",
        footer: "<div class='modal-footer'></div>",
        closeButton: "<button type='button' class='bootbox-close-button close' data-dismiss='modal' aria-hidden='true'>&times;</button>",
        form: "<form class='bootbox-form'></form>",
        inputs: {
            text: "<input class='bootbox-input bootbox-input-text form-control' autocomplete=off type=text />",
            textarea: "<textarea class='bootbox-input bootbox-input-textarea form-control'></textarea>",
            email: "<input class='bootbox-input bootbox-input-email form-control' autocomplete='off' type='email' />",
            select: "<select class='bootbox-input bootbox-input-select form-control'></select>",
            checkbox: "<div class='checkbox'><label><input class='bootbox-input bootbox-input-checkbox' type='checkbox' /></label></div>",
            date: "<input class='bootbox-input bootbox-input-date form-control' autocomplete=off type='date' />",
            time: "<input class='bootbox-input bootbox-input-time form-control' autocomplete=off type='time' />",
            number: "<input class='bootbox-input bootbox-input-number form-control' autocomplete=off type='number' />",
            password: "<input class='bootbox-input bootbox-input-password form-control' autocomplete='off' type='password' />"
        }
    },
        o = {
            locale: "en",
            backdrop: "static",
            animate: !0,
            className: null,
            closeButton: !0,
            show: !0,
            container: "body"
        },
        p = {};
    p.alert = function () {
        var a;
        if (a = k("alert", ["ok"], ["message", "callback"], arguments), a.callback && !b.isFunction(a.callback)) throw new Error("alert requires callback property to be a function when provided");
        return a.buttons.ok.callback = a.onEscape = function () {
            return b.isFunction(a.callback) ? a.callback.call(this) : !0
        }, p.dialog(a)
    },
        p.confirm = function () {
        var a;
        if (a = k("confirm", ["cancel", "confirm"], ["message", "callback"], arguments), a.buttons.cancel.callback = a.onEscape = function () {
            return a.callback.call(this, !1)
        }, a.buttons.confirm.callback = function () {
            return a.callback.call(this, !0)
        }, !b.isFunction(a.callback)) throw new Error("confirm requires a callback");
        return p.dialog(a)
        },
        p.prompt = function () {
        var a, d, e, f, h, i, k;
        if (f = b(n.form), d = {
            className: "bootbox-prompt",
            buttons: l("cancel", "confirm"),
            value: "",
            inputType: "text"
        }, a = m(j(d, arguments, ["title", "callback"]), ["cancel", "confirm"]), i = a.show === c ? !0 : a.show, a.message = f, a.buttons.cancel.callback = a.onEscape = function () {
            return a.callback.call(this, null)
        }, a.buttons.confirm.callback = function () {
            var c;
            switch (a.inputType) {
                case "text":
                case "textarea":
                case "email":
                case "select":
                case "date":
                case "time":
                case "number":
                case "password":
                    c = h.val();
                    break;
                case "checkbox":
                    var d = h.find("input:checked");
                    c = [], g(d, function (a, d) {
                        c.push(b(d).val())
                    })
            }
            return a.callback.call(this, c)
        }, a.show = !1, !a.title) throw new Error("prompt requires a title");
        if (!b.isFunction(a.callback)) throw new Error("prompt requires a callback");
        if (!n.inputs[a.inputType]) throw new Error("invalid prompt type");
        switch (h = b(n.inputs[a.inputType]), a.inputType) {
            case "text":
            case "textarea":
            case "email":
            case "date":
            case "time":
            case "number":
            case "password":
                h.val(a.value);
                break;
            case "select":
                var o = {};
                if (k = a.inputOptions || [], !b.isArray(k)) throw new Error("Please pass an array of input options");
                if (!k.length) throw new Error("prompt with select requires options");
                g(k, function (a, d) {
                    var e = h;
                    if (d.value === c || d.text === c) throw new Error("given options in wrong format");
                    d.group && (o[d.group] || (o[d.group] = b("<optgroup/>").attr("label", d.group)), e = o[d.group]), e.append("<option value='" + d.value + "'>" + d.text + "</option>")
                }), g(o, function (a, b) {
                    h.append(b)
                }), h.val(a.value);
                break;
            case "checkbox":
                var q = b.isArray(a.value) ? a.value : [a.value];
                if (k = a.inputOptions || [], !k.length) throw new Error("prompt with checkbox requires options");
                if (!k[0].value || !k[0].text) throw new Error("given options in wrong format");
                h = b("<div/>"), g(k, function (c, d) {
                    var e = b(n.inputs[a.inputType]);
                    e.find("input").attr("value", d.value), e.find("label").append(d.text), g(q, function (a, b) {
                        b === d.value && e.find("input").prop("checked", !0)
                    }), h.append(e)
                })
        }
        return a.placeholder && h.attr("placeholder", a.placeholder), a.pattern && h.attr("pattern", a.pattern), a.maxlength && h.attr("maxlength", a.maxlength), f.append(h), f.on("submit", function (a) {
            a.preventDefault(), a.stopPropagation(), e.find(".btn-primary").click()
        }), e = p.dialog(a), e.off("shown.bs.modal"), e.on("shown.bs.modal", function () {
            h.focus()
        }), i === !0 && e.modal("show"), e
    }, p.dialog = function (a) {
        a = h(a);
        var d = b(n.dialog),
            f = d.find(".modal-dialog"),
            i = d.find(".modal-body"),
            j = a.buttons,
            k = "",
            l = {
                onEscape: a.onEscape
            };
        if (b.fn.modal === c) throw new Error("$.fn.modal is not defined; please double check you have included the Bootstrap JavaScript library. See http://getbootstrap.com/javascript/ for more details.");
        if (g(j, function (a, b) {
            k += "<button data-bb-handler='" + a + "' type='button' class='btn " + b.className + "'>" + b.label + "</button>", l[a] = b.callback
        }), i.find(".bootbox-body").html(a.message), a.animate === !0 && d.addClass("fade"), a.className && d.addClass(a.className), "large" === a.size ? f.addClass("modal-lg") : "small" === a.size && f.addClass("modal-sm"), a.title && i.before(n.header), a.closeButton) {
            var m = b(n.closeButton);
            a.title ? d.find(".modal-header").prepend(m) : m.css("margin-top", "-10px").prependTo(i)
        }
        return a.title && d.find(".modal-title").html(a.title), k.length && (i.after(n.footer), d.find(".modal-footer").html(k)), d.on("hidden.bs.modal", function (a) {
            a.target === this && d.remove()
        }), d.on("shown.bs.modal", function () {
            d.find(".btn-primary:first").focus()
        }), "static" !== a.backdrop && d.on("click.dismiss.bs.modal", function (a) {
            d.children(".modal-backdrop").length && (a.currentTarget = d.children(".modal-backdrop").get(0)), a.target === a.currentTarget && d.trigger("escape.close.bb")
        }), d.on("escape.close.bb", function (a) {
            l.onEscape && e(a, d, l.onEscape)
        }), d.on("click", ".modal-footer button", function (a) {
            var c = b(this).data("bb-handler");
            e(a, d, l[c])
        }), d.on("click", ".bootbox-close-button", function (a) {
            e(a, d, l.onEscape)
        }), d.on("keyup", function (a) {
            27 === a.which && d.trigger("escape.close.bb")
        }), b(a.container).append(d), d.modal({
            backdrop: a.backdrop ? "static" : !1,
            keyboard: !1,
            show: !1
        }), a.show && d.modal("show"), d
    }, p.setDefaults = function () {
        var a = {};
        2 === arguments.length ? a[arguments[0]] = arguments[1] : a = arguments[0], b.extend(o, a)
    }, p.hideAll = function () {
        return b(".bootbox").modal("hide"), p
    };
    var q = {
        bg_BG: {
            OK: "Ок",
            CANCEL: "Отказ",
            CONFIRM: "Потвърждавам"
        },
        br: {
            OK: "OK",
            CANCEL: "Cancelar",
            CONFIRM: "Sim"
        },
        cs: {
            OK: "OK",
            CANCEL: "Zrušit",
            CONFIRM: "Potvrdit"
        },
        da: {
            OK: "OK",
            CANCEL: "Annuller",
            CONFIRM: "Accepter"
        },
        de: {
            OK: "OK",
            CANCEL: "Abbrechen",
            CONFIRM: "Akzeptieren"
        },
        el: {
            OK: "Εντάξει",
            CANCEL: "Ακύρωση",
            CONFIRM: "Επιβεβαίωση"
        },
        en: {
            OK: "OK",
            CANCEL: "Cancel",
            CONFIRM: "OK"
        },
        es: {
            OK: "OK",
            CANCEL: "Cancelar",
            CONFIRM: "Aceptar"
        },
        et: {
            OK: "OK",
            CANCEL: "Katkesta",
            CONFIRM: "OK"
        },
        fa: {
            OK: "قبول",
            CANCEL: "لغو",
            CONFIRM: "تایید"
        },
        fi: {
            OK: "OK",
            CANCEL: "Peruuta",
            CONFIRM: "OK"
        },
        fr: {
            OK: "OK",
            CANCEL: "Annuler",
            CONFIRM: "D'accord"
        },
        he: {
            OK: "אישור",
            CANCEL: "ביטול",
            CONFIRM: "אישור"
        },
        hu: {
            OK: "OK",
            CANCEL: "Mégsem",
            CONFIRM: "Megerősít"
        },
        hr: {
            OK: "OK",
            CANCEL: "Odustani",
            CONFIRM: "Potvrdi"
        },
        id: {
            OK: "OK",
            CANCEL: "Batal",
            CONFIRM: "OK"
        },
        it: {
            OK: "OK",
            CANCEL: "Annulla",
            CONFIRM: "Conferma"
        },
        ja: {
            OK: "OK",
            CANCEL: "キャンセル",
            CONFIRM: "確認"
        },
        lt: {
            OK: "Gerai",
            CANCEL: "Atšaukti",
            CONFIRM: "Patvirtinti"
        },
        lv: {
            OK: "Labi",
            CANCEL: "Atcelt",
            CONFIRM: "Apstiprināt"
        },
        nl: {
            OK: "OK",
            CANCEL: "Annuleren",
            CONFIRM: "Accepteren"
        },
        no: {
            OK: "OK",
            CANCEL: "Avbryt",
            CONFIRM: "OK"
        },
        pl: {
            OK: "OK",
            CANCEL: "Anuluj",
            CONFIRM: "Potwierdź"
        },
        pt: {
            OK: "OK",
            CANCEL: "Cancelar",
            CONFIRM: "Confirmar"
        },
        ru: {
            OK: "OK",
            CANCEL: "Отмена",
            CONFIRM: "Применить"
        },
        sq: {
            OK: "OK",
            CANCEL: "Anulo",
            CONFIRM: "Prano"
        },
        sv: {
            OK: "OK",
            CANCEL: "Avbryt",
            CONFIRM: "OK"
        },
        th: {
            OK: "ตกลง",
            CANCEL: "ยกเลิก",
            CONFIRM: "ยืนยัน"
        },
        tr: {
            OK: "Tamam",
            CANCEL: "İptal",
            CONFIRM: "Onayla"
        },
        zh_CN: {
            OK: "OK",
            CANCEL: "取消",
            CONFIRM: "确认"
        },
        zh_TW: {
            OK: "OK",
            CANCEL: "取消",
            CONFIRM: "確認"
        }
    };
    return p.addLocale = function (a, c) {
        return b.each(["OK", "CANCEL", "CONFIRM"], function (a, b) {
            if (!c[b]) throw new Error("Please supply a translation for '" + b + "'")
        }), q[a] = {
            OK: c.OK,
            CANCEL: c.CANCEL,
            CONFIRM: c.CONFIRM
        }, p
    }, p.removeLocale = function (a) {
        return delete q[a], p
    }, p.setLocale = function (a) {
        return p.setDefaults("locale", a)
    }, p.init = function (c) {
        return a(c || b)
    }, p
});