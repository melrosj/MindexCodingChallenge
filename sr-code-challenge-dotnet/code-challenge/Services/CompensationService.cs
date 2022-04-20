using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        public Compensation Create(Compensation compensation)
        {
            if(compensation != null )
            {
                if(_compensationRepository.GetById(compensation.CompensationId) == null) //Check to make sure the ID does not already exist since we allow the user to specify an ID
                {
                    _compensationRepository.Add(compensation);
                    _compensationRepository.SaveAsync().Wait();
                }
                else
                {
                    _logger.LogWarning("A compensation with the id: " + compensation.CompensationId + " already exists.");
                    return null;
                }

            }
            else
            {
                _logger.LogWarning("Compensation was null.");
            }

            return compensation;
        }

        public Compensation GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetById(id);
            }

            return null;
        }
    }
}
