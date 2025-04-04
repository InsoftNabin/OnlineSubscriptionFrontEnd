(function (factory) {
  typeof define === 'function' && define.amd ? define(factory) :
  factory();
})((function () { 'use strict';

  // import * as echarts from 'echarts';
  const { merge } = window._;

  // form config.js
  const echartSetOption = (
    chart,
    userOptions,
    getDefaultOptions,
    responsiveOptions
  ) => {
    const { breakpoints, resize } = window.phoenix.utils;
    const handleResize = options => {
      Object.keys(options).forEach(item => {
        if (window.innerWidth > breakpoints[item]) {
          chart.setOption(options[item]);
        }
      });
    };

    const themeController = document.body;
    // Merge user options with lodash
    chart.setOption(merge(getDefaultOptions(), userOptions));

    resize(() => {
      chart.resize();
      if (responsiveOptions) {
        handleResize(responsiveOptions);
      }
    });
    if (responsiveOptions) {
      handleResize(responsiveOptions);
    }

    themeController.addEventListener(
      'clickControl',
      ({ detail: { control } }) => {
        if (control === 'phoenixTheme') {
          chart.setOption(window._.merge(getDefaultOptions(), userOptions));
        }
      }
    );
  };
  // -------------------end config.js--------------------

  const resizeEcharts = () => {
    const $echarts = document.querySelectorAll('[data-echart-responsive]');

    if ($echarts.length > 0) {
      $echarts.forEach(item => {
        const echartInstance = echarts.getInstanceByDom(item);
        echartInstance?.resize();
      });
    }
  };

  const navbarVerticalToggle = document.querySelector('.navbar-vertical-toggle');
  navbarVerticalToggle &&
    navbarVerticalToggle.addEventListener('navbar.vertical.toggle', e => {
      return resizeEcharts();
    });

  const echartTabs = document.querySelectorAll('[data-tab-has-echarts]');
  echartTabs &&
    echartTabs.forEach(tab => {
      tab.addEventListener('shown.bs.tab', e => {
        const el = e.target;
        const { hash } = el;
        const id = hash ? hash : el.dataset.bsTarget;
        const content = document.getElementById(id.substring(1));
        const chart = content?.querySelector('[data-echart-tab]');
        chart && window.echarts.init(chart).resize();
      });
    });

  const tooltipFormatter = (params, dateFormatter = 'MMM DD') => {
    let tooltipItem = ``;
    params.forEach(el => {
      tooltipItem += `<div class='ms-1'>
        <h6 class="text-700"><span class="fas fa-circle me-1 fs--2" style="color:${
          el.borderColor ? el.borderColor : el.color
        }"></span>
          ${el.seriesName} : ${
      typeof el.value === 'object' ? el.value[1] : el.value
    }
        </h6>
      </div>`;
    });
    return `<div>
            <p class='mb-2 text-600'>
              ${
                window.dayjs(params[0].axisValue).isValid()
                  ? window.dayjs(params[0].axisValue).format(dateFormatter)
                  : params[0].axisValue
              }
            </p>
            ${tooltipItem}
          </div>`;
  };

  // dayjs.extend(advancedFormat);

  /* -------------------------------------------------------------------------- */
  /*                             Echarts Total Sales                            */
  /* -------------------------------------------------------------------------- */

  const contactsBySourceChartInit = () => {
    const { getColor, getData } = window.phoenix.utils;
    const chartElContainer = document.querySelector(
      '.echart-contact-by-source-container'
    );
    const chartEl = chartElContainer.querySelector('.echart-contact-by-source');
    const chartLabel = chartElContainer.querySelector('[data-label]');

    if (chartEl) {
      const userOptions = getData(chartEl, 'echarts');
      const chart = window.echarts.init(chartEl);
      const data = [
        { value: 80, name: 'Organic Search' },
        { value: 65, name: 'Paid Search' },
        { value: 40, name: 'Direct Traffic' },
        { value: 220, name: 'Social Media' },
        { value: 120, name: 'Referrals' },
        { value: 35, name: 'Others Campaigns' },
      ];
      const totalSource = data.reduce((acc, val) => val.value + acc, 0);
      if (chartLabel) {
        chartLabel.innerHTML = totalSource;
      }
      const getDefaultOptions = () => ({
        color: [
          getColor('primary'),
          getColor('success'),
          getColor('info'),
          getColor('info-300'),
          getColor('danger-200'),
          getColor('warning-300'),
        ],
        tooltip: {
          trigger: 'item',
        },
        responsive: true,
        maintainAspectRatio: false,

        series: [
          {
            name: 'Contacts by Source',
            type: 'pie',
            radius: ['55%', '90%'],
            startAngle: 90,
            avoidLabelOverlap: false,
            itemStyle: {
              borderColor: getColor('gray-soft'),
              borderWidth: 3,
            },

            label: {
              show: false,
            },
            emphasis: {
              label: {
                show: false,
              },
            },
            labelLine: {
              show: false,
            },
            data,
          },
        ],
        grid: {
          bottom: 0,
          top: 0,
          left: 0,
          right: 0,
          containLabel: false,
        },
      });

      echartSetOption(chart, userOptions, getDefaultOptions);
    }
  };

  // dayjs.extend(advancedFormat);

  /* -------------------------------------------------------------------------- */
  /*                     Echart Bar Member info                                 */
  /* -------------------------------------------------------------------------- */

  const newUsersChartsInit = () => {
    const { getColor, getData, getPastDates, rgbaColor } = window.phoenix.utils;
    const $echartnewUsersCharts = document.querySelector('.echarts-new-users');
    const tooltipFormatter = params => {
      const currentDate = window.dayjs(params[0].axisValue);
      const prevDate = window.dayjs(params[0].axisValue).subtract(1, 'month');

      const result = params.map((param, index) => ({
        value: param.value,
        date: index > 0 ? prevDate : currentDate,
        color: param.color
      }));

      let tooltipItem = ``;
      result.forEach((el, index) => {
        tooltipItem += `<h6 class="fs--1 text-700 ${
        index > 0 && 'mb-0'
      }"><span class="fas fa-circle me-2" style="color:${el.color}"></span>
      ${el.date.format('MMM DD')} : ${el.value}
    </h6>`;
      });
      return `<div class='ms-1'>
              ${tooltipItem}
            </div>`;
    };

    if ($echartnewUsersCharts) {
      const userOptions = getData($echartnewUsersCharts, 'echarts');
      const chart = window.echarts.init($echartnewUsersCharts);
      const dates = getPastDates(12);
      const getDefaultOptions = () => ({
        tooltip: {
          trigger: 'axis',
          padding: 10,
          backgroundColor: getColor('gray-100'),
          borderColor: getColor('gray-300'),
          textStyle: { color: getColor('dark') },
          borderWidth: 1,
          transitionDuration: 0,
          axisPointer: {
            type: 'none'
          },
          formatter: tooltipFormatter
        },
        xAxis: [
          {
            type: 'category',

            data: dates,
            show: true,
            boundaryGap: false,
            axisLine: {
              show: false
            },
            axisTick: {
              show: false
            },
            axisLabel: {
              formatter: value => window.dayjs(value).format('DD MMM, YY'),
              showMinLabel: true,
              showMaxLabel: false,
              color: getColor('gray-800'),
              align: 'left',
              interval: 5,
              fontFamily: 'Nunito Sans',
              fontWeight: 600,
              fontSize: 12.8
            }
          },
          {
            type: 'category',
            position: 'bottom',
            show: true,
            data: dates,
            axisLabel: {
              formatter: value => window.dayjs(value).format('DD MMM, YY'),
              interval: 130,
              showMaxLabel: true,
              showMinLabel: false,
              color: getColor('gray-800'),
              align: 'right',
              fontFamily: 'Nunito Sans',
              fontWeight: 600,
              fontSize: 12.8
            },
            axisLine: {
              show: false
            },
            axisTick: {
              show: false
            },
            splitLine: {
              show: false
            },
            boundaryGap: false
          }
        ],
        yAxis: {
          show: false,
          type: 'value',
          boundaryGap: false
        },
        series: [
          {
            type: 'line',
            data: [220, 220, 150, 150, 150, 250, 250, 400, 400, 400, 300, 300],
            lineStyle: {
              width: 2,
              color: getColor('info')
            },
            areaStyle: {
              color: {
                type: 'linear',
                x: 0,
                y: 0,
                x2: 0,
                y2: 1,
                colorStops: [
                  {
                    offset: 0,
                    color: rgbaColor(getColor('info'), 0.2)
                  },
                  {
                    offset: 1,
                    color: rgbaColor(getColor('info'), 0)
                  }
                ]
              }
            },
            showSymbol: false,
            symbol: 'circle'
          }
        ],
        grid: { left: 0, right: 0, top: 5, bottom: 20 }
      });
      echartSetOption(chart, userOptions, getDefaultOptions);
    }
  };

  /* -------------------------------------------------------------------------- */
  /*                     Echart Bar Member info                                 */
  /* -------------------------------------------------------------------------- */

  const newLeadsChartsInit = () => {
    const { getColor, getData, getPastDates, rgbaColor } = window.phoenix.utils;
    const $echartnewLeadsCharts = document.querySelector('.echarts-new-leads');
    const tooltipFormatter = params => {
      const currentDate = window.dayjs(params[0].axisValue);
      const prevDate = window.dayjs(params[0].axisValue).subtract(1, 'month');

      const result = params.map((param, index) => ({
        value: param.value,
        date: index > 0 ? prevDate : currentDate,
        color: param.color
      }));

      let tooltipItem = ``;
      result.forEach((el, index) => {
        tooltipItem += `<h6 class="fs--1 text-700 ${
        index > 0 && 'mb-0'
      }"><span class="fas fa-circle me-2" style="color:${el.color}"></span>
      ${el.date.format('MMM DD')} : ${el.value}
    </h6>`;
      });
      return `<div class='ms-1'>
              ${tooltipItem}
            </div>`;
    };

    if ($echartnewLeadsCharts) {
      const userOptions = getData($echartnewLeadsCharts, 'echarts');
      const chart = window.echarts.init($echartnewLeadsCharts);
      const dates = getPastDates(11);
      const getDefaultOptions = () => ({
        tooltip: {
          trigger: 'axis',
          padding: 10,
          backgroundColor: getColor('gray-100'),
          borderColor: getColor('gray-300'),
          textStyle: { color: getColor('dark') },
          borderWidth: 1,
          transitionDuration: 0,
          axisPointer: {
            type: 'none'
          },
          formatter: tooltipFormatter
        },
        xAxis: [
          {
            type: 'category',

            data: dates,
            show: true,
            boundaryGap: false,
            axisLine: {
              show: false
            },
            axisTick: {
              show: false
            },
            axisLabel: {
              formatter: value => window.dayjs(value).format('DD MMM, YY'),
              showMinLabel: true,
              showMaxLabel: false,
              color: getColor('gray-800'),
              align: 'left',
              interval: 5,
              fontFamily: 'Nunito Sans',
              fontWeight: 600,
              fontSize: 12.8
            }
          },
          {
            type: 'category',
            position: 'bottom',
            show: true,
            data: dates,
            axisLabel: {
              formatter: value => window.dayjs(value).format('DD MMM, YY'),
              interval: 130,
              showMaxLabel: true,
              showMinLabel: false,
              color: getColor('gray-800'),
              align: 'right',
              fontFamily: 'Nunito Sans',
              fontWeight: 600,
              fontSize: 12.8
            },
            axisLine: {
              show: false
            },
            axisTick: {
              show: false
            },
            splitLine: {
              show: false
            },
            boundaryGap: false
          }
        ],
        yAxis: {
          show: false,
          type: 'value',
          boundaryGap: false
        },
        series: [
          {
            type: 'line',
            data: [100, 100, 260, 250, 270, 160, 190, 180, 260, 200, 220],
            lineStyle: {
              width: 2,
              color: getColor('primary')
            },
            areaStyle: {
              color: {
                type: 'linear',
                x: 0,
                y: 0,
                x2: 0,
                y2: 1,
                colorStops: [
                  {
                    offset: 0,
                    color: rgbaColor(getColor('primary'), 0.2)
                  },
                  {
                    offset: 1,
                    color: rgbaColor(getColor('primary'), 0)
                  }
                ]
              }
            },
            showSymbol: false,
            symbol: 'circle'
          }
        ],
        grid: { left: 0, right: 0, top: 5, bottom: 20 }
      });
      echartSetOption(chart, userOptions, getDefaultOptions);
    }
  };

  /* -------------------------------------------------------------------------- */
  /*                             Echarts Total Sales                            */
  /* -------------------------------------------------------------------------- */

  const addClicksChartInit = () => {
    const { getColor, getData, getPastDates, getItemFromStore } =
      window.phoenix.utils;
    const $addClicksChart = document.querySelector('.echart-add-clicks-chart');

    // getItemFromStore('phoenixTheme')
    const dates = getPastDates(11);
    const currentMonthData = [
      2000, 2250, 1070, 1200, 1000, 1450, 3100, 2900, 1800, 1450, 1700
    ];

    const prevMonthData = [
      1100, 1200, 2700, 1700, 2100, 2000, 2300, 1200, 2600, 2900, 1900
    ];

    const tooltipFormatter = params => {
      const currentDate = window.dayjs(params[0].axisValue);
      const prevDate = window.dayjs(params[0].axisValue).subtract(1, 'month');

      const result = params.map((param, index) => ({
        value: param.value,
        date: index > 0 ? prevDate : currentDate,
        color: param.color
      }));

      let tooltipItem = ``;
      result.forEach((el, index) => {
        tooltipItem += `<h6 class="fs--1 text-700 ${
        index > 0 && 'mb-0'
      }"><span class="fas fa-circle me-2" style="color:${el.color}"></span>
      ${el.date.format('MMM DD')} : ${el.value}
    </h6>`;
      });
      return `<div class='ms-1'>
              ${tooltipItem}
            </div>`;
    };

    if ($addClicksChart) {
      const userOptions = getData($addClicksChart, 'echarts');
      const chart = window.echarts.init($addClicksChart);

      const getDefaultOptions = () => ({
        // color: [getColor('primary'), getColor('info')],
        tooltip: {
          trigger: 'axis',
          padding: 10,
          backgroundColor: getColor('gray-100'),
          borderColor: getColor('gray-300'),
          textStyle: { color: getColor('dark') },
          borderWidth: 1,
          transitionDuration: 0,
          axisPointer: {
            type: 'none'
          },
          formatter: tooltipFormatter
        },
        xAxis: [
          {
            type: 'category',
            data: dates,
            axisLabel: {
              formatter: value => window.dayjs(value).format('DD MMM, YY'),
              interval: 3,
              showMinLabel: true,
              showMaxLabel: false,
              color: getColor('gray-800'),
              align: 'left',
              fontFamily: 'Nunito Sans',
              fontWeight: 700,
              fontSize: 12.8,
              margin: 15
            },
            axisLine: {
              show: true,
              lineStyle: {
                color: getColor('gray-300')
              }
            },
            axisTick: {
              show: true,
              interval: 5
            },
            boundaryGap: false
          },
          {
            type: 'category',
            position: 'bottom',
            data: dates,
            axisLabel: {
              formatter: value => window.dayjs(value).format('DD MMM, YY'),
              interval: 130,
              showMaxLabel: true,
              showMinLabel: false,
              color: getColor('gray-900'),
              align: 'right',
              fontFamily: 'Nunito Sans',
              fontWeight: 700,
              fontSize: 12.8,
              margin: 15
            },
            axisLine: {
              show: true,
              lineStyle: {
                color: getColor('gray-300')
              }
            },
            axisTick: {
              show: true
            },
            splitLine: {
              show: false
            },
            boundaryGap: false
          }
        ],
        yAxis: {
          axisPointer: { type: 'none' },
          axisTick: 'none',
          splitLine: {
            show: true,
            lineStyle: {
              color:
                getItemFromStore('phoenixTheme') === 'dark'
                  ? getColor('gray-100')
                  : getColor('gray-200')
            }
          },
          axisLine: { show: false },
          axisLabel: {
            show: true,
            fontFamily: 'Nunito Sans',
            fontWeight: 700,
            fontSize: 12.8,
            color: getColor('gray-900'),
            margin: 25,
            // verticalAlign: 'bottom',
            formatter: value => `${value / 1000}k`
          }
          // axisLabel: { show: true }
        },
        series: [
          {
            name: 'e',
            type: 'line',
            data: prevMonthData,
            // symbol: 'none',
            lineStyle: {
              type: 'line',
              width: 3,
              color: getColor('info-200')
            },
            showSymbol: false,
            symbol: 'emptyCircle',
            symbolSize: 6,
            itemStyle: {
              color: getColor('info-200'),
              borderWidth: 3
            }
          },
          {
            name: 'd',
            type: 'line',
            data: currentMonthData,
            showSymbol: false,
            symbol: 'emptyCircle',
            symbolSize: 6,
            itemStyle: {
              color: getColor('primary'),
              borderWidth: 3
            },

            lineStyle: {
              type: 'line',
              width: 3,
              color: getColor('primary')
            }
          }
        ],
        grid: {
          right: 2,
          left: 5,
          bottom: '10px',
          top: '2%',
          containLabel: true
        },
        animation: false
      });

      echartSetOption(chart, userOptions, getDefaultOptions);
    }
  };

  // dayjs.extend(advancedFormat);

  /* -------------------------------------------------------------------------- */
  /*                             Echarts Total Sales                            */
  /* -------------------------------------------------------------------------- */

  const echartsLeadConversiontInit = () => {
    const { getColor, getData, getPastDates } = window.phoenix.utils;
    const $leadConversionChartEl = document.querySelector(
      '.echart-lead-conversion'
    );

    const dates = getPastDates(4);

    const tooltipFormatter = params => {
      let tooltipItem = ``;
      params.forEach(el => {
        tooltipItem += `<h6 class="fs--1 text-700 mb-0"><span class="fas fa-circle me-2" style="color:${el.color}"></span>
      ${el.axisValue} : ${el.value}
    </h6>`;
      });
      return `<div class='ms-1'>
              ${tooltipItem}
            </div>`;
    };

    if ($leadConversionChartEl) {
      const userOptions = getData($leadConversionChartEl, 'echarts');
      const chart = echarts.init($leadConversionChartEl);

      const getDefaultOptions = () => ({
        color: [getColor('primary'), getColor('gray-300')],
        tooltip: {
          trigger: 'axis',
          padding: [7, 10],
          backgroundColor: getColor('gray-100'),
          borderColor: getColor('gray-300'),
          textStyle: { color: getColor('dark') },
          borderWidth: 1,
          transitionDuration: 0,
          axisPointer: {
            type: 'none'
          },
          formatter: params => tooltipFormatter(params)
        },
        xAxis: {
          type: 'value',
          inverse: true,
          axisLabel: {
            show: false
          },
          show: false,
          data: dates,
          axisLine: {
            lineStyle: {
              color: getColor('gray-300')
            }
          },
          axisTick: false
        },
        yAxis: {
          data: ['Closed Won', 'Objection', 'Offer', 'Qualify Lead', 'Created'],
          type: 'category',
          axisPointer: { type: 'none' },
          axisTick: 'none',
          splitLine: {
            interval: 5,
            lineStyle: {
              color: getColor('gray-200')
            }
          },
          axisLine: { show: false },
          axisLabel: {
            show: true,
            align: 'left',
            margin: 100,
            color: getColor('gray-900')
          }
        },
        series: {
          name: 'Lead Conversion',
          type: 'bar',
          barWidth: '20px',
          showBackground: true,
          data: [
            {
              value: 1060,
              itemStyle: {
                color: getColor('success-200'),
                borderRadius: [4, 0, 0, 4]
              },
              emphasis: {
                itemStyle: {
                  color: getColor('success-300')
                },
                label: {
                  formatter: () => `{b| 53% }`,
                  rich: {
                    b: {
                      color: getColor('white')
                    }
                  }
                }
              },
              label: {
                show: true,
                position: 'inside',
                formatter: () => `{b| 53%}`,
                rich: {
                  b: {
                    color: getColor('success-600'),
                    fontWeight: 500,
                    padding: [0, 5, 0, 0]
                  }
                }
              }
            },
            {
              value: 1200,
              itemStyle: {
                color: getColor('info-200'),
                borderRadius: [4, 0, 0, 4]
              },
              emphasis: {
                itemStyle: {
                  color: getColor('info-300')
                },
                label: {
                  formatter: () => `{b| 60% }`,
                  rich: {
                    b: {
                      color: getColor('white')
                    }
                  }
                }
              },
              label: {
                show: true,
                position: 'inside',
                formatter: () => `{b| 60%}`,
                rich: {
                  b: {
                    color: getColor('info-600'),
                    fontWeight: 500,
                    padding: [0, 5, 0, 0]
                  }
                }
              }
            },
            {
              value: 1600,
              itemStyle: {
                color: getColor('primary-200'),
                borderRadius: [4, 0, 0, 4]
              },
              emphasis: {
                itemStyle: {
                  color: getColor('primary-300')
                },
                label: {
                  formatter: () => `{b| 80% }`,
                  rich: {
                    b: {
                      color: getColor('white')
                    }
                  }
                }
              },
              label: {
                show: true,
                position: 'inside',
                formatter: () => `{b| 80% }`,
                rich: {
                  b: {
                    color: getColor('primary-600'),
                    fontWeight: 500,
                    padding: [0, 5, 0, 0]
                  }
                }
              }
            },
            {
              value: 1800,
              itemStyle: {
                color: getColor('warning-200'),
                borderRadius: [4, 0, 0, 4]
              },
              emphasis: {
                itemStyle: {
                  color: getColor('warning-300')
                },
                label: {
                  formatter: () => `{b| 90% }`,
                  rich: {
                    b: {
                      color: getColor('white')
                    }
                  }
                }
              },
              label: {
                show: true,
                position: 'inside',
                formatter: () => `{b|90%}`,
                rich: {
                  b: {
                    color: getColor('warning-600'),
                    fontWeight: 500,
                    padding: [0, 5, 0, 0]
                  }
                }
              }
            },
            {
              value: 2000,
              itemStyle: {
                color: getColor('danger-200'),
                borderRadius: [4, 0, 0, 4]
              },
              emphasis: {
                itemStyle: {
                  color: getColor('danger-300')
                },
                label: {
                  formatter: val => `{a|${val.value}}`,
                  rich: {
                    a: {
                      color: getColor('white')
                    }
                  }
                }
              },
              label: {
                show: true,
                position: 'inside',
                formatter: val => `{a|${val.value}}`,
                rich: {
                  a: {
                    color: getColor('danger-600'),
                    fontWeight: 500
                  }
                }
              }
            }
          ],
          barGap: '50%'
        },
        grid: {
          right: 5,
          left: 100,
          bottom: 0,
          top: '5%',
          containLabel: false
        },
        animation: false
      });

      const responsiveOptions = {
        xs: {
          yAxis: {
            show: false
          },
          grid: {
            left: 0
          }
        },
        sm: {
          yAxis: {
            show: true
          },
          grid: {
            left: 100
          }
        }
      };

      echartSetOption(chart, userOptions, getDefaultOptions, responsiveOptions);
    }
  };

  // dayjs.extend(advancedFormat);

  /* -------------------------------------------------------------------------- */
  /*                             Echarts Total Sales                            */
  /* -------------------------------------------------------------------------- */

  const echartsRevenueTargetInit = () => {
    const { getColor, getData } = window.phoenix.utils;
    const $leadConversionChartEl = document.querySelector(
      '.echart-revenue-target-conversion'
    );

    const tooltipFormatter = (params = 'MMM DD') => {
      let tooltipItem = ``;
      params.forEach(el => {
        tooltipItem += `<div class='ms-1'>
          <h6 class="text-700"><span class="fas fa-circle me-1 fs--2" style="color:${el.color}"></span>
            ${el.seriesName} : $${el.value}
          </h6>
        </div>`;
      });
      return `<div>
              <p class='mb-2 text-600'>
                ${params[0].axisValue}
              </p>
              ${tooltipItem}
            </div>`;
    };

    const data1 = [42000, 35000, 35000, 40000];
    const data2 = [30644, 33644, 28644, 38644];

    if ($leadConversionChartEl) {
      const userOptions = getData($leadConversionChartEl, 'echarts');
      const chart = window.echarts.init($leadConversionChartEl);

      const getDefaultOptions = () => ({
        color: [getColor('primary'), getColor('gray-300')],
        tooltip: {
          trigger: 'axis',
          padding: [7, 10],
          backgroundColor: getColor('gray-100'),
          borderColor: getColor('gray-300'),
          textStyle: { color: getColor('dark') },
          borderWidth: 1,
          transitionDuration: 0,
          axisPointer: {
            type: 'none'
          },
          formatter: params => tooltipFormatter(params)
        },
        xAxis: {
          type: 'value',
          axisLabel: {
            show: true,
            interval: 3,
            showMinLabel: true,
            showMaxLabel: false,
            color: getColor('gray-500'),
            align: 'left',
            fontFamily: 'Nunito Sans',
            fontWeight: 400,
            fontSize: 12.8,
            margin: 10,
            formatter: value => `${value / 1000}k`
          },
          show: true,
          axisLine: {
            lineStyle: {
              color: getColor('gray-300')
            }
          },
          axisTick: false,
          splitLine: {
            show: false
          }
        },
        yAxis: {
          data: ['Luxemburg', 'Canada', 'Australia', 'India'],
          type: 'category',
          axisPointer: { type: 'none' },
          axisTick: 'none',
          splitLine: {
            interval: 5,
            lineStyle: {
              color: getColor('gray-200')
            }
          },
          axisLine: { show: false },
          axisLabel: {
            show: true,
            margin: 21,
            color: getColor('gray-900')
          }
        },
        series: [
          {
            name: 'Target',
            type: 'bar',
            label: {
              show: false
            },
            emphasis: {
              disabled: true
            },
            showBackground: true,
            backgroundStyle: {
              color: getColor('gray-100')
            },
            barWidth: '30px',
            barGap: '-100%',
            data: data1,
            itemStyle: {
              borderWidth: 4,
              color: getColor('gray-200'),
              borderColor: getColor('gray-200')
            }
          },
          {
            name: 'Gained',
            type: 'bar',
            emphasis: {
              disabled: true
            },
            label: {
              show: true,
              color: getColor('white'),
              fontWeight: 700,
              fontFamily: 'Nunito Sans',
              fontSize: 12.8,
              formatter: value => `$${value.value.toLocaleString()}`
            },
            // showBackground: true,
            backgroundStyle: {
              color: getColor('gray-100')
            },
            barWidth: '30px',
            data: data2,
            itemStyle: {
              borderWidth: 4,
              color: getColor('primary-300'),
              borderColor: getColor('gray-200')
            }
          }
        ],
        grid: {
          right: 0,
          left: 0,
          bottom: 8,
          top: 0,
          containLabel: true
        },
        animation: false
      });

      echartSetOption(chart, userOptions, getDefaultOptions);
    }
  };

  const { docReady } = window.phoenix.utils;

  docReady(contactsBySourceChartInit);
 // docReady(contactsCreatedChartInit);
  docReady(newUsersChartsInit);
  docReady(newLeadsChartsInit);
  docReady(addClicksChartInit);
  docReady(echartsLeadConversiontInit);
  docReady(echartsRevenueTargetInit);

}));
//# sourceMappingURL=crm-dashboard.js.map
