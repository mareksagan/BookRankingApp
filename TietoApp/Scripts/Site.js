$(".favorite-button").click(function () {
    if ($(this).hasClass("glyphicon-star-empty")) {
        $(this).removeClass("glyphicon-star-empty");
        $(this).addClass("glyphicon-star");
    }
    else if ($(this).hasClass("glyphicon-star"))
    {
        $(this).removeClass("glyphicon-star");
        $(this).addClass("glyphicon-star-empty");
    }
});

$('.move-up').click(function () {
    var row = $(this).closest('tr');
    row.insertBefore(row.prev());
});

$('.move-down').click(function () {
    var row = $(this).closest('tr');
    row.insertAfter(row.next());
});