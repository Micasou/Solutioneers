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
            var groups = new List<Category>
            {
                  new Category { CategoryID = 0, Title= "Solutioneers Features", Description ="Craving a new feature on the site? Submit it here and we will do our best to make sure all the top voted ideas get integrated into our systems!" },
                  new Category {  Title= "Business", Description ="Some important shit here" },
                  new Category { Title= "Comics", Description ="Some important shit here" },
                  new Category { Title= "Communication", Description ="Some important shit here" },
                  new Category { Title= "Education", Description ="Some important shit here" },
                  new Category { Title= "Entertainment", Description ="Some important shit here" },
                  new Category { Title= "Finance", Description ="Some important shit here" },
                  new Category { Title= "Health & Fitness", Description ="Some important shit here" },
                  new Category { Title= "Lifestyle", Description ="Some important shit here" },
                  new Category { Title= "Media & Video", Description ="Some important shit here" },
                  new Category { Title= "Medical", Description ="Some important shit here" },
                  new Category { Title= "Music & Audio", Description ="Some important shit here" },
                  new Category { Title= "News & Magazines", Description ="Some important shit here" },
                  new Category { Title= "Photography", Description ="Some important shit here" },
                  new Category { Title= "Productivity", Description ="Some important shit here" },
                  new Category { Title= "Shopping", Description ="Some important shit here" },
                  new Category { Title= "Social", Description ="Some important shit here" },
                  new Category { Title= "Sports", Description ="Some important shit here" },
                  new Category { Title= "Tools", Description ="Some important shit here" },
                  new Category { Title= "Transportation", Description ="Some important shit here" },
                  new Category { Title= "Travel & Local", Description ="Some important shit here" },
                  new Category { Title= "Weather", Description ="Some important shit here" }
            };
            groups.ForEach(s => context.Categories.Add(s));
            context.SaveChanges(); 
        }
    }
}