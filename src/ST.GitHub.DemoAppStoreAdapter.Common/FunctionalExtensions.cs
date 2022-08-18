namespace ST.GitHub.DemoAppStoreAdapter.Common
{
    public static class FunctionalExtensions
    {
        public static T Map<TIn, T>(this TIn input, Func<TIn, T> mapper)
        {
            return mapper(input);
        }

        public static async Task<T> MapAsync<TIn, T>(this Task<TIn> inputTask, Func<TIn, T> mapper)
        {
            var input = await inputTask;
            return mapper(input);
        }

        public static async Task<T> MapAsync<TIn, T>(this Task<TIn> inputTask, Func<TIn, Task<T>> asyncMapper)
        {
            var input = await inputTask;
            return await asyncMapper(input);
        }
    }
}