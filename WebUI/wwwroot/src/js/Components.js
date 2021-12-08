var ToastType = 
{
    "info": 1,
    "success": 2,
    "error": 3
}

function Toaster(toastContainer) {
    var _this = this;
    this.currentStack = [];
    
    this.container = (function(){  
        var providedContainer = toastContainer ? $(toastContainer) : [];
        if(providedContainer.length == 0) {
            return $("<div></div>")
        }
        return providedContainer;
    })() 

    this.showSingle = function(toastType, message) {
        let toast = $(createToast(toastType, message));
        _this.container.empty().append(toast);
        toast.toast('show');
        _this.currentStack = [toast];
    }

    this.stack = function(toastType, message) {
        let toast = $(createToast(toastType, message));
        _this.container.append(toast);
        toast.toast('show');
        _this.currentStack.push(toast);
    }

    this.clear = function() {
        currentStack = [];
        this.container.empty();
    }

    function createToast(toastType, message) {
        var bgColorClass = "bg-light";
        var textColorClass = "text-black";
        var closeBtnClass = "btn-close"

        switch (toastType) {
          case ToastType.success:
            bgColorClass = "bg-success";
            textColorClass = "text-white";
            closeBtnClass = "btn-close btn-close-white"
            break;
          case ToastType.error:
            bgColorClass = "bg-danger";
            textColorClass = "text-white";
            closeBtnClass = "btn-close btn-close-white"
            break;
        }

       var toastHtml = 
       [
            '<div class="toast align-items-center rounded '+bgColorClass+'" role="alert" aria-live="assertive" aria-atomic="true">',
                '<div class="d-flex">',
                    '<div class="toast-body fw-bold '+textColorClass+'">',
                        message ?? '',
                    '</div>',
                    '<button '+textColorClass+' type="button" class="'+closeBtnClass+' me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>',
                '</div>',
            '</div>'
        ].join(""); 
        return toastHtml;
    }
}

    