/*Custom JS File */

//Open Ajax Model Start
$(function () {
    let PlaceHolderElement = $('#PlaceHolderHere');
    $('button[data-bs-toggle="ajax-modal"]').click(function (event) {
        let url = $(this).data('url');
        let decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })
});