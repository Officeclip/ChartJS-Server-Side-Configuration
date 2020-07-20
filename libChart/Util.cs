using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibChart
{
    public static class Util
    {
        /// <summary>
        /// Check the link to verify the colors mentioned in the string https://convertingcolors.com/
        /// </summary>
        /// <returns></returns>
        public static List<string> GetColors()
        {
            return new List<string>
                            {
                                "rgba(255, 99, 132, 0.8)",
                                "rgba(54, 162, 235, 0.8)",
                                "rgba(255, 206, 86, 0.8)",
                                "rgba(75, 192, 192, 0.8)",
                                "rgba(153, 102, 255, 0.8)",
                                "rgba(255, 159, 64, 0.8)",
                                "rgba(144, 12, 63,0.8)",
                                "rgba(8, 73, 35,0.8)",
                                "rgba(246, 20, 4, 0.8)"
                            };
        }

        public static List<string> GetColors(int i)
        {
            var colors = GetColors();
            return new List<string>() { colors[i] };
        }

    }
}
