function Submit() {
    if ($("#form").valid()) {
        var obj = {};
        obj.channel = {};
        obj.channel.Description = $("#Description").val();
        obj.channel.Code = $("#Code").val();
        obj.channel.Type = $("#Type").val();

        var formBody = new FormData();
        formBody.append("channel", JSON.stringify(obj));
        $.ajax({
            url: "../Channel/Edit",
            type: "POST",
            contentType: false,
            processData: false,
            data: formBody,
            beforeSend: function (xhr) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            },
            success: function (data) {
                window.location.href = window.location.href;
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    } else {

    }
}