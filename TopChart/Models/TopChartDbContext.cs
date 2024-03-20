using Microsoft.EntityFrameworkCore;

namespace TopChart.Models
{
    public class TopChartDbContext: DbContext
    {
        public TopChartDbContext(DbContextOptions<TopChartDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tracks> Tracks { get; set; }

        public DbSet<Singer> Singer { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Video> Video { get; set; }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentVideo> CommentVideo { get; set; }
    }
}
