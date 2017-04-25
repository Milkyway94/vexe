$(".select2").select2({
    allowClear: true,
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
function TimVeXe() {
    $("#btnSearch").addClass("disabled");
    $("#btnSearch").attr("disabled", true);
    $(".fa-spinner").show();
}
function Login() {
    var path = window.location.pathname;
    window.location.href = "/login.htm?returnUrl=" + encodeURIComponent(path);
}
function locdau(n) {
    return n = n.toString().toLowerCase(), n = n.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a"), n = n.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e"), n = n.replace(/ì|í|ị|ỉ|ĩ/g, "i"), n = n.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o"), n = n.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u"), n = n.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y"), n = n.replace(/đ/g, "d"), n = n.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-"), n = n.replace(/-+-/g, "-"), n.replace(/^\-+|\-+$/g, "")
}
//begin


//log
$(document).ready(function () {
    console.log(" ______  _____  ______   _______       ________         __         __ __       ___\n|  ____||     \\_/     |(`  ______`)  (  _______)       |  |       /  ||    \\   |  |\n| |____ |  | \\___/ |  |(  (     | |  (  |               \\  \\     /  / |  |\ \  |  |\n|____  ||  |       |  |(  (     | |  (  |                \\  \\   /  /  |  | \\ \\ |  |\n ____| ||  |       |  |(  (,____| |_ (  |______            \\ \\_/  /   |  |  \\ \\|  |\n|______||__|       |__|(,_______,__/ ( ,______,)  (_)       \\____/    |__|   \\____|");
})