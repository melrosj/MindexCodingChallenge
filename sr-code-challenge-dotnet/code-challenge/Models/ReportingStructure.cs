using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Models
{
    /// <summary>
    /// A class that contains an initial employee as well as the total number of employees that report to the initial employee
    /// </summary>
    public class ReportingStructure
    {
        public Employee EmployeeObject { get; set; }
        public int NumberOfReports { get; set; }
    }
}
