namespace Matt.SharedKernel.Results;

internal interface IResult
{
    bool IsSuccess { get; }

    bool IsFailed { get; }

    string DisplayMessage { get; }
}