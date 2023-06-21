using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork
{
    public interface IReteNode
    {
        public IEnumerable<IReteNode>? Outputs { get; set; }
    }
}
