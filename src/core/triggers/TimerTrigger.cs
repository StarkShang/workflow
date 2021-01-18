using System;
using System.Threading.Tasks;

namespace Workflow {
    public class TimerTrigger: Trigger {
        public async override Task Run() {
            await Next(null);
        }
    }
}