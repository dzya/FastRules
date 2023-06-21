using FastRules.Engine.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Rules
{
    public class ConditionRule<T> : BaseRule<T>
    {
        public ConditionRule(ICondition<T> condition, RuleAction ruleAction) : base(condition, ruleAction)
        {
        }
    }
}
