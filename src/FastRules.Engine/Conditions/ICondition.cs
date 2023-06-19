using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Conditions
{
    public interface ICondition<T>
    {
        public IOperation<T> Operation { get; set; }

        public Func<Fact, T> GetLeftOperand { get; set; }

        public Func<Fact, T> GetRightOperand { get; set; }

        public bool IsPositive(Fact fact);
    }
}
