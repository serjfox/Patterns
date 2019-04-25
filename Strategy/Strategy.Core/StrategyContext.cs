namespace Strategy.Core
{
    public abstract class StrategyContext
    {
        public static void DoSort(
            int[] array,
            IStrategyBehavior sortBehavior) => sortBehavior.ExecuteOperation(array);
    }
}