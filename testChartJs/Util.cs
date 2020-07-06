using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;

namespace testChartJs
{
    public static class Util
    {
        public static List<string> GetColors(int i)
        {
            var colors = new List<string>
                            {
                                "rgba(255, 99, 132, 0.8)",
                                "rgba(54, 162, 235, 0.8)",
                                "rgba(255, 206, 86, 0.8)",
                                "rgba(75, 192, 192, 0.8)",
                                "rgba(153, 102, 255, 0.8)",
                                "rgba(255, 159, 64, 0.8)"
                            };
            return new List<string>() { colors[i] };
        }

        public static List<string> CreateLabels(int minValue, int length)
        {
            var labels = new List<string>();
            for (int i=minValue+length-1; i>=minValue; i--)
            {
                labels.Add(i.ToString());
            }
            return labels;
        }

        public static List<int> CreateRandomInts(int length, int maxValue)
        {
            Thread.Sleep(10);
            var rand = new Random((int)DateTime.Now.Ticks);
            var rtnlist = new List<int>();

            for (int i = 0; i < length; i++)
            {
                rtnlist.Add(rand.Next(maxValue));
            }
            return rtnlist;
        }
    }
}