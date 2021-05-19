using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Stories.Data
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //optionsBuilder.UseSqlServer("Data Source=localhost;Database=Stories;User Id=sa;Password=reallyStrongPwd123;");
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Database=Stories;Trusted_Connection=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}