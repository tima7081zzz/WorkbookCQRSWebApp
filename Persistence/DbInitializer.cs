namespace Persistence;

public class DbInitializer
{
    public static void Initialize(WorkBookDbContext context)
    {
        context.Database.EnsureCreated();
    }
}