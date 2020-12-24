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
    public class HackMDController : ControllerBase
    {
        private readonly ILogger<HackMDController> _logger;
        private readonly SpeakerService _speakerService;

        public HackMDController(ILogger<HackMDController> logger, SpeakerService speakerService)
        {
            _logger = logger;
            _speakerService = speakerService;
        }

        [HttpGet]
        public IEnumerable<HackMDModel> Get()
        {
            return _speakerService.GetSpeakers()
                .Where(p => p.Tags.Contains("HackMD"))
                .Select(p => new HackMDModel
                {
                    speaker_name = p.Name,
                    title = p.Topic,
                    classroom = p.Room,
                    track = p.Track,
                    session_start = p.SessionStart,
                    session_end = p.SessionEnd,
                    summary = p.TopicOutline,
                });
        }
    }

    public class HackMDModel
    {
        public string speaker_name { get; set; }
        public string title { get; set; }
        public string classroom { get; set; }
        public string track { get; set; }
        public DateTime session_start { get; set; }
        public DateTime session_end { get; set; }
        public string summary { get; set; }
    }
}
