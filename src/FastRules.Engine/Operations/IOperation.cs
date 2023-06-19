using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public interface IOperation<T>
    {
        public T LeftOperand { get; set; }

        public T RightOperand { get; set; }

        public OperationIds Id { get; }

        public bool Result { get; }
    }
}
