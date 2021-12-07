const resultPayloadType =
{
    empty: 0,
    json: 1,
    html: 2
}

class Result {
    constructor(succeded, payload, errors) {
        this.succeded = succeded || false;
        this.payload = payload || {};
        this.errors = errors || []             
    }

    processErrors() {
        if (this.succeded) return;
        if (this.errors && Array.isArray(this.errors) && this.errors.length > 0) {
            var htmlErrors = "";

            for (var i = 0; i < this.errors.length; i++) {
                var error = this.errors[i];
                htmlErrors += "<p class='mb-0'>" + error + "</p>";
            }

            //this.errors.forEach(error => {
            //    htmlErrors += '<ul class="list-group">'
            //    htmlErrors += '<li class="list-group-item list-group-item-dange">' + error + '</li>'
            //    htmlErrors += '<ul>'
            //    htmlErrors += error + "\n"
            //});
            setupAndShowErrorDialog(htmlErrors);
        }
    }
}

$(document).ajaxComplete(function (event, xhr, settings) {
    let response = xhr.responseJSON;
    if (response && response.hasOwnProperty("succeded"))
    {
        var result = new Result(response.succeded, response.payload, response.errors)
        if (!result.succeded) {
            result.processErrors();
        }
    }
});

function setupAndShowErrorDialog(messagesHtml) {
    $("#error-toast-body").empty().html(messagesHtml ?? "Generic Error!");
    $("#error-toast").toast('show');

    //$("#error_modal_message_body").empty().html("<p>" + (messagesHtml ?? "Generic Error!") + "</p>")
    //$("#error_modal").modal('show');
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

function refreshValidationForFormWithSelector(selector) {
    if (!$(selector)[0]) return;
    var form = $(selector)
        .removeData("validator") 
        .removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(form);
}

function showSuccessAlertWithMessage(message) {
    $("#global-success-alert-message").empty().text(message);
    $("#global-success-alert").show();
}

function showErrorAlertWithMessage(message) {  
    $("#global-error-alert-message").empty().text(message);
    $("#global-error-alert").show();
}