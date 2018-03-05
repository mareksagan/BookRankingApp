$(".favorite-button").click(function () {
    var row = $(this).parent().parent();

    var rank = row.children().find(".rank").first().text();

    if ($(this).hasClass("glyphicon-star-empty")) {
        $(this).removeClass("glyphicon-star-empty");
        $(this).addClass("glyphicon-star");

        document.cookie = rank+"=true";
    }
    else if ($(this).hasClass("glyphicon-star")) {
        $(this).removeClass("glyphicon-star");
        $(this).addClass("glyphicon-star-empty");

        document.cookie = rank+"=false";
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
