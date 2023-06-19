using FastRules.Engine.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Rules
{
    public abstract class BaseRule<T> : IRule<T>
    {
        private readonly ICondition<T> _condition;

        public BaseRule(ICondition<T> condition) 
        {
            _condition = condition;
        }

        public ICondition<T> Condition => throw new NotImplementedException();
    }
}
