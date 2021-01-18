using System.Threading.Tasks;

namespace Workflow
{
    public abstract class Trigger {
        public abstract Task Run();
    }
}