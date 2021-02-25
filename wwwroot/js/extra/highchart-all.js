console.log("chart-all")


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
});
