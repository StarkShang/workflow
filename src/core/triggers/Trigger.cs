using System.Threading.Tasks;

namespace Workflow
{
    public abstract class Trigger: Unit {
        public abstract Task Run();
    }
}