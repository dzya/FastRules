using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Conditions
{
    public class StringOperationCondition : BaseCondition<string>
    {
        public StringOperationCondition() 
        { 
        }

        public override bool IsPositive(Object fact)
        {
            if(Operation == null)
            {
                throw new InvalidOperationException("Operation should be set first.");
            }

            if(GetLeftOperand == null)
            {
                throw new InvalidOperationException("Left operand should be set first.");
            }

            if (GetRightOperand == null)
            {
                throw new InvalidOperationException("Right operand should be set first.");
            }

            var leftOperand = GetLeftOperand(fact);
            var rightOperand = GetRightOperand(fact);
            Operation.LeftOperand = leftOperand;
            Operation.RightOperand = rightOperand;
            return Operation.Result;
        }
    }
}
