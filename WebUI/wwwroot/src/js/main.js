const resultPayloadType =
{
    empty: 0,
    json: 1,
    html: 2
}

/* user is saved to cookies upon login, TODO:refactor */
$(document).ready(function ()
{
    let username = getCookie("username");
    let password = getCookie("password");
    if (username != "" && password != "")
    {
        $("#user_session").html('<span class="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">' + username + '</span>')
    }
});

$(document).ajaxComplete(function (event, xhr, settings) {
    let response = xhr.responseJSON;
    if (response && response.responseType)
    {
        parseResponse(response);
    }
});

$(document).ajaxError(function (event, xhr, settings) {

    setupAndShowErrorDialog()
});

function parseResponse(response) {
    switch (response.responseType) {
        case responseType.KO:
            setupAndShowErrorDialog(response.errorMessage ?? "Generic Error!");
            break;
    }
}

function setupAndShowErrorDialog(message) {
    $("#error_modal_message_body").empty().html("<p>" + (message ?? "Generic Error!") + "</p>")
    $("#error_modal").modal('show');
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}