
$(window).on("load", function(){
    var ctx = $("#column-chart");
    var chartOptions = {
        elements: {
            rectangle: {
                borderWidth: 2,
                borderColor: 'rgb(0, 255, 0)',
                borderSkipped: 'bottom'
            }
        },
        responsive: true,
        maintainAspectRatio: false,
        responsiveAnimationDuration:500,
        legend: {
            position: 'top',
        },
        scales: {
            xAxes: [{
                display: true,
                gridLines: {
                    color: "#f3f3f3",
                    drawTicks: false,
                },
                scaleLabel: {
                    display: true,
                }
            }],
            yAxes: [{
                display: true,
                gridLines: {
                    color: "#f3f3f3",
                    drawTicks: false,
                },
                scaleLabel: {
                    display: true,
                }
            }]
        },
        title: {
            display: true,
            text: 'Chart.js Bar Chart'
        }
    };

    var chartData = {
        labels: ["Class 1", "Class 2", "Class 3", "Class 4", "Class 5","Class 6", "Class 7", "Class 8"],
        datasets: [{
            label: "Boys",
            data: [25, 15, 20, 22, 18, 25, 20, 30],
            backgroundColor: "#28D094",
            hoverBackgroundColor: "rgba(22,211,154,.9)",
            borderColor: "transparent"
        }, {
            label: "Girls",
            data: [25, 15, 20, 22, 18, 25, 20, 30],
            backgroundColor: "#F98E76",
            hoverBackgroundColor: "rgba(249,142,118,.9)",
            borderColor: "transparent"
        }]
    };

    var config = {
        type: 'bar',
        options : chartOptions,
        data : chartData
    };

    var lineChart = new Chart(ctx, config);
});