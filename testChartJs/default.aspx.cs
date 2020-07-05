using ChartServerConfiguration.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testChartJs
{
    public partial class _default : System.Web.UI.Page
    {
        protected string chartConfigString;
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var chartConfig = CreateServerConfiguration();
            chartConfigString = chartConfig.MakeChart();
        }

        private List<int> GetData()
        {
            return new List<int>()
            {
              36,
              40,
              39,
              39,
              36,
              39,
              42,
              37,
              38,
              39,
              36,
              37,
              37,
              212,
              67,
              37,
              53,
              38,
              43,
              37,
              38,
              40,
              37,
              37,
              36,
              55,
              39,
              35,
              44,
              62,
              239,
              241,
              262,
              63,
              44,
              39,
              43,
              42,
              36,
              51,
              53,
              39,
              38,
              51,
              43,
              236,
              45,
              204
            };
        }

        private List<string> GetLabels() {
            return new List<string>()
            {
                "60",
                "59",
                "58",
                "57",
                "56",
                "55",
                "53",
                "52",
                "51",
                "50",
                "49",
                "48",
                "47",
                "46",
                "45",
                "44",
                "43",
                "42",
                "41",
                "39",
                "38",
                "37",
                "36",
                "35",
                "34",
                "33",
                "32",
                "31",
                "30",
                "29",
                "25",
                "23",
                "22",
                "21",
                "20",
                "19",
                "18",
                "17",
                "16",
                "15",
                "14",
                "13",
                "11",
                "10",
                "9",
                "5",
                "3",
                "2"
            };
        }

        private ChartConfiguration CreateServerConfiguration()
        {
            var unit = "ms";
            var dataSets = new List<DataSetItem>();
            var dataSetItem = new DataSetItem()
            {
                Label = "Ping Result",
                Data = GetData(),
                BorderWidth = 1,
                BackgroundColor = Util.GetColors(),
                BorderColor = Util.GetColors()[0],
                Fill = false
            };
            dataSets.Add(dataSetItem);
            var xAxesCallback = @"function (value, index, values) {
                                        if (value > 0) { value = -1 * value;}
                                        return value + ' min';
                                    }";

            var xAxesTicks = new Ticks()
            {
                Display = true,
                BeginAtZero = true,
                Max = 60,
                MaxTicksLimit = 12,
                Callback = (new JRaw(xAxesCallback))
            };

            var xAxesTicksItem = new TicksItem() { ticks = xAxesTicks };


            var yAxesCallback = $@"function (value, index, values) {{
                                        return value + ' {unit}';
                                    }}";

            var yAxesTicks = new Ticks()
            {
                Callback = new JRaw(yAxesCallback)
            };

            var yAxesTicksItem = new TicksItem() { ticks = yAxesTicks };

            var chartConfig = new ChartConfiguration
            {
                Type = ChartType.line.GetChartType(),
                Data =
                {
                    Labels = GetLabels(),
                    Datasets = dataSets
                },
                Options =
                {
                    Title =
                    {
                        Text = "My Test Chart"
                    },
                    Scales = new Scales()
                    {
                        XAxes = new List<TicksItem>()
                        {
                            xAxesTicksItem
                        },
                        YAxes = new List<TicksItem>()
                        {
                            yAxesTicksItem
                        }
                    }
                }
            };
            return chartConfig;
        }
    }
}