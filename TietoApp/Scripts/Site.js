$(".favorite-button").click(function () {
    var row = $(this).parent().parent();

    var rank = parseInt(row.children(1).text());
    debugger;
    if ($(this).hasClass("glyphicon-star-empty")) {
        $(this).removeClass("glyphicon-star-empty");
        $(this).addClass("glyphicon-star");

        document.cookie = "like-cookie-" + String(rank) + "=true";
        debugger;
    }
    else if ($(this).hasClass("glyphicon-star")) {
        $(this).removeClass("glyphicon-star");
        $(this).addClass("glyphicon-star-empty");

        document.cookie = "like-cookie-" + String(rank) + "=false";
        debugger;
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
