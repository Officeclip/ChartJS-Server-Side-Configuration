using ChartServerConfiguration.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;

namespace testChartJs
{
    public partial class TimesheetHoursData : System.Web.UI.Page
    {
        protected string chartConfigString;
        private DataSet GetData()
        {
            DataTable table1 = new DataTable("timesheetHours");
            table1.Columns.Add("billableDur", typeof(decimal));
            table1.Columns.Add("nonbillableDur", typeof(decimal));
            table1.Columns.Add("date", typeof(DateTime));
            table1.Rows.Add(8.24, 0.70, new DateTime(2020, 1, 1));
            table1.Rows.Add(1.24, 3.70, new DateTime(2020, 1, 2));
            table1.Rows.Add(7.24, 0, new DateTime(2020, 1, 3));
            table1.Rows.Add(5, 3, new DateTime(2020, 1, 4));
            var ds = new DataSet();
            ds.Tables.Add(table1);
            return ds;
        }

        private List<Tuple<string, List<int?>>> GetChartData()
        {
            var returnValue = new List<Tuple<string, List<int?>>>();
            var tuple = new Tuple<string, List<int?>>(
                                                "Billable", 
                                                new List<int?> { 8, 1, 7, 5 });
            returnValue.Add(tuple);
            tuple = new Tuple<string, List<int?>>(
                                                "Non-Billable",
                                                new List<int?> { 1, 3, 1, 5 });
            returnValue.Add(tuple);
            return returnValue;
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            var chartConfig = CreateServerConfiguration();
            chartConfigString = chartConfig.MakeChart();
        }

        private ChartConfiguration CreateServerConfiguration()
        {
            var unit = "hrs";
            var dataSets = new List<DataSetItem>();

            DataSetItem dataSetItem = new DataSetItem()
            {
                Label = "Billable",
                Data = new List<int?> { 8, 1, 7, 5 },
            };
            dataSets.Add(dataSetItem);
            dataSetItem = new DataSetItem()
            {
                Label = "Non-Billable",
                Data = new List<int?> { 1, 3, 1, 5 },
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

            //var xAxesTicksItem = new TicksItem() { ticks = xAxesTicks };


            //var yAxesCallback = $@"function (value, index, values) {{
            //                            return value + ' {unit}';
            //                        }}";

            //var yAxesTicks = new Ticks()
            //{
            //    Callback = new JRaw(yAxesCallback)
            //};

            //var yAxesTicksItem = new TicksItem() { ticks = yAxesTicks };

            var chartConfig = new ChartConfiguration
            {
                Type = ChartType.line.GetChartType(),
                Data =
                {
                    Labels = new List<string>{"Jan 1", "Jan 2", "Jan 3", "Jan 4" },
                    Datasets = dataSets
                },
                Options =
                {
                    Title =
                    {
                        Text = "My Test Chart"
                    },
                    //Scales = new Scales()
                    //{
                    //    XAxes = new List<TicksItem>()
                    //    {
                    //        xAxesTicksItem
                    //    },
                    //    YAxes = new List<TicksItem>()
                    //    {
                    //        yAxesTicksItem
                    //    }
                    //}
                }
            };
            return chartConfig;
        }

    }
}