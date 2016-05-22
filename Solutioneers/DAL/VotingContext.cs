using Solutioneers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Solutioneers.DAL
{
    public class VotingContext : DbContext
    {
        public VotingContext() : base("VotingContext") //This is the connection string
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<ChannelVote> ChannelVotes { get; set; }
        public DbSet<ProblemVote> ProblemVotes { get; set; }
        public DbSet<SolutionVote> SolutionVotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Link that explains the blow code http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*
            //Maps a many to many relationship
            modelBuilder.Entity<Category>()
            .HasMany(c => c.Channels).WithMany(i => i.Categories)
            .Map(t => t.MapLeftKey("CourseID")
                .MapRightKey("InstructorID")
                .ToTable("CourseInstructor"));

           The below code is there to show the second way to establish relationships besides the hard coded models
           *  modelBuilder.Entity<Problem>()
                    .HasRequired(s => s.Channel) // Problem entity requires Channel 
                    .WithMany(s => s.Problems); // Channel entity includes many Problem entities

            modelBuilder.Entity<Solution>()
                  .HasRequired(s => s.Channel) // Solution entity requires Channel 
                  .WithMany(s => s.Solutions); // Channel entity includes many Solution entities

            modelBuilder.Entity <ChannelVote>()
            .HasRequired(s => s.Channel) //Vote entity requires a channel
            .WithMany(s => s.Votes); //Channel entity has many votes

            modelBuilder.Entity<ProblemVote>()
              .HasRequired(s => s.Problem) //Vote entity requires a problem
              .WithMany(s => s.Votes); //Problem entity has many votes

            modelBuilder.Entity<SolutionVote>()
            .HasRequired(s => s.Solution) //Vote entity requires a problem
            .WithMany(s => s.Votes); //Problem entity has many votes
            */
        }
    }
}