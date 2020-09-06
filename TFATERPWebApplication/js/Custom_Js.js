$(document).ready(function () {

    $('.Buttonclick').click(function () {
        alert($(this).attr("value"));
        $('#QuantityHiddn').val($(this).attr("value"));
        $('button').removeClass('active');
        $(this).addClass('active');
    });
   
})
