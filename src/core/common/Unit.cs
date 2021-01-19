using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workflow
{
    public class Unit: Model {
        public void AddTask(WorkTask task) {
            _tasks.Add(task);
        }

        public async Task Next(object? param) {
            foreach (var task in _tasks) {
                await task.Run(param);
            }
        }

        protected readonly List<WorkTask> _tasks;
        public Unit() {
            _tasks = new List<WorkTask>();
        }
    }
}