function Result(succeded, payload, errors) 
{    
    var _this = this;
    var resultPayloadType =
    {
        empty: 0,
        json: 1,
        html: 2
    };

    this.succeded = succeded || false;
    this.payload = payload || {};
    this.errors = errors || [];
    this.payloadType = 

    this.processErrors = function() 
    {
        if (this.errors && Array.isArray(this.errors) && this.errors.length > 0) {
            return this.errors;           
        } 
        return [];
    }
}
