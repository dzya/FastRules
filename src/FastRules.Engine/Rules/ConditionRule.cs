using FastRules.Engine.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Rules
{
    public class ConditionRule : BaseRule
    {
        public ConditionRule(ICondition condition) : base(condition)
        {
        }
    }
}
