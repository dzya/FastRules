using FastRules.Engine.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Rules
{
    public abstract class BaseRule<T> : IRule<T>
    {
        private readonly ICondition<T> _condition;
        private readonly RuleAction _ruleAction;

        public BaseRule(ICondition<T> condition, RuleAction ruleAction) 
        {
            _condition = condition;
            _ruleAction = ruleAction;
        }

        public ICondition<T> Condition => _condition;

        public RuleAction? Fire(object fact)
        {
            if(_condition.IsPositive(fact))
            {
                return _ruleAction;
            }

            return null;
        }
    }
}
