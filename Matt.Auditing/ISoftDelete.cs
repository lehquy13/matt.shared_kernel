namespace Matt.Auditing;

public interface ISoftDelete
{
    // Summary:
    //     Used to mark an Entity as 'Deleted'.
    bool IsDeleted { get; }
}