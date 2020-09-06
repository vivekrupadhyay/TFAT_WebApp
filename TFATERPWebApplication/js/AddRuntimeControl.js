
$(document).ready(function () {
    $('#tax').each(function () {
        $(this).keyup(function () {
            CalSumAvg();
        });
    });
});
function CalSumAvg()
{
    var Percent = 0;
    var Cal = 0;
    $('#tax').each(function () {
        //add only if the value is number
        if (!isNaN(this.value) && this.value.length != 0) {
            Percent += parseFloat(this.value);
            Cal = Percent / 100;
        }

    });
    $("#taxamt").html(sum.toFixed(2));
}














