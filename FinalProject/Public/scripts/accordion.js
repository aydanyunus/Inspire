$(document).ready(function(){
    $('.collapse').collapse({
        toggle: true
    })
    $('.panel-arrow').click(function(){
        $('.panel-arrow:after').toggle("slow", function(){
            console.log("hello");
        })
    })
})