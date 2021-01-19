using System.Collections.Generic;

namespace Workflow {
    public class WorkflowScheduler {
        public IEnumerable<Workflow> Workflows { get { return _container.Values; } }
        public void CreateWorkflow(Workflow workflow) {
            _container.Add(workflow.Id, workflow);
        }

        public Workflow? GetWorkflowById(string id) {
            if (_container.TryGetValue(id, out var workflow)) {
                return workflow;
            } else {
                return null;
            }
        }

        private Dictionary<string, Workflow> _container = new Dictionary<string, Workflow>();
    }
}