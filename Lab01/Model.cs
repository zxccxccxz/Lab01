﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    sealed class Model
    {
        public DateTime BirthDate { get; set; }
        public string AsianSign { get; set; }
        public string WesternSign { get; set; }

        public Model()
        {
            BirthDate = DateTime.Now.AddDays(-1);
        }
    }
}
