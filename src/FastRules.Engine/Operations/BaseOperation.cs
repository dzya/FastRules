using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public abstract class BaseOperation<T> : IOperation<T>
    {
        public T LeftOperand { get; set; }

        public T RightOperand { get; set; }

        protected Predicate<(T, T)> Predicate { get; set; }

        public abstract OperationIds Id { get; }

        public abstract bool Result { get; }
    }
}
