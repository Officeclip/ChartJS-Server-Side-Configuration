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