using System.Threading.Tasks;
using Workflow;

namespace console
{
    class Program {
        static async Task Main(string[] args) {
            var trigger = new TimerTrigger();
            var task1 = new FunctionTask(async (param) => {
                await System.Console.Out.WriteLineAsync("task1");
                return "task1";
            });
            var task2 = new FunctionTask(async (param) => {
                await System.Console.Out.WriteLineAsync("task2");
                return null;
            });
            var task3 = new FunctionTask(async (param) => {
                await System.Console.Out.WriteLineAsync("task3");
                return null;
            });
            var workflow = new Workflow.Workflow()
                .SetTrigger(trigger)
                .AddTask(trigger.Id, task1)
                .AddTask(trigger.Id, task2)
                .AddTask(task1.Id, task3);
            await workflow.Run();

            while (true) { }
        }
    }
}
