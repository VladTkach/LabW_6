using Microsoft.EntityFrameworkCore;

namespace LW_6.Models;

public class DemoContext : DbContext
{
    public DbSet<BarModel> Bars { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite(@"Data Source=Server=tcp:lab-work-6-server.database.windows.net,1433;Initial Catalog=lab-work-6-database;Persist Security Info=False;User ID=lab-work-6-server-admin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
}
