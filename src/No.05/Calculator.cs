// (c) 2022 Ervin Peters (coder@ervnet.de)

namespace No._05
{
    public static class Calculator
    {
        public static string calc(string stackDefs, string actionDefs)
            => new ChargeStacks(stackDefs).applyActions(actionDefs, 0).cratesOnTop();

        public static string calc2(string stackDefs, string actionDefs)
            => new ChargeStacks(stackDefs).applyActions(actionDefs, 1).cratesOnTop();
    }
}