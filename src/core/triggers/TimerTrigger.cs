using System.Threading.Tasks;

namespace Workflow {
    public class TimerTrigger: Trigger {
        public async override Task Run() {
            await Timer.AddHandler(async () => await Next(null));
        }
    }
}