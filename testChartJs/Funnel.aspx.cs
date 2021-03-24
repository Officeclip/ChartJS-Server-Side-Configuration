using ChartServerConfiguration.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace testChartJs
{
    public partial class Funnel : System.Web.UI.Page
    {
        protected string chartConfigString;

        protected void Page_Load(object sender, EventArgs e)
        {
            var chartConfig = CreateServerConfiguration();
            chartConfigString = chartConfig.MakeChart();
        }

        private ChartConfiguration CreateServerConfiguration()
        {
            var dataSets = new List<DataSetItem>();

            DataSetItem dataSetItem = new DataSetItem()
            {
                Label = "Issues",
                Data = new List<int?> { 30, 60, 90 },
                BackgroundColor = LibChart.Util.GetColors().GetRange(0,2),
            };
            dataSets.Add(dataSetItem);

            var chartConfig = new ChartConfiguration
            {
                Type = ChartType.funnel.GetChartType(),
                Data =
                {
                    Labels = new List<string> { "Open", "Closed", "Resolved"},
                    Datasets = dataSets
                },
                Options =
                {
                    Sort = "desc",
                    Title =
                    {
                        Text = "My Test Chart"
                    },
                    
                }
            };
            return chartConfig;
        }

    }
}