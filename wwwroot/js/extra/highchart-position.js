Highcharts.chart('container-position', {
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
        text:" "
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
      color:'#6698ff',
      data: [1000, 1000, 1000, 1000, 1000, 1000, 1000]
    }, {
      name: 'Mənfi',
      color:'#ff7066',
      data: [100, 100, 100, 100, 100, 100, 100]
    }]
  });