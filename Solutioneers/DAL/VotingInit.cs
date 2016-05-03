using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solutioneers.Models;

namespace Solutioneers.DAL
{
    public class VotingInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<VotingContext>
    {
        protected override void Seed(VotingContext context)
        {
            var groups = new List<GroupModel>
            {
                new GroupModel { Title= "Sports", Description ="Some important shit here" },
                new GroupModel { Title= "Gaming", Description ="Other important shit here" }
            };
            groups.ForEach(s => context.Groups.Add(s));
            context.SaveChanges(); 
        }
    }
}