﻿const responseType =
{
    OK: 0,
    KO: 1
}

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
        switch (response.responseType) {
            case responseType.OK:
                break;
            case responseType.KO:
                alert("Server error")
                break;
        }
        return;
    }
});

$(document).ajaxError(function (event, xhr, settings) {
    alert("Server error");
});

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