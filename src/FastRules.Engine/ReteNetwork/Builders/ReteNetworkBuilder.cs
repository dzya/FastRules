using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork.Builders
{
    public class ReteNetworkBuilder : BaseNetworkBuilder
    {
        public override INetwork Build()
        {
            return new Network();
        }
    }
}
