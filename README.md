# FastRules

.Net Rule Engine with a focus on high load and performance.

## How to use

var network = new Network();
var session = new Session();
var fact = new Fact();

var ruleAction = network.Run(session, fact);


