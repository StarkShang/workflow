using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workflow {
    public class Workflow {
        public async Task Run() {
            if (_trigger == null) {
                throw new ArgumentNullException(nameof(_trigger), "未设置trigger");
            }
            await _trigger.Run();
        }

        public Workflow SetTrigger(Trigger trigger) {
            if (_trigger != null) { _units.Remove(_trigger.Id); }
            _trigger = trigger;
            _units.Add(_trigger.Id, _trigger);
            return this;
        }

        public Workflow AddTask(string parentId, WorkTask task) {
            if (_units.TryGetValue(parentId, out var unit)) {
                unit.AddTask(task);
            }
            if (!_units.ContainsKey(task.Id)) {
                _units.Add(task.Id, task);
            }
            return this;
        }

        private Trigger? _trigger;
        private Dictionary<string, Unit> _units = new Dictionary<string, Unit>();
    }
}