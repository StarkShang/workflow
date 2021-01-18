using System;
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
            _trigger = trigger;
            return this;
        }

        private Trigger? _trigger;
    }
}