namespace Matt.SharedKernel.Paginations;

public interface IPaginated
{
    public int PageIndex { get; }
    public int PageSize { get; }
}