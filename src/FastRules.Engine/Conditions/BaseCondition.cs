using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Conditions
{
    public abstract class BaseCondition<T> : ICondition<T>
    {
        public IOperation<T> Operation { get; set; }

        public Func<Fact, T> GetLeftOperand { get; set; }

        public Func<Fact, T> GetRightOperand { get; set; }

        public abstract bool IsPositive(Fact fact);
    }
}
