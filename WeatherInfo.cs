using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class WeatherInfo
    {
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
        }

        public class main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
        }

        public class sys
        {
           public string country { get; set; }
        }
        public class root
        {
            public List<weather> weather { get; set; }
            public main main { get; set; }
            public sys sys { get; set; }    
        }
    }
}
