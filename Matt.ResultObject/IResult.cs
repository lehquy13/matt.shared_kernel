namespace Matt.ResultObject;

internal interface IResult
{
    bool IsSuccess { get; }

    bool IsFailed { get; }

    string DisplayMessage { get; }
}