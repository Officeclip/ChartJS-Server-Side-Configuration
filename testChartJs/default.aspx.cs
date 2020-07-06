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

        private ChartConfiguration CreateServerConfiguration()
        {
            var unit = "ms";
            var dataSets = new List<DataSetItem>();
            for (int i = 1; i <= 5; i++)
            {
                var dataSetItem = new DataSetItem()
                {
                    Label = i.ToString(),
                    Data = Util.CreateRandomInts(60, 230),
                    BorderWidth = 1,
                    BackgroundColor = LibChart.Util.GetColors(i % 5),
                    BorderColor = LibChart.Util.GetColors(i % 5)[0],
                    Fill = false
                };
                dataSets.Add(dataSetItem);
            }
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
                    Labels = Util.CreateLabels(1, 60),
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