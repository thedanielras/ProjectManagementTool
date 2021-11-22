$(document).ready(function ()
{
    let username = getCookie("username");
    let password = getCookie("password");
    if (username != "" && password != "")
    {
        $("#user_session").html('<span class="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">' + username + '</span>')
    }

});

$(document).bind("ajaxSend", function () {
    console.log("is loading");
}).bind("ajaxComplete", function () {
    console.log("loaded");
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