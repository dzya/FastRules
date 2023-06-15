using System;
using System.Collections.Generic;
using System.Text;

namespace FastRules.Engine.ReteNetwork.Builders
{
    public class SessionBuilder : ISessionBuilder
    {
        public ISession Build()
        {
            return new Session();
        }
    }
}
