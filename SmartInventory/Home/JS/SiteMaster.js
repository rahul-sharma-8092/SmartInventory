function showNotification(message, type, autoClose = true, duration = 5000) {
    if ($('#notification').length === 0) {
        $('body').append('<div id="notification" style="display:none; max-width: 90%; position:fixed; top:2px; right:auto; left: auto; background-color:#f0f0f0; border:1px solid #ccc; padding:10px; z-index:1000;">'
            + '<span id="notification-message"></span>'
            + '<span id="notification-close" style="cursor:pointer; font-weight:bold; float:right; margin-left:10px;">&times;</span>'
            + '</div>');
    }

    $('#notification-message').html(message);

    // Set the notification style based on the type
    if (type === 'success') {
        $('#notification').css('background-color', '#d4edda').css('color', '#155724').css('border', '1px solid #c3e6cb');
    } else if (type === 'error') {
        $('#notification').css('background-color', '#f8d7da').css('color', '#721c24').css('border', '1px solid #f5c6cb');
    } else if (type === 'warning') {
        $('#notification').css('background-color', '#fff3cd').css('color', '#856404').css('border', '1px solid #ffeeba');
    }

    $('#notification').fadeIn();

    $('#notification-close').off('click').on('click', function () {
        $('#notification').fadeOut();
    });

    if (autoClose) {
        setTimeout(function () {
           $('#notification').fadeOut();
        }, duration);
    }
}
