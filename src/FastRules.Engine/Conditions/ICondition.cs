using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Conditions
{
    public interface ICondition
    {
        public bool IsPositive(Fact fact);
    }
}
