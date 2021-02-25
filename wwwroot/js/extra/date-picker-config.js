//jQuery.fn.exists = function(){ return this.length > 0; }
//if ($("#datepicker").exists()) {
//    var picker = new Lightpick({
//        field: document.getElementById('datepicker'),
//        singleDate: false
//    });
//}
//if ($("#datepicker-2").exists()) {
//    var picker = new Lightpick({
//        field: document.getElementById('datepicker-2'),
//        singleDate: false
//    });
//}

//$(document).ready(function () {
//    $('input[name="daterange"]').daterangepicker({
//        opens: 'left',
//        format: 'YYYY-MM-DD',
//        showWeekNumbers: Boolean,
//        ranges: {
//            'Today': [moment(), moment()],
//            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
//            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
//            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
//            'This Month': [moment().startOf('month'), moment().endOf('month')],
//            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
//        },
//        alwaysShowCalendars: false,
//        opens: "right"
//    },
//        function (start, end, label) {
//            // alert('A date range was chosen: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));
//            console.log(start.format('YYYY-MM-DD'))
//        });
//});

$(document).ready(function () {
    if ($('#daterange').val().length == 0 || undefined) {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }
        today = mm + '.' + dd + '.' + yyyy;
        $('#daterange').val(today)
    }
    $('#daterange').daterangepicker(
        {
            startDate: moment().subtract('days', 29),
            endDate: moment(),
            minDate: '01/01/2012',
            maxDate: '12/31/2021',
            //dateLimit: { days: 60 },
            showDropdowns: true,
            showWeekNumbers: true,
            timePicker: true,
            timePicker24Hour: true,
            timePickerIncrement: 30,
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
                'Last 7 Days': [moment().subtract('days', 6), moment()],
                'Last 30 Days': [moment().subtract('days', 29), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            },
            opens: 'left',
            buttonClasses: ['btn btn-default'],
            applyClass: 'btn-small btn-primary',
            cancelClass: 'btn-small',
            format: 'DD.MM.YYYY',
            separator: ' - ',
            locale: {
                applyLabel: 'Submit',
                fromLabel: 'From',
                toLabel: 'To',
                customRangeLabel: 'Custom Range',
                daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                firstDay: 1
            }
        },
        function (start, end) {
            $('#daterange').val(start.format('DD.MM.YYYY H:mm') + " " + end.format('DD.MM.YYYY H:mm'))
            $('#daterange').attr("from", start.format('DD.MM.YYYY H:mm'))
            $('#daterange').attr("to", end.format('DD.MM.YYYY H:mm'))

        }
    );
});