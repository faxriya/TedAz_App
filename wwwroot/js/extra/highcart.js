// ============================== Review main=====================
   $.ajax({
         url: `/Analytic/Data`,
         type: 'POST',
         data: { id: 6 },
       success: function (data) {
             console.log("test")
             var obj = JSON.parse(data);
             var processed_json = new Array();
             for (i = 0; i < obj.dates.length; i++) {
                 processed_json.push([Date.parse(new Date(obj.dates[i].key)), obj.dates[i].count]);

             }
           Highcharts.getJSON(
    'https://cdn.jsdelivr.net/gh/highcharts/highcharts@v7.0.0/samples/data/usdeur.json',
    function (data) {

        Highcharts.chart('containerReview_Main', {
            chart: {
                zoomType: 'x'
            },
            title: {
                text: ' '
            },
            subtitle: {
                text: document.ontouchstart === undefined ?
                    ' ' : 'Pinch the chart to zoom in'
            },
            credits: {
                enabled: false
            },
            xAxis: {
                enableMouseTracking: true,

                type: 'datetime',


            },
            yAxis: {
                title: {
                    text: ' '
                }
            },
            legend: {
                enabled: false
            },

            plotOptions: {
                enableMouseTracking: true,

                area: {
                    fillColor: {
                        linearGradient: {
                            x1: 0,
                            y1: 0,
                            x2: 0,
                            y2: 1
                        },
                        stops: [
                            [0, Highcharts.getOptions().colors[0]],
                            [1, Highcharts.color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                        ]
                    },
                    marker: {
                        radius: 3
                    },
                    lineWidth: 2,
                    states: {
                        hover: {
                            lineWidth: 2
                        }
                    },
                    threshold: null
                }
            },

            series: [{
                type: 'area',
                name: 'Qeydlər',
                data: processed_json
            }]
        });
    }
);
         },
         error: function (resp) {
             console.error(resp);
         }
     })