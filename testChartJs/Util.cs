using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace testChartJs
{
    public static class Util
    {
        public static List<string> GetColors()
        {
            return new List<string>
                            {
                                "rgba(255, 99, 132, 0.8)",
                                "rgba(54, 162, 235, 0.8)",
                                "rgba(255, 206, 86, 0.8)",
                                "rgba(75, 192, 192, 0.8)",
                                "rgba(153, 102, 255, 0.8)",
                                "rgba(255, 159, 64, 0.8)"
                            };
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
            var rand = new Random();
            var rtnlist = new List<int>();

            for (int i = 0; i < length; i++)
            {
                rtnlist.Add(rand.Next(maxValue));
            }
            return rtnlist;
            //Random rand = new Random();
            //var ints = Enumerable.Range(0, length)
            //                             .Select(i => new Tuple<int, int>(rand.Next(length), i))
            //                             .OrderBy(i => i.Item1)
            //                             .Select(i => i.Item2);
            //return ints.ToList();
        }
    }
}