$(document).ready(function () {
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
    $('.tooltip-span').hover(function(){
        $('.tooltip-inner').css('background', '#5ec3d5');
        $('.tooltip-inner').css('color', 'white');
        $('.tooltip-inner').css('border-radius', '0px');
        $('.tooltip-arrow').css('border-bottom-color', '#5ec3d5');
    });
})