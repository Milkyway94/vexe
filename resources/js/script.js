$(".select2").select2();
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

//begin


//log
$(document).ready(function () {
    console.log(" ______  _____  ______   _______       ________         __         __ __       ___\n|  ____||     \\_/     |(`  ______`)  (  _______)       |  |       /  ||    \\   |  |\n| |____ |  | \\___/ |  |(  (     | |  (  |               \\  \\     /  / |  |\ \  |  |\n|____  ||  |       |  |(  (     | |  (  |                \\  \\   /  /  |  | \\ \\ |  |\n ____| ||  |       |  |(  (,____| |_ (  |______            \\ \\_/  /   |  |  \\ \\|  |\n|______||__|       |__|(,_______,__/ ( ,______,)  (_)       \\____/    |__|   \\____|");
})