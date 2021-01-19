using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workflow;

namespace service.Controllers
{
    [ApiController]
    [Route("workflows")]
    public class WorkflowController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _scheduler.Workflows.Select(workflow => workflow.Id).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetWorkflowById([FromRoute] string id) {
            return _scheduler.GetWorkflowById(id)?.Id;
        }

        private readonly ILogger<WorkflowController> _logger;
        private readonly WorkflowScheduler _scheduler;
        public WorkflowController(
            WorkflowScheduler scheduler,
            ILogger<WorkflowController> logger)
        {
            _scheduler = scheduler;
            _logger = logger;
        }
    }
}
