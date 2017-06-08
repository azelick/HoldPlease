// Write your Javascript code.
$(function() {
    $('.request-provider').on('click', function(e) {
        var serviceId = $(e.target).data("serviceid").toString();
        var userId = $(e.target).data("userid");
        $.ajax({
            type: "GET",
            url: "/Service/AddNotification/" + serviceId + "/" + userId,
            success: function(status, xhr) {
                $(e.target).replaceWith("<span class='green'>Requested</span>");
            }
        });

    });
});