﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSON
{
    class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TempratureCelsius { get; set; }
        public string Summary { get; set; }
    }
}
