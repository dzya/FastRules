using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public abstract class BaseStringOperation : BaseOperation
    {
        public string LeftOperand { get; set; }

        public string RightOperand { get; set; }

        protected Predicate<(string, string)> Predicate { get; set; }

        public override bool Result => Predicate((LeftOperand, RightOperand));
    }
}
