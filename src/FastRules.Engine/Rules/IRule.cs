using FastRules.Engine.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Rules
{
    public interface IRule<T>
    {
        public ICondition<T> Condition { get; }

        public RuleAction? Fire(object fact);
    }
}
