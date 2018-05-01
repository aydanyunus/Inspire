$(document).ready(function () {
    $('#myTabs a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    });
    var x = 1;
    $(".form-input input").attr('value', x);
    $(".up").click(function () {
        $(".form-input input").attr('value', x++);
    });
    $(".down").click(function () {
        $(".form-input input").attr('value', x--);
    });
})