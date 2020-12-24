using dotnetConf2020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeakerController : ControllerBase
    {
        private readonly ILogger<SpeakerController> _logger;
        private readonly SpeakerService _speakerService;

        public SpeakerController(ILogger<SpeakerController> logger, SpeakerService speakerService)
        {
            _logger = logger;
            _speakerService = speakerService;
        }

        [HttpGet]
        public IEnumerable<SpeakerModel> Get()
        {
            return _speakerService.GetSpeakers()
                .Where(p => p.Tags.Contains("HackMD"));
        }
    }
}
