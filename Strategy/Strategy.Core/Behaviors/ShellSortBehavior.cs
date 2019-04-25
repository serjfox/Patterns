namespace Strategy.Core.Behaviors
{
    public class ShellSortBehavior : IStrategyBehavior
    {
        // Худшее время O(n²)
        // Лучшее время O(n log² n)
        public void ExecuteOperation(int[] vector)
        {
            var step = vector.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < vector.Length; i++)
                {
                    var value = vector[i];

                    for (j = i - step; (j >= 0) && (vector[j] > value); j -= step)
                        vector[j + step] = vector[j];

                    vector[j + step] = value;
                }
                step /= 2;
            }
        }
    }
}