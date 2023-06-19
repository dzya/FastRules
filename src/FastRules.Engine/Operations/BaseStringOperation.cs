using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public abstract class BaseStringOperation : BaseOperation<string>
    {
        public override bool Result => Predicate((LeftOperand, RightOperand));
    }
}
