using FastRules.Engine.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Rules
{
    public interface IRule
    {
        public ICondition Condition { get; }
    }
}
