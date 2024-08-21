function openDeleteModal (bookId) {
    // Open Modal
    $('#deleteModal').modal('show')

    $('#bookId').val(bookId)
}
$(document).ready(function () {
    var alertDuration = 5000 // 5 saniye

    var alertElement = $('#autoCloseAlert')
    if (alertElement.length) {
        // Belirtilen süre sonra alerti gizle
        setTimeout(function () {
            alertElement.fadeOut('slow')
        }, alertDuration)
    }
})