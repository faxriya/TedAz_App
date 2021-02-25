var defaultData = 'https://demo-live-data.highcharts.com/time-data.csv';
// var urlInput = document.getElementById('fetchURL');
// var pollingCheckbox = document.getElementById('enablePolling');
// var pollingInput = document.getElementById('pollingTime');

function createChart() {
  Highcharts.chart('containerCompare', {
    chart: {
      type: 'spline'
    },
    title: {
        text:""
      },
    credits: {
        enabled: false
    },
    accessibility: {
      announceNewData: {
        enabled: true,
        minAnnounceInterval: 15000,
        announcementFormatter: function (allSeries, newSeries, newPoint) {
          if (newPoint) {
            return 'New point added. Value: ' + newPoint.y;
          }
          return false;
        }
      }
    },
    data: {
      csvURL: defaultData,
      enablePolling: false,
    //   dataRefreshRate: parseInt(pollingInput.value, 10)
    }
  });

    // pollingInput.value = 0;
  
}

// urlInput.value = defaultData;

// We recreate instead of using chart update to make sure the loaded CSV
// and such is completely gone.
// pollingCheckbox.onchange = urlInput.onchange = pollingInput.onchange = createChart;

// Create the chart
createChart();
