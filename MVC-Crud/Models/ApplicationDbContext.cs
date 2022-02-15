namespace MVC_Crud.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Games> tbl_Games { get; set; }


        public DbSet<GamerProfile> tbl_GamerProfile { get; set; }


        public DbSet<Ranking> tbl_Ranking { get; set; }
        


    }
}
