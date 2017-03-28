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
$(".slide1").slick({
    slidesToShow: 4,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 1000,
    speed: 500,
    responsive: [{
        breakpoint: 1200,
        settings: {
            slidesToShow: 4,
            slidesToScroll: 1
        }
    }, {
        breakpoint: 1024,
        settings: {
            slidesToShow: 3,
            slidesToScroll: 1,
            infinite: true
        }
    }, {
        breakpoint: 600,
        settings: {
            slidesToShow: 2,
            slidesToScroll: 1
        }
    }, {
        breakpoint: 480,
        settings: {
            slidesToShow: 1,
            slidesToScroll: 1
        }
    }]
});
$(".slider").slick({
    slidesToShow: 5,
    slidesToScroll: 1,
    dots: true,
    autoplay: true,
    autoplaySpeed: 1000,
    speed: 500,
    responsive: [{
        breakpoint: 1200,
        settings: {
            slidesToShow: 4,
            dots: true,
            slidesToScroll: 1
        }
    }, {
        breakpoint: 1024,
        settings: {
            slidesToShow: 3,
            slidesToScroll: 1,
            infinite: true,
            dots: true
        }
    }, {
        breakpoint: 600,
        settings: {
            slidesToShow: 2,
            dots: true,
            slidesToScroll: 1
        }
    }, {
        breakpoint: 480,
        dots: true,
        settings: {
            slidesToShow: 1,
            dots: true,
            slidesToScroll: 1
        }
    }]
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

//Register page
$("#rsCapcha").click(function (e) {
    e.preventDefault();
    location.reload();
});
function validatePhone(value) {
    var filter = /^[a-zA-Z0-9]+[a-zA-Z0-9]$/;
    if (filter.test(value)) {
        return true;
    }
    else {
        return false;
    }
}
$("#txtUserName").focusout(function () {
    var value = $("#txtUserName").val();
    if (!validatePhone(value)) {
        $("#lbErrorUserName").text("Tên đăng nhập không hợp lệ(Hợp lệ: chữ không dấu, số, từ 6-18 kí tự)");
        $("#lbErrorUserName").removeClass("green fa fa-check");
        $("#lbErrorUserName").addClass("do fa fa-exclamation");
        $("#txtUserName").css("border", "1px solid red");
        $("#txtUserName").focus();
    }
});

$(document).ready(function () {
    var i = 0;
    $(".button_chat_offline").click(function () {
        $(".modal-content").animate({
            height: 'toggle'
        });
        if (i%2 == 0) {
            $("#downup").html("<i class=\"pill-right fa fa-chevron-down\"></i>")
        }
        else {
            $("#downup").html("<i class=\"pill-right fa fa-chevron-up\"></i>")
        }
        i++;
    });
});
$(document).ready(function () {
    $("#img-product-1").click(function () {
        $('#ImgModal').modal('show');
    });
});
function Send() {
    document.getElementById("btnsend").setAttribute("disabled", "true");
    document.getElementById("btnsend").innerHTML="Đang gửi...";
    document.getElementById("btnsend").setAttribute("class", "btn btn-primary btn-block disabled");
    $("#imgLoading").show();
}