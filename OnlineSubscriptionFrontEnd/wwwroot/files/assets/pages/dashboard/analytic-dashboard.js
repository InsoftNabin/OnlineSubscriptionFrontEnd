'use strict';
$(document).ready(function() {
    var chart = AmCharts.makeChart("visitor", {
        "type": "serial",
        "hideCredits": true,
        "theme": "light",
        "dataDateFormat": "YYYY-MM-DD",
        "precision": 2,
        "valueAxes": [{
            "id": "v1",
            "title": "Visitors",
            "position": "left",
            "autoGridCount": false,
            "labelFunction": function(value) {
                return "$" + Math.round(value) + "M";
            }
        }, {
            "id": "v2",
            "title": "New Visitors",
            "gridAlpha": 0,
            "position": "right",
            "autoGridCount": false
        }],
        "graphs": [{
            "id": "g3",
            "valueAxis": "v1",
            "lineColor": "#feb798",
            "fillColors": "#feb798",
            "fillAlphas": 1,
            "type": "column",
            "title": "old Visitor",
            "valueField": "sales2",
            "clustered": false,
            "columnWidth": 0.5,
            "legendValueText": "$[[value]]M",
            "balloonText": "[[title]]<br /><b style='font-size: 130%'>$[[value]]M</b>"
        }, {
            "id": "g4",
            "valueAxis": "v1",
            "lineColor": "#fe9365",
            "fillColors": "#fe9365",
            "fillAlphas": 1,
            "type": "column",
            "title": "New visitor",
            "valueField": "sales1",
            "clustered": false,
            "columnWidth": 0.3,
            "legendValueText": "$[[value]]M",
            "balloonText": "[[title]]<br /><b style='font-size: 130%'>$[[value]]M</b>"
        }, {
            "id": "g1",
            "valueAxis": "v2",
            "bullet": "round",
            "bulletBorderAlpha": 1,
            "bulletColor": "#FFFFFF",
            "bulletSize": 5,
            "hideBulletsCount": 50,
            "lineThickness": 2,
            "lineColor": "#0df3a3",
            "type": "smoothedLine",
            "title": "Last Month Visitor",
            "useLineColorForBulletBorder": true,
            "valueField": "market1",
            "balloonText": "[[title]]<br /><b style='font-size: 130%'>[[value]]</b>"
        }, {
            "id": "g2",
            "valueAxis": "v2",
            "bullet": "round",
            "bulletBorderAlpha": 1,
            "bulletColor": "#FFFFFF",
            "bulletSize": 5,
            "hideBulletsCount": 50,
            "lineThickness": 2,
            "lineColor": "#fe5d70",
            // "type": "smoothedLine",
            "dashLength": 5,
            "title": "Average Visitor",
            "useLineColorForBulletBorder": true,
            "valueField": "market2",
            "balloonText": "[[title]]<br /><b style='font-size: 130%'>[[value]]</b>"
        }],
        "chartCursor": {
            "pan": true,
            "valueLineEnabled": true,
            "valueLineBalloonEnabled": true,
            "cursorAlpha": 0,
            "valueLineAlpha": 0.2
        },
        "categoryField": "date",
        "categoryAxis": {
            "parseDates": true,
            "dashLength": 1,
            "minorGridEnabled": true
        },
        "legend": {
            "useGraphSettings": true,
            "position": "top"
        },
        "balloon": {
            "borderThickness": 1,
            "cornerRadius": 5,
            "shadowAlpha": 0
        },
        "dataProvider": [{
            "date": "2013-01-16",
            "market1": 71,
            "market2": 75,
            "sales1": 5,
            "sales2": 8
        }, {
            "date": "2013-01-17",
            "market1": 74,
            "market2": 78,
            "sales1": 4,
            "sales2": 6
        }, {
            "date": "2013-01-18",
            "market1": 78,
            "market2": 88,
            "sales1": 5,
            "sales2": 2
        }, {
            "date": "2013-01-19",
            "market1": 85,
            "market2": 89,
            "sales1": 8,
            "sales2": 9
        }, {
            "date": "2013-01-20",
            "market1": 82,
            "market2": 89,
            "sales1": 9,
            "sales2": 6
        }, {
            "date": "2013-01-21",
            "market1": 83,
            "market2": 85,
            "sales1": 3,
            "sales2": 5
        }, {
            "date": "2013-01-22",
            "market1": 88,
            "market2": 92,
            "sales1": 5,
            "sales2": 7
        }, {
            "date": "2013-01-23",
            "market1": 85,
            "market2": 90,
            "sales1": 7,
            "sales2": 6
        }, {
            "date": "2013-01-24",
            "market1": 85,
            "market2": 91,
            "sales1": 9,
            "sales2": 5
        }, {
            "date": "2013-01-25",
            "market1": 80,
            "market2": 84,
            "sales1": 5,
            "sales2": 8
        }, {
            "date": "2013-01-26",
            "market1": 87,
            "market2": 92,
            "sales1": 4,
            "sales2": 8
        }, {
            "date": "2013-01-27",
            "market1": 84,
            "market2": 87,
            "sales1": 3,
            "sales2": 4
        }, {
            "date": "2013-01-28",
            "market1": 83,
            "market2": 88,
            "sales1": 5,
            "sales2": 7
        }, {
            "date": "2013-01-29",
            "market1": 84,
            "market2": 87,
            "sales1": 5,
            "sales2": 8
        }, {
            "date": "2013-01-30",
            "market1": 81,
            "market2": 85,
            "sales1": 4,
            "sales2": 7
        }]
    });

    // project and visite start
    var chart = AmCharts.makeChart("proj-earning", {
        "type": "serial",
        "hideCredits": true,
        "theme": "light",
        "dataProvider": [{
            "type": "UI",
            "visits": 10
        }, {
            "type": "UX",
            "visits": 15
        }, {
            "type": "Web",
            "visits": 12
        }, {
            "type": "App",
            "visits": 16
        }, {
            "type": "SEO",
            "visits": 8
        }],
        "valueAxes": [{
            "gridAlpha": 0.3,
            "gridColor": "#fff",
            "axisColor": "transparent",
            "color": '#fff',
            "dashLength": 0
        }],
        "gridAboveGraphs": true,
        "startDuration": 1,
        "graphs": [{
            "balloonText": "Active User: <b>[[value]]</b>",
            "fillAlphas": 1,
            "lineAlpha": 1,
            "lineColor": "#fff",
            "type": "column",
            "valueField": "visits",
            "columnWidth": 0.5
        }],
        "chartCursor": {
            "categoryBalloonEnabled": false,
            "cursorAlpha": 0,
            "zoomable": false
        },
        "categoryField": "type",
        "categoryAxis": {
            "gridPosition": "start",
            "gridAlpha": 0,
            "axesAlpha": 0,
            "lineAlpha": 0,
            "fontSize": 12,
            "color": '#fff',
            "tickLength": 0
        },
        "export": {
            "enabled": false
        }

    });

    var ctx = document.getElementById("newuserchart").getContext("2d");
    window.myDoughnut = new Chart(ctx, {
        type: 'doughnut',
        data: {
            datasets: [{
                data: [10,34,5],
                backgroundColor: ["#fe9365","#01a9ac","#fe5d70"],
                label: 'Dataset 1'
            }],
            labels: ["Satisfied", "Unsatisfied", "NA"]
        },
        options: {
            maintainAspectRatio: false,
            responsive: true,
            legend: {
                position: 'bottom',
            },
            title: {
                display: true,
                text: "",
            },
            animation: {
                animateScale: true,
                animateRotate: true
            }
        }
    });
    // sale order start
   var ctx = document.getElementById('sale-chart1').getContext("2d");
   var myChart = new Chart(ctx, {
       type: 'line',
       data: salechart('#b71c1c', [25, 30, 15, 20, 25, 30, 15, 25, 35, 30, 20, 10, 12, 1], 'transparent'),
       options: salebuildoption(),
   });
   var ctx = document.getElementById('sale-chart2').getContext("2d");
   var myChart = new Chart(ctx, {
       type: 'line',
       data: salechart('#00692c', [30, 15, 25, 35, 30, 20, 25, 30, 15, 20, 25,10, 12, 1], 'transparent'),
       options: salebuildoption(),
   });
   var ctx = document.getElementById('sale-chart3').getContext("2d");
   var myChart = new Chart(ctx, {
       type: 'line',
       data: salechart('#096567', [15, 20, 25,10, 30, 15, 25, 35, 30, 20, 25, 30, 12, 1], 'transparent'),
       options: salebuildoption(),
   });
   function salechart(a, b, f) {
       if (f == null) {
           f = "rgba(0,0,0,0)";
       }
       return {
           labels: ["1","2","3","4","5","6","7","8","9","10","11","12","13","14","15"],
           datasets: [{
               label: "",
               borderColor: a,
               borderWidth: 2,
               hitRadius: 30,
               pointRadius: 3,
               pointHoverRadius: 4,
               pointBorderWidth: 5,
               pointHoverBorderWidth: 12,
               pointBackgroundColor: Chart.helpers.color("#000000").alpha(0).rgbString(),
               // pointBorderColor: Chart.helpers.color("#000000").alpha(0).rgbString(),
               pointBorderColor: a,
               pointHoverBackgroundColor: a,
               pointHoverBorderColor: Chart.helpers.color("#000000").alpha(.1).rgbString(),
               fill: true,
               lineTension: 0,
               backgroundColor: f,
               data: b,
           }]
       };
   }
   function salebuildoption() {
       return {
           title: {
               display: !1
           },
           tooltips: {
               position: 'nearest',
               mode: 'index',
               intersect: false,
               yPadding: 10,
               xPadding: 10,
           },
           legend: {
               display: !1,
               labels: {
                   usePointStyle: !1
               }
           },
           responsive: !0,
           maintainAspectRatio: !0,
           hover: {
               mode: "index"
           },
           scales: {
               xAxes: [{
                   display: !1,
                   gridLines: !1,
                   scaleLabel: {
                       display: !0,
                       labelString: "Month"
                   }
               }],
               yAxes: [{
                   display: !1,
                   gridLines: !1,
                   scaleLabel: {
                       display: !0,
                       labelString: "Value"
                   },
                   ticks: {
                       beginAtZero: !0
                   }
               }]
           },
           elements: {
               point: {
                   radius: 4,
                   borderWidth: 12
               }
           },
           layout: {
               padding: {
                   left: 10,
                   right: 10,
                   top: 25,
                   bottom: 25
               }
           }
       };
   }
   // sale order end
});
