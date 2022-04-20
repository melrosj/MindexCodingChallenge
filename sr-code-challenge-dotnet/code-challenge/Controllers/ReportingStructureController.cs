using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/reportingStructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportStructureService _reportStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportStructureService reportStructureService)
        {
            _logger = logger;
            _reportStructureService = reportStructureService;
        }

        /// <summary>
        /// Gets a reporting structure 
        /// </summary>
        /// <param name="id">The id of the employee that the report structure should be displayed for</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult GetReportingStructureById(String id)
        {
            _logger.LogDebug($"Received Reporting Structure get request for '{id}'");

            var reportStructure = _reportStructureService.GetReportStructureById(id);

            if (reportStructure == null)
                return NotFound();


            return Ok(reportStructure);
        }
    }
}
