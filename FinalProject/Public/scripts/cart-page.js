$(document).ready(function () {
    var x = 1;
    $(".counter .form-input").attr('value', x);
    $(".up").click(function () {
        var value = parseInt($(this).parent().children(".form-input").val());
        value++;
        $(this).parent().children(".form-input").val(value);
    });
    $(".down").click(function () {
        var value = parseInt($(this).parent().children(".form-input").val());
        value--;
        $(this).parent().children(".form-input").val(value);
    });
})