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
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<ProblemModel> Problems { get; set; }
        public DbSet<SolutionModel> Solutions { get; set; }
        public DbSet<ProblemVoteModel> ProblemVotes { get; set; }
        public DbSet<SolutionVoteModel> SolutionVotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
        }
    }
}