using ChartServerConfiguration.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace testChartJs
{
    public partial class IssueStatus : System.Web.UI.Page
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
                Data = new List<int?> { 288, 1493, 305, 27, 5, 174, 86, 72, 20 },
                BackgroundColor = LibChart.Util.GetColors(),
            };
            dataSets.Add(dataSetItem);

            var chartConfig = new ChartConfiguration
            {
                Type = ChartType.pie.GetChartType(),
                Data =
                {
                    Labels = new List<string> { "Open", "Closed", "Resolved", "Reopened", "Pending", "Not A Bug", "Can't Replicate", "Discuss", "Fix in next Release" },
                    Datasets = dataSets
                },
                Options =
                {
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