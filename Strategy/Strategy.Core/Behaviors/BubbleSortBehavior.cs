namespace Strategy.Core.Behaviors
{
    // O(n³)
    public class BubbleSortBehavior : IStrategyBehavior
    {
        public void ExecuteOperation(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                        Swap(array, i, j);
                }
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}