

$(document).ready(function () {
    Highcharts.chart('word-cloud', {

    });


    $.ajax({
        url: `/Analytic/Data`,
        type: 'POST',
        data: { id: 11 },
        success: function (data) {
            dataWord = JSON.parse(data);
            console.log(dataWord)
            console.log("test dataword")

            var text = "";
            for (let i = 0; i < dataWord.length; i++) {
                const element = dataWord[i].name;
                text = text + " " + element;
            }

            var lines = text.split(/[,\. ]+/g),
                data = Highcharts.reduce(lines, function (arr, word) {
                    var obj = Highcharts.find(arr, function (obj) {
                        return obj.name === word;
                    });
                    if (obj) {
                        obj.weight += 1;
                    } else {
                        obj = {
                            name: word,
                            weight: 1
                        };
                        arr.push(obj);
                    }
                    return arr;
                }, []);
            Highcharts.chart('word-cloud', {
                accessibility: {
                    screenReaderSection: {
                        beforeChartFormat: '<h5>{chartTitle}</h5>' +
                            '<div>{chartSubtitle}</div>' +
                            '<div>{chartLongdesc}</div>' +
                            '<div>{viewTableButton}</div>'
                    }
                },
                series: [{
                    type: 'wordcloud',
                    data: data,
                    rotation: {
                        from: 0,
                        to: 0,
                    },
                    minFontSize: 7,
                    style: {
                        fontFamily: 'Arial',
                    }
                }],
                tooltip: { enabled: false },
                title: false
            });
        },
        error: function (resp) {
            console.error(resp);
        }
    })
})