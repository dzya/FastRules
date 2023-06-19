using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public interface IOperation
    {
        public OperationIds Id { get; }

        public bool Result { get; }
    }
}
