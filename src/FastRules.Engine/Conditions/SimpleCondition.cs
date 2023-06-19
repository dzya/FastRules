using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.Conditions
{
    public class SimpleCondition : BaseCondition
    {
        private readonly string _leftOperand;
        private readonly string _rightOperand;

        public SimpleCondition(string leftOperand, string rightOperand) 
        { 
            _leftOperand = leftOperand;
            _rightOperand = rightOperand;
        }
    }
}
