var App = new function() {
    var _globalToastContainer;
    var _globalContentModal;
    var _this = this;
    var _hasLoaded = false;

    this.initialize = function() {
        if (_hasLoaded) return;     
        _globalToastContainer = $("#global_toast-container");
        _globalContentModal =  $("#content_modal");
        // Global error handler
        $(document).ajaxComplete(function (event, xhr, settings) {
            let response = xhr.responseJSON;
            if (response && response.hasOwnProperty("succeded"))
            {
                var result = new Result(response.succeded, response.payload, response.errors);
                var errors = result.processErrors();
        
                if (errors.length > 0) {
                    _this.showErrors(errors);
                }
            }
        });

        _hasLoaded = true;

        _this.toaster = new Toaster(_globalToastContainer);
    }
    
    this.showErrors = function(errors) {
        if (!Array.isArray(errors)) return;
        _this.toaster.clear();
        errors.forEach(error => {
            _this.toaster.stack(ToastType.error, error);
        });     
    }

    this.refreshValidationForFormWithSelector = function(selector) {
        if (!$(selector)[0]) return;
        var form = $(selector)
            .removeData("validator") 
            .removeData("unobtrusiveValidation");
        $.validator.unobtrusive.parse(form);
    }

    this.flushContentModal = function() {
        _globalContentModal.modal('hide');
        _globalContentModal.find(".modal-content").empty();    
    }

    $(document).ready(function() {
        _this.initialize();
    });
}