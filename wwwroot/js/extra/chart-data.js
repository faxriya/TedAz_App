function chartData(filters) {

    console.log(filters);

    // ============================== Review main=====================
    $.ajax({
        url: `/Analytic/Data`,
        dataType: 'JSON', 
        type: 'POST',
        data: { id: 6, data: JSON.stringify(filters) },
        traditional: true,
        success: function (data) {
            var obj = JSON.parse(data);
            var processed_json = new Array();
            for (i = 0; i < obj.length; i++) {
                processed_json.push([Date.parse(new Date(obj[i].name)), obj[i].count]);

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

    //=====================key MAin===============

    //$.ajax({
    //    url: `/Analytic/Data`,
    //    type: 'POST',
    //    data: { id: 2 },
    //    success: function (data) {
    //        var obj = JSON.parse(data);
    //        var processed_json = new Array();
    //        for (i = 0; i < obj.sentiments.length; i++) {
    //            processed_json.push([obj.sentiments[i].count]);

    //        }
    //        Highcharts.getJSON(
    //            'https://cdn.jsdelivr.net/gh/highcharts/highcharts@v7.0.0/samples/data/usdeur.json',
    //            function (data) {

    //                Highcharts.chart('containerKey_Main', {
    //                    chart: {
    //                        zoomType: 'x'
    //                    },
    //                    title: {
    //                        text: ' '
    //                    },
    //                    subtitle: {
    //                        text: document.ontouchstart === undefined ?
    //                            ' ' : 'Pinch the chart to zoom in'
    //                    },
    //                    credits: {
    //                        enabled: false
    //                    },
    //                    xAxis: {
    //                        enableMouseTracking: true,

    //                        type: 'datetime',


    //                    },
    //                    yAxis: {
    //                        title: {
    //                            text: ' '
    //                        }
    //                    },
    //                    legend: {
    //                        enabled: false
    //                    },

    //                    plotOptions: {
    //                        enableMouseTracking: true,

    //                        area: {
    //                            fillColor: {
    //                                linearGradient: {
    //                                    x1: 0,
    //                                    y1: 0,
    //                                    x2: 0,
    //                                    y2: 1
    //                                },
    //                                stops: [
    //                                    [0, Highcharts.getOptions().colors[0]],
    //                                    [1, Highcharts.color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
    //                                ]
    //                            },
    //                            marker: {
    //                                radius: 3
    //                            },
    //                            lineWidth: 2,
    //                            states: {
    //                                hover: {
    //                                    lineWidth: 2
    //                                }
    //                            },
    //                            threshold: null
    //                        }
    //                    },

    //                    series: [{
    //                        type: 'area',
    //                        name: 'Qeydlər',
    //                        data: processed_json
    //                    }]
    //                });
    //            }
    //        );
    //    },
    //    error: function (resp) {
    //        console.error(resp);
    //    }
    //})



    // ==========================key pie===========================

    $.ajax({
        url: `/Analytic/Data`,
        type: 'POST',
        dataType: 'JSON',
        traditional: true,
        data: { id: 4, data: JSON.stringify(filters)},
        success: function (data) {
            var data = JSON.parse(data);

            Highcharts.chart('containerKey_DistributionOfSources', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: ''
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                credits: {
                    enabled: false
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: ' {point.percentage:.1f} %'
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: [{
                        name: data[0].name,
                        y: data[0].count,
                        sliced: true,
                        selected: true
                    },
                    {
                        name: data[1].name,
                        y: data[1].count,
                    },
                    {
                        name: data[2].name,
                        y: data[2].count,
                    },
                    {
                        name: data[3].name,
                        y: data[3].count,
                    },
                    {
                        name: data[4].name,
                        y: data[4].count,
                    },
                    {
                        name: data[5].name,
                        y: data[5].count,
                    },
                    {
                        name: data[6].name,
                        y: data[6].count,
                    },

                    {
                        name: data[7].name,
                        y: data[7].count,
                    }



                    ]
                }]
            });
        },
        error: function (resp) {
            console.error(resp);
        }
    })


    // ==========================key row===========================

    //   $.ajax({
    //         url: `/Home/Data`,
    //         type: 'POST',
    //         data: { id: 6 },
    //         success: function (data) {
    //             var obj = JSON.parse(data);
    //             var processed_json = new Array();
    //             for (i = 0; i < obj.dates.length; i++) {
    //                 processed_json.push([Date.parse(new Date(obj.dates[i].key)), obj.dates[i].count]);

    //             }
    Highcharts.chart('containerKey_DistributionTime', {
        chart: {
            type: 'area'
        },

        xAxis: {
            visible: false
        },
        yAxis: {
            labels: {
                format: '{value}%'
            },
            title: {
                enabled: false
            }
        },
        credits: {
            enabled: false
        },
        tooltip: {
            pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.percentage:.1f}%</b> ({point.y:,.0f} millions)<br/>',
            split: true
        },
        title: {
            text: " "
        },
        plotOptions: {
            area: {
                stacking: 'percent',
                lineColor: '#ffffff',
                lineWidth: 1,
                marker: {
                    lineWidth: 1,
                    lineColor: '#ffffff'
                },
                accessibility: {
                    pointDescriptionFormatter: function (point) {
                        function round(x) {
                            return Math.round(x * 100) / 100;
                        }
                        return (point.index + 1) + ', ' + point.category + ', ' +
                            point.y + ' millions, ' + round(point.percentage) + '%, ' +
                            point.series.name;
                    }
                }
            }
        },
        series: [{
            name: 'Müsbət',
            color: '#aedd7a',
            data: [2000, 2000, 2000, 2000, 2000, 2000, 2000]
        }, {
            name: 'Neytral',
            color: '#6698ff',
            data: [1000, 1000, 1000, 1000, 1000, 1000, 1000]
        }, {
            name: 'Mənfi',
            color: '#ff7066',
            data: [100, 100, 100, 100, 100, 100, 100]
        }]
    });
    //     },
    //     error: function (resp) {
    //         console.error(resp);
    //     }
    // })


    // ============================== demography main=====================
    //$.ajax({
    //    url: `/Analytic/Data`,
    //    type: 'POST',
    //    data: { id: 8 },
    //    success: function (data) {
    //        var obj = JSON.parse(data);
    //        var processed_json = new Array();
    //        for (i = 0; i < obj.genders.length; i++) {
    //            processed_json.push([obj.genders[i].count]);

    //        }
    //        Highcharts.getJSON(
    //            'https://cdn.jsdelivr.net/gh/highcharts/highcharts@v7.0.0/samples/data/usdeur.json',
    //            function (data) {

    //                Highcharts.chart('containerDemography_Main', {
    //                    chart: {
    //                        zoomType: 'x'
    //                    },
    //                    title: {
    //                        text: ' '
    //                    },
    //                    subtitle: {
    //                        text: document.ontouchstart === undefined ?
    //                            ' ' : 'Pinch the chart to zoom in'
    //                    },
    //                    credits: {
    //                        enabled: false
    //                    },
    //                    xAxis: {
    //                        enableMouseTracking: true,

    //                        type: 'datetime',


    //                    },
    //                    yAxis: {
    //                        title: {
    //                            text: ' '
    //                        }
    //                    },
    //                    legend: {
    //                        enabled: true
    //                    },

    //                    plotOptions: {
    //                        enableMouseTracking: true,

    //                        area: {
    //                            fillColor: {
    //                                linearGradient: {
    //                                    x1: 0,
    //                                    y1: 0,
    //                                    x2: 0,
    //                                    y2: 1
    //                                },
    //                                stops: [
    //                                    [0, Highcharts.getOptions().colors[0]],
    //                                    [1, Highcharts.color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
    //                                ]
    //                            },
    //                            marker: {
    //                                radius: 3
    //                            },
    //                            lineWidth: 2,
    //                            states: {
    //                                hover: {
    //                                    lineWidth: 2
    //                                }
    //                            },
    //                            threshold: null
    //                        }
    //                    },

    //                    series: [{
    //                        type: 'area',
    //                        name: 'Male',
    //                        data: processed_json[0]
    //                    },
    //                    {
    //                        type: 'area',
    //                        name: 'Female',
    //                        data: processed_json[1]
    //                    }]
    //                });
    //            }
    //        );
    //    },
    //    error: function (resp) {
    //        console.error(resp);
    //    }
    //})

    // ==========================demography pie===========================

    $.ajax({
        url: `/Analytic/Data`,
        type: 'POST',
        dataType: 'JSON',
        traditional: true,
        data: { id: 8, data: JSON.stringify(filters) },
        success: function (data) {
            var data = JSON.parse(data);

            Highcharts.chart('containerDemography_DistributionMale', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: ''
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                credits: {
                    enabled: false
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: [{
                        name: data[0].name,
                        y: data[0].count,
                        sliced: true,
                        selected: true
                    },
                    {
                        name: data[1].name,
                        y: data[1].count,
                    },
                    {
                        name: data[2].name,
                        y: data[2].count,
                    },
                    {
                        name: data[3].name,
                        y: data[3].count,
                    }



                    ]
                }]
            });
        },
        error: function (resp) {
            console.error(resp);
        }
    })

    // ==========================demography row===========================

    $.ajax({
        url: `/Analytic/Data`,
        type: 'POST',
        dataType: 'JSON',
        traditional: true,
        data: { id: 2, data: JSON.stringify(filters) },
        success: function (data) {
            var data = JSON.parse(data);


            Highcharts.chart('containerDemography_DistributionAge', {
                chart: {
                    type: 'bar'
                },
                title: {
                    text: ' '
                },
                xAxis: {
                    categories: ['60+', '45-59', '35-44', '25-34', '18-24', '<18']
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: ' '
                    }
                },
                legend: {
                    reversed: true
                },
                plotOptions: {
                    series: {
                        stacking: 'normal'
                    }
                },
                series: [{

                    name: 'demography',
                    data: [{
                        name: data[0].name,
                        y: data[0].count,
                        sliced: true,
                        selected: true
                    },
                    {
                        name: data[1].name,
                        y: data[1].count,
                    },
                    {
                        name: data[2].name,
                        y: data[2].count,
                    },
                    {
                        name: data[3].name,
                        y: data[3].count,
                    }



                    ]
                }]
            });
        },
        error: function (resp) {
            console.error(resp);
        }
    })
    //})

    Highcharts.getJSON('https://demo-live-data.highcharts.com/aapl-c.json', function (data) {
        // Create the chart
        Highcharts.stockChart('containerCart-1', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerCart-2', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerCart-3', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerCart-4', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerRow-1', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerRow-2', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerRow-3', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerRow-4', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerRow-5', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerRow-6', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
        Highcharts.stockChart('containerRow-7', {

            rangeSelector: {
                selected: 1
            },
            tooltip: {
                enabled: false
            },



            navigation: {
                buttonOptions: {
                    enabled: false
                }
            },
            credits: {
                enabled: false
            },
            plotOptions: {
                series: {
                    enableMouseTracking: false,
                    states: {
                        hover: {
                            enabled: false
                        }
                    }
                }
            },
            states: { hover: 'none' },
            yAxis: {
                visible: false
            },

            xAxis: {
                visible: false
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: true
            },
            navigator: {
                enabled: false
            },

            scrollbar: { enabled: false },
            rangeSelector: {
                enabled: false

            },



            series: [{
                name: 'AAPL Stock Price',
                data: data,
                type: 'area',
                threshold: null,
                tooltip: {
                    valueDecimals: 2
                },
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
                }
            }]
        });
    })
}