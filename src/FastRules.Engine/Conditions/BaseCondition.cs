using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Conditions
{
    public abstract class BaseCondition<T> : ICondition<T>
    {
        public IOperation<T> Operation { get; set; }

        public Func<Object, T> GetLeftOperand { get; set; }

        public Func<Object, T> GetRightOperand { get; set; }

        public abstract bool IsPositive(Object fact);
    }
}
