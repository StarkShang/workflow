using System.Threading.Tasks;

namespace Workflow {
    public abstract class WorkTask: Unit {

        public async Task Run(object? param) {
            var result = await Excute(param);
            await Next(result);
        } 
        public abstract Task<object?> Excute(object? param);
    }
}