$(document).ready(function () {
    $.ajax({
        url: `/Analytic/Data`,
        type: 'POST',
        data: { id: 12 },
        success: function (data) {
            var obj = JSON.parse(data);

            Highcharts.getJSON('https://cdn.jsdelivr.net/gh/highcharts/highcharts@v7.0.0/samples/data/world-population-density.json', function (data) {

                // Prevent logarithmic errors in color calulcation
                data.forEach(function (p) {
                    p.value = (p.value < 1 ? 1 : p.value);
                });




                var processed_json = new Array();
                console.log(processed_json)
                for (i = 0; i < obj.length; i++) {
                    var innerMap = {};
                    innerMap["code3"] = obj[i].name.toUpperCase();

                    innerMap["value"] = obj[i].count;
                    processed_json.push(innerMap);

                }

                // Initiate the chart
                Highcharts.mapChart('containerMap', {
                    chart: {
                        map: 'custom/world'
                    },

                    title: {
                        text: 'Zoom in on country by double click'
                    },

                    mapNavigation: {
                        enabled: true,
                        enableDoubleClickZoomTo: true
                    },

                    colorAxis: {
                        min: 1,
                        max: 1000,
                        type: 'logarithmic'
                    },

                    series: [{
                        data: processed_json,
                        joinBy: ['iso-a3', 'code3'],
                        name: 'Notifications',

                        states: {
                            hover: {
                                color: '#a4edba'
                            }
                        }

                    }]
                });
            });
        },
        error: function (resp) {
            console.error(resp);
        }
    })


})