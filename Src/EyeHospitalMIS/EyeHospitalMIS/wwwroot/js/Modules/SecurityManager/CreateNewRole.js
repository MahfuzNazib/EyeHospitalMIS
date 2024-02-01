$(document).ready(function () {
    var selectedPermissionIds = [];

    // Event listener for checkbox changes
    $('input[type="checkbox"]').on('change', function () {
        // Use the "data()" method to access data attributes
        var permissionId = $(this).data('permission-id');
        console.log("Hello2 : ", $(this.value));
        var nodeValue = $(this.location);
        if ($(this).prop('checked')) {
            // Checkbox is checked, add the permission ID to the array
            selectedPermissionIds.push(nodeValue);
        } else {
            // Checkbox is unchecked, remove the permission ID from the array
            selectedPermissionIds = selectedPermissionIds.filter(function (id) {
                return id !== permissionId;
            });
        }

        // Display the selected permission IDs (you can customize this part)
        console.log('Selected Permission IDs:', selectedPermissionIds);
    });
});