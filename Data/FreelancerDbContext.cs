using Microsoft.EntityFrameworkCore;

public class FreelancerDbContext : DbContext
{
    public FreelancerDbContext(DbContextOptions<FreelancerDbContext> options) : base(options) { }

    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Skillset> Skillsets { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
}