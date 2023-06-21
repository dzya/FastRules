using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork.Builders
{
    public abstract class BaseNetworkBuilder : INetworkBuilder
    {
        public abstract INetwork Build(IEnumerable<IRule<object>> rules);
    }
}
