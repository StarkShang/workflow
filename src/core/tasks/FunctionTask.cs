using System;
using System.Threading.Tasks;

namespace Workflow {
    public class FunctionTask: WorkTask {
        public override async Task<object?> Excute(object? param) {
            return await _function.Invoke(param);
        }

        private readonly Func<object?, Task<object?>> _function;

        public FunctionTask(Func<object?, Task<object?>> function) {
            _function = function;
        }
    }
}