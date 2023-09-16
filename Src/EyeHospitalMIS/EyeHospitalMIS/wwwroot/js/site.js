/*Custom JS File */

//Open Ajax Model Start
$(function () {
    var PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-bs-toggle="ajax-modal"]').click(function (event) {
        console.log("Here");
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
});