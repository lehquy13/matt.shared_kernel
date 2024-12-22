namespace Matt.SharedKernel.Paginations;

public interface IHasTotalItemsCount
{
    public long TotalItems { get; }
}