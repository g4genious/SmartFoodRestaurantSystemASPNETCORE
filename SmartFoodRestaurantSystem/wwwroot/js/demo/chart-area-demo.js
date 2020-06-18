// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

function number_format(number, decimals, dec_point, thousands_sep) {
  // *     example: number_format(1234.56, 2, ',', ' ');
  // *     return: '1 234,56'
  number = (number + '').replace(',', '').replace(' ', '');
  var n = !isFinite(+number) ? 0 : +number,
    prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
    sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
    dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
    s = '',
    toFixedFix = function(n, prec) {
      var k = Math.pow(10, prec);
      return '' + Math.round(n * k) / k;
    };
  // Fix for IE parseFloat(0.55).toFixed(0) = 0;
  s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
  if (s[0].length > 3) {
    s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
  }
  if ((s[1] || '').length < prec) {
    s[1] = s[1] || '';
    s[1] += new Array(prec - s[1].length + 1).join('0');
  }
  return s.join(dec);
}

var jan = document.getElementById("jan").innerHTML;
var feb = document.getElementById("feb").innerHTML;
var mar = document.getElementById("mar").innerHTML;
var apr = document.getElementById("apr").innerHTML;
var may = document.getElementById("may").innerHTML;
var jun = document.getElementById("jun").innerHTML;
var jul = document.getElementById("jul").innerHTML;
var aug = document.getElementById("aug").innerHTML;
var sep = document.getElementById("sep").innerHTML;
var oct = document.getElementById("oct").innerHTML;
var nov = document.getElementById("nov").innerHTML;
var dec = document.getElementById("dec").innerHTML;

// Area Chart Example

var ctx = document.getElementById("myAreaChart");
var myLineChart = new Chart(ctx, {
  type: 'line',
  data: {
    labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
    datasets: [{
      label: "Earnings",
        lineTension: 0.3,
        backgroundColor: "rgba(101, 172, 220)",
        borderColor: "rgb(101, 172, 220)",
      pointRadius: 6,
      pointBackgroundColor: "rgb(20, 40, 188)",
        pointBorderColor: "#FFFFFF",
      pointHoverRadius: 3,
        pointHoverBackgroundColor: "rgb(101, 172, 220)",
        pointHoverBorderColor: "rgb(101, 172, 220)",
      pointHitRadius: 10,
      pointBorderWidth: 3,
      data: [jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec],
    }],
  },
  options: {
    maintainAspectRatio: false,
    layout: {
      padding: {
        left: 10,
        right: 25,
        top: 25,
        bottom: 0
      }
    },
    scales: {
      xAxes: [{
        time: {
          unit: 'date'
        },
        gridLines: {
          display: false,
          drawBorder: false
        },
        ticks: {
          maxTicksLimit: 7
        }
      }],
      yAxes: [{
        ticks: {
          maxTicksLimit: 5,
          padding: 10,
          // Include a dollar sign in the ticks
          callback: function(value, index, values) {
            return 'Rs.' + number_format(value);
          }
        },
        gridLines: {
            color: "rgb(101, 172, 220)",
          zeroLineColor: "rgb(234, 236, 244)",
          drawBorder: false,
          borderDash: [4],
          zeroLineBorderDash: [2]
        }
      }],
    },
      legend: {
          display: true
    },
    tooltips: {
      backgroundColor: "rgb(255,255,255)",
      bodyFontColor: "#858796",
      titleMarginBottom: 10,
      titleFontColor: '#6e707e',
      titleFontSize: 14,
      borderColor: '#dddfeb',
      borderWidth: 1,
      xPadding: 15,
      yPadding: 15,
      displayColors: false,
      intersect: false,
      mode: 'index',
      caretPadding: 10,
      callbacks: {
        label: function(tooltipItem, chart) {
          var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
          return datasetLabel + ': Rs.' + number_format(tooltipItem.yLabel);
        }
      }
    }
  }
});
