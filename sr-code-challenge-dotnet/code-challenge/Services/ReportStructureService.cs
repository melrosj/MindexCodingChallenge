using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class ReportStructureService : IReportStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public ReportStructureService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        private Employee GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _employeeRepository.GetById(id);
            }

            return null;
        }

        public ReportingStructure GetReportStructureById(string id)
        {
            Employee emp = null;
            ReportingStructure reportingStructure = new ReportingStructure();
            if(!String.IsNullOrEmpty(id))
            {
                emp = GetById(id);
                reportingStructure.NumberOfReports = GetNumberOfReports(emp);
                reportingStructure.EmployeeObject = emp;

                return reportingStructure;
            }

            return null;
        }

        /// <summary>
        /// An Iterative function that is designed to traverse through an employee's direct report tree and count the number of reports
        /// </summary>
        /// <param name="emp">Employee to check for subordinates</param>
        private int GetNumberOfReports(Employee emp)
        {
            Stack<Employee> empStack = new Stack<Employee>();
            int count = 0;

            empStack.Push(emp); //Push the initial employee onto the stack

            while(empStack.Count != 0)
            {
                Employee node = empStack.Pop(); //Pop top employee and count directt reports on that employee

                if (node.DirectReports != null)
                {
                    foreach (Employee e in node.DirectReports)
                    {
                        empStack.Push(GetById(e.EmployeeId)); //Push the subordinate employee to the stack
                        count++;
                    }
                }
            }

            return count;

            // Originally implemented solution that used recursion instead of iteration
            // The original implementation took in an initial employee and a refrence to a queue. the number of reports was determined by the size of the queue

            /*if (emp.DirectReports != null)
            {
                for (int i = 0; i < emp.DirectReports.Count; i++)
                {
                    var employee = GetById(emp.DirectReports[i].EmployeeId);
                    if (employee != null)
                    {
                        empQueue.Enqueue(employee); //Add employee to the queue
                        AddEmployeeToQueue(employee, empQueue); //Call this functtion again and pass in the new subordinate employee to check for direct reports
                    }
                }
            }*/
        }
    }
}
