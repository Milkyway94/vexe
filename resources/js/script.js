$(".select2").select2({
    placeholder: function () {
        $(this).data('placeholder');
    }
});
$(".timepicker").timepicker();
$(".datepicker").datepicker({
    closeText: "Đóng",
    prevText: "Trước",
    nextText: "Sau",
    currentText: "Hôm nay",
    monthNames: ["Tháng một", "Tháng hai", "Tháng ba", "Tháng tư", "Tháng năm", "Tháng sáu", "Tháng bảy", "Tháng tám", "Tháng chín", "Tháng mười", "Tháng mười một", "Tháng mười hai"],
    monthNamesShort: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
    dayNames: ["Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy"],
    dayNamesShort: ["CN", "Hai", "Ba", "Tư", "Năm", "Sáu", "Bảy"],
    dayNamesMin: ["CN", "T2", "T3", "T4", "T5", "T6", "T7"],
    weekHeader: "Tuần",
    dateFormat: "dd/mm/yy",
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: "",
    changeMonth: true

});
$(".datepicker").change(function () {
    if (!moment($(this).val(), "DD/MM/YYYY", true).isValid()) {
        alert("Nhập ngày không đúng định dạng");
        $(this).val('');
        $(this).focus();
    }
})
function convertToDateTime(str) {
    var from = $(str).val().split("/");
    var f = new Date(from[2], from[1] - 1, from[0]);
    console.log(f);
    return f;
}
function isPastDate(date) {
    var today = new Date();
    today.setDate(today.getDate() - 1);
    return date < today;
}
function Login() {
    var path = window.location.pathname;
    window.location.href = "/login.htm?returnUrl=" + encodeURIComponent(path);
}
function locdau(n) {
    return n = n.toString().toLowerCase(), n = n.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a"), n = n.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e"), n = n.replace(/ì|í|ị|ỉ|ĩ/g, "i"), n = n.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o"), n = n.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u"), n = n.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y"), n = n.replace(/đ/g, "d"), n = n.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-"), n = n.replace(/-+-/g, "-"), n.replace(/^\-+|\-+$/g, "")
}
$.widget("custom.catcomplete", $.ui.autocomplete, {

    _create: function () {
        this._super();
        this.widget().menu("option", "items", "> :not(.ui-autocomplete-category)");
    },

    _resizeMenu: function () {
        this.menu.element.outerWidth(382).outerHeight(300);
    },

    _renderMenu: function (ul, items) {

        var that = this,
            currentCategory = "";

        $.each(items, function (index, item) {
            var li;
            if (item.category != currentCategory) {
                ul.append("<li class='ui-autocomplete-category " + item.category + "'>" + item.category + "</li>");
                currentCategory = item.category;
            }

            li = that._renderItemData(ul, item);

            if (item.category) {
                li.attr("aria-label", item.category + " : " + item.label);
            }
        });
    },

    _renderItem: function (ul, item) {
        return $("<li>")
            .addClass(item.category)
            .attr("data-value", item.value)
            .append($("<a>").text(item.label))
            .appendTo(ul);
    }
});
//begin
$(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $("#goTop").fadeIn()
        } else {
            $("#goTop").fadeOut()
        }
    });
    $("#goTop").click(function () {
        $("body,html").animate({
            scrollTop: 0
        }, "slow")
    })
});
jQuery("document").ready(function (a) {
    var b = a(".navbar");
    a(window).scroll(function () {
        if (a(this).scrollTop() > 100) {
            b.addClass("hed_fixed")
        } else {
            b.removeClass("hed_fixed ")
        }
    })
});

$(document).ready(function () {
    $("#searchkey").focusin(function () {
        $("#search").css("width", "320px !important")
    })
});
$(document).ready(function () {
    $("#txtSDate").change(function () {
        var b = new Date(Date.parse($("#txtSDate").val(), "dd/MM/yyyy"));
        var a = new Date(Date.parse($("#txtEDate").val(), "dd/MM/yyyy"));
        if (b > a) {
            alert("Ngày sau phải lớn hơn ngày trước")
        }
    });
    $("#txtEDate").change(function () {
        var b = new Date(Date.parse($("#txtSDate").val(), "dd/MM/yyyy"));
        var a = new Date(Date.parse($("#txtEDate").val(), "dd/MM/yyyy"));
        if (b > a) {
            alert("Ngày sau phải lớn hơn ngày trước")
        }
    })
});
$(".en").click(function (a) {
    a.preventDefault();
    window.location.href = "/?lang=2"
});
$(".vi").click(function (a) {
    a.preventDefault();
    window.location.href = "/?lang=1"
});

function validatePhone(value) {
    var filter = /^[0-9-+]+$/;
    if (filter.test(value)) {
        return true;
    }
    else {
        return false;
    }
}
function ValidateDate(dtValue) {
    var dtRegex = new RegExp(/\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/);
    return dtRegex.test(dtValue);
}
function validateEmail(sEmail) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (filter.test(sEmail)) {
        return true;
    }
    else {
        return false;
    }
}
function validateBienSo(value) {
    var filter = /[a-zA-Z0-9-]+/;
    if (filter.test(sEmail)) {
        return true;
    }
    else {
        return false;
    }
}
//upload

//$('#fAvartar').change(function (event) {
//    event.preventDefault();
//    var fileName = document.getElementById("fAvartar").files[0] ;
//    if (fileName && fileName.length > 0) {
//        $('#avartar').prop("src", fileName);
//    }
//});

//log
$(document).ready(function () {
    console.log(" ______  _____  ______   _______       ________         __         __ __       ___\n|  ____||     \\_/     |(`  ______`)  (  _______)       |  |       /  ||    \\   |  |\n| |____ |  | \\___/ |  |(  (     | |  (  |               \\  \\     /  / |  |\ \  |  |\n|____  ||  |       |  |(  (     | |  (  |                \\  \\   /  /  |  | \\ \\ |  |\n ____| ||  |       |  |(  (,____| |_ (  |______            \\ \\_/  /   |  |  \\ \\|  |\n|______||__|       |__|(,_______,__/ ( ,______,)  (_)       \\____/    |__|   \\____|");
})