﻿using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Models
{
    public class Compensation
    {
        public string CompensationId { get; set; }
        public Employee Employee { get; set; }
        public double Salary { get; set; }
        public DateTime EffectiveDate { get; set; }

    }
}
