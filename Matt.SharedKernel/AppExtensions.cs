using Matt.ResultObject;

namespace Matt.SharedKernel;

public static class AppExtensions
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> consumer)
    {
        foreach (var obj in enumerable)
            consumer(obj);
    }
}

public static class DomainValidation
{
    public static Result Sequentially(params Func<Result>[] operations)
    {
        foreach (var operation in operations)
        {
            var result = operation();
            if (result.IsFailed) return result;
        }

        return Result.Success();
    }
}