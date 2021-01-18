using System.Threading.Tasks;
using Workflow;

namespace console
{
    class Program {
        static async Task Main(string[] args) {
            var tigger = new TimerTrigger();
            var workflow = new Workflow.Workflow().SetTrigger(tigger);
            await workflow.Run();

            while (true) { }
        }
    }
}
