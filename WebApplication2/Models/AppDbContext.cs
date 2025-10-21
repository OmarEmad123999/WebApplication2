using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Player> Players { get; set; }
        public DbSet<Coach>  Coaches { get; set; }
        public DbSet<Competetion> competetions { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasMany(x=> x.competetions).WithMany(x=>x.teams);
            modelBuilder.Entity<Team>().HasMany(x=> x.Players).WithOne(x=> x.Team).HasForeignKey(x=> x.TeamId);
            modelBuilder.Entity<Coach>().HasOne(x=> x.Team).WithOne(x=> x.Coach).HasForeignKey<Team>(x=> x.CoachId);

            modelBuilder.Entity<Coach>().HasData(
                new Coach { Id=1, Name="Essam Ahmed", Specialization="Football", ExperienceYears=5},
                new Coach { Id=2,Name="Ahmed Elsayed", Specialization="VollyBall", ExperienceYears=3},
                new Coach { Id=3, Name="Kareem Magdy", Specialization="BasketBall", ExperienceYears=8}
                );

            modelBuilder.Entity<Team>().HasData(
                new Team { Id=1,Name="Al-Ahly",City="Cairo", CoachId=1},
                new Team { Id=2,Name="Madrid", City="Giza", CoachId=2}
                );
            modelBuilder.Entity<Player>().HasData(
                new Player { Id=1, FullName="Mohammed Salah", Position="Striker", Age=35, TeamId=1},
                new Player { Id=2, FullName="Mohammed Ahmed", Position="GoalKeeper", Age=25, TeamId=2}
                );
            modelBuilder.Entity<Competetion>().HasData(
                 new Competetion { Id=1, Title="Fifa WorldCup", Location="France", Date = DateTime.UtcNow},
                 new Competetion { Id=2 , Title="Africa Cup", Location="Egypt", Date= DateTime.UtcNow}
                );
        }
    }
}


















