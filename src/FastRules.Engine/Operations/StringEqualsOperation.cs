using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public class StringEqualsOperation : BaseStringOperation
    {
        public StringEqualsOperation() 
        {
            Predicate = new Predicate<(string, string)> (
                (x) => 
                    (x.Item1 != null && x.Item2 != null) 
                    ? x.Item1.Equals(x.Item2) 
                    : x.Item1 == x.Item2); 
        }

        public override OperationIds Id => OperationIds.StringEquals;
    }
}
