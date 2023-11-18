$(document).ready(function () {
    const responseStatus = responseData.responseStatus;
    const responseMessage = responseData.responseMessage;
    const responseType = responseData.responseType;

    if (responseStatus) {
        Swal.fire({
            title: responseType,
            text: responseMessage,
            icon: responseStatus,
            showCancelButton: !1,
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            buttonsStyling: !1,
            showCloseButton: !1
        });
    }

    // Delete Confirmation Message
    // Assuming you're using jQuery
    $(document).on("click", ".delete-this-record", function () {
        let recordId = $(this).data("record-id");
        let deleteMethod = $(this).data("delete-method");
        let redirectUrl = $(this).data("redirect-url");


        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel!",
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            cancelButtonClass: "btn btn-danger w-xs mt-2",
            buttonsStyling: false,
            showCloseButton: true
        }).then(function (result) {
            if (result.value) {
                $.ajax({
                    type: "POST",
                    url: deleteMethod,
                    data: { Id: recordId },
                    success: function (data) {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Your data has been deleted.",
                            icon: "success",
                            confirmButtonClass: "btn btn-primary w-xs mt-2",
                            buttonsStyling: false
                        }).then(function () {
                            window.location.href = redirectUrl;
                        });
                    },
                    error: function () {
                        Swal.fire({
                            title: "Error",
                            text: "An error occurred while deleting the data.",
                            icon: "error",
                            confirmButtonClass: "btn btn-primary mt-2",
                            buttonsStyling: false
                        });
                    }
                });
            } else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire({
                    title: "Cancelled",
                    text: "Your data is safe :)",
                    icon: "error",
                    confirmButtonClass: "btn btn-primary mt-2",
                    buttonsStyling: false
                });
            }
        });
    });


});

