public class AppDbContext : DbContext
{
    public DbSet<TreeNode> TreeNodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0");
    }//src: https://learn.microsoft.com/en-us/ef/core/
}