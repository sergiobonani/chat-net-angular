using Financial.Bot.Application.DTOs;
using Financial.Bot.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Bot.Application.UseCases
{
    public class ProcessCommandUseCase : IProcessCommandUseCase
    {
        private ILogger<ProcessCommandUseCase> _logger;

        public ProcessCommandUseCase(ILogger<ProcessCommandUseCase> logger)
        {
            _logger = logger;
        }
        public Task ExecuteAsync(ProcessCommandDto processCommand)
        {
            throw new NotImplementedException();
        }
    }
}
