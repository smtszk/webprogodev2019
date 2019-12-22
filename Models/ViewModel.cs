using System;
using System.Collections.Generic;

namespace webprogodev2019.Models
{
    public class ViewModel
    {
        public List<Haber> haberList { get; set; }

        public string errorString { get; set; }

        public string index { get; set; }

        public ViewModel()
        {
            haberList = new List<Haber>();
        }
    }
}
