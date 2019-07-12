$(document).ready(() => {
    $("#send").click(function (event) {
        event.preventDefault();
        sendData();
    });
});

function sendData() {
    var formData = getFormData();
    $.ajax({
        url: "/api/values",
        method: "POST",
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(formData),
        success: viewResult
    });
}

function getFormData() {
    return {
        action: $("#selectAction").val(),
        text: $("#textArea").val()
    };
}

function viewResult(data) {
    $("#answerText").text(data.message);
}