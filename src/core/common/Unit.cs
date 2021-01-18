using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workflow
{
    public class Unit {
        public void AddTask(WorkTask task) {
            _tasks.Add(task);
        }

        public async Task Next(object? param) {
            foreach (var task in _tasks) {
                await task.Run(param);
            }
        }

        public readonly string Id;
        protected readonly List<WorkTask> _tasks;
        public Unit() {
            Id = Guid.NewGuid().ToString("N");
            _tasks = new List<WorkTask>();
        }
    }
}