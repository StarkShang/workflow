using System;

namespace Workflow {
    public abstract class Model {
        public readonly string Id;
        public Model() {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}