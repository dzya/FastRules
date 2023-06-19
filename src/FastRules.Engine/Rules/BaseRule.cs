using FastRules.Engine.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Rules
{
    public abstract class BaseRule : IRule
    {
        private readonly ICondition _condition;

        public BaseRule(ICondition condition) 
        {
            _condition = condition;
        }

        public ICondition Condition => throw new NotImplementedException();
    }
}
