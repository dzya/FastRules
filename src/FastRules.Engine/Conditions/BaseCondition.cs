using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Conditions
{
    public abstract class BaseCondition : ICondition
    {
        public bool IsPositive(Fact fact)
        {
            throw new NotImplementedException();
        }
    }
}
