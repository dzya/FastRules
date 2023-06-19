using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Operations
{
    public class IntLessThanOperation : BaseIntOperation
    {
        public IntLessThanOperation() 
        {
            Predicate = new Predicate<(int, int)>(
                (x) => x.Item1 < x.Item2);
        }

        public override OperationIds Id => OperationIds.IntLessThan;
    }
}
