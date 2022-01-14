using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoefsmidEnjo.Shared
{
    public static class Converters
    {
        public static DateTime ConvertDateTime(string dt)
        {

            String[] split = dt.Split(" ");
            int[] datesplit = split[0].Split("/").Select(s => int.Parse(s)).ToArray();
            int[] timesplit = split[1].Split(":").Select(s => int.Parse(s)).ToArray();

            return new DateTime(datesplit[2], datesplit[1], datesplit[0], timesplit[0], timesplit[1], 0);

        }


    }
}
