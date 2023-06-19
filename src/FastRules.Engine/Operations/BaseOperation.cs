using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public abstract class BaseOperation : IOperation
    {
        public abstract OperationIds Id { get; }

        public abstract bool Result { get; }
    }
}
