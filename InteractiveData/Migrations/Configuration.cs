using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

public sealed class Configuration : DbMigrationsConfiguration<AmpContext>
{
    public bool AutomaticMigrationsEnabled { get; }

    private bool pendingMigrationsExist;
    private Seeder seeder;

    public Configuration()
    {
        // This ensures a schema diff. is always performed and automatic updates take place.
        AutomaticMigrationsEnabled = true;

        // This is required to detect changes.
        pendingMigrationsExist = new DbMigrator(this).GetPendingMigrations().Any();
    }

    protected override void Seed(Context context)
    {
        // Only if a diff exists should migrations be performed.
        if (!pendingMigrationsExist)
        {
            return;
        }

        // Initialize Seeding routine and populate the target DB.
        seeder = new Seeder(context);
        seeder.Seed();
    }
}