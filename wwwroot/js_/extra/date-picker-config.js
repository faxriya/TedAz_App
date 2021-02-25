jQuery.fn.exists = function(){ return this.length > 0; }
if ($("#datepicker").exists()) {
    var picker = new Lightpick({
        field: document.getElementById('datepicker'),
        singleDate: false
    });
}
if ($("#datepicker-2").exists()) {
    var picker = new Lightpick({
        field: document.getElementById('datepicker-2'),
        singleDate: false
    });
}

   