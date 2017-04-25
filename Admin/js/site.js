$(".datepicker").datepicker();
$(".select2").select2();
function HideModal(modal) {
    $(modal).modal('hide');
}
function rLogin() {
    $.post("/Admin/ReloadLogin.aspx", {}, function (data) {
    }, "html");
}
setInterval(function () {
    rLogin();
}, 30000);
//tinymce
tinymce.init({
    selector: '.editor',
    height: 250,
    theme: 'modern',
    plugins: [
      'advlist autolink lists link image charmap print preview hr anchor pagebreak',
      'searchreplace wordcount visualblocks visualchars code fullscreen',
      'insertdatetime media nonbreaking save table contextmenu directionality',
      'emoticons template paste textcolor colorpicker textpattern imagetools codesample'
    ],
    toolbar1: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
    toolbar2: 'print preview media | forecolor backcolor emoticons | codesample',
    image_advtab: true,
    relative_urls: false,
    remove_script_host: false,
    file_browser_callback: openKCFinder,
    file_browser_callback_types: 'file image media',
    style_formats: [
        { title: 'Open Sans', inline: 'span', styles: { 'font-family': 'Open Sans' } },
        { title: 'Arial', inline: 'span', styles: { 'font-family': 'arial' } },
        { title: 'Book Antiqua', inline: 'span', styles: { 'font-family': 'book antiqua' } },
        { title: 'Comic Sans MS', inline: 'span', styles: { 'font-family': 'comic sans ms,sans-serif' } },
        { title: 'Courier New', inline: 'span', styles: { 'font-family': 'courier new,courier' } },
        { title: 'Georgia', inline: 'span', styles: { 'font-family': 'georgia,palatino' } },
        { title: 'Helvetica', inline: 'span', styles: { 'font-family': 'helvetica' } },
        { title: 'Impact', inline: 'span', styles: { 'font-family': 'impact,chicago' } },
        { title: 'Symbol', inline: 'span', styles: { 'font-family': 'symbol' } },
        { title: 'Tahoma', inline: 'span', styles: { 'font-family': 'tahoma' } },
        { title: 'Terminal', inline: 'span', styles: { 'font-family': 'terminal,monaco' } },
        { title: 'Times New Roman', inline: 'span', styles: { 'font-family': 'times new roman,times' } },
        { title: 'Verdana', inline: 'span', styles: { 'font-family': 'Verdana' } }
    ],
});
function openKCFinder(field_name, url, type, win) {
    BrowseServerInEditor(field_name);
    return false;
}
function BrowseServerInEditor(field) {
    var finder = new CKFinder();
    finder.selectActionFunction = function (fileUrl) {
        document.getElementById(field).value = fileUrl;
    };
    finder.popup();
}
function BrowseServer(field) {
    var finder = new CKFinder();
    finder.selectActionFunction = function (fileUrl) {
        document.getElementById(field).value = fileUrl;
        $(field).prop("ng-value", fileUrl);
        document.getElementById("catimg").src = fileUrl;
    };
    finder.popup();
}
//change slug
$(document).ready(function () {
    $(".datepicker").datepicker();
    $(".nav-tabs li a").click(function () {
        $(this).tab('show');
    });
    $('.nav-tabs a').on('shown.bs.tab', function (event) {
        var x = $(event.target).text();         // active tab
        var y = $(event.relatedTarget).text();  // previous tab
        $(".act span").text(x);
        $(".prev span").text(y);
    });
    //$('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
    //    checkboxClass: 'icheckbox_flat-green',
    //    radioClass: 'iradio_flat-green'
    //});
});
function ChangeToSlug() {
    // Chuyển hết sang chữ thường
    var title = document.getElementById("ctl02_txtName").value;
    var str = title.toLowerCase();
    // xóa dấu
    str = str.replace(/(à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ)/g, 'a');
    str = str.replace(/(è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ)/g, 'e');
    str = str.replace(/(ì|í|ị|ỉ|ĩ)/g, 'i');
    str = str.replace(/(ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ)/g, 'o');
    str = str.replace(/(ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ)/g, 'u');
    str = str.replace(/(ỳ|ý|ỵ|ỷ|ỹ)/g, 'y');
    str = str.replace(/(đ)/g, 'd');
    // Xóa ký tự đặc biệt
    str = str.replace(/([^0-9a-z-\s])/g, '');
    // Xóa khoảng trắng thay bằng ký tự -
    str = str.replace(/(\s+)/g, '-');
    // xóa phần dự - ở đầu
    str = str.replace(/^-+/g, '');
    // xóa phần dư - ở cuối
    str = str.replace(/-+$/g, '');
    // return 
    document.getElementById('ctl02_txtCode').value = str;
    return str;
}