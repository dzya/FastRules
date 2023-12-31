﻿using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork.Builders
{
    public interface INetworkBuilder
    {
        public INetwork Build(IEnumerable<IRule<object>> rules);
    }
}
