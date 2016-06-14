﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solutioneers.Models;

namespace Solutioneers.DAL
{
    public class VotingInit : System.Data.Entity.DropCreateDatabaseAlways<VotingContext>
    {
        protected override void Seed(VotingContext context)
        {
            var groups = new List<Category>
            {
                  new Category { CategoryID = 0, Title= "Solutioneers Features", Description ="Craving a new feature on the site? Submit it here and we will do our best to make sure all the top voted ideas get integrated into our systems!" },
                  new Category { CategoryID = 1,  Title= "Business", Description ="Some important shit here" },
                  new Category { CategoryID = 2, Title= "Comics", Description ="Some important shit here" },
                  new Category { CategoryID = 3, Title= "Communication", Description ="Some important shit here" },
                  new Category { CategoryID = 4, Title= "Education", Description ="Some important shit here" },
                  new Category { CategoryID = 5, Title= "Entertainment", Description ="Some important shit here" },
                  new Category { CategoryID = 6, Title= "Finance", Description ="Some important shit here" },
                  new Category { CategoryID = 7, Title= "Health & Fitness", Description ="Some important shit here" },
                  new Category { CategoryID = 8, Title= "Lifestyle", Description ="Some important shit here" },
                  new Category { CategoryID = 9, Title= "Media & Video", Description ="Some important shit here" },
                  new Category { CategoryID = 10, Title= "Medical", Description ="Some important shit here" },
                  new Category { CategoryID = 11, Title= "Music & Audio", Description ="Some important shit here" },
                  new Category { CategoryID = 12, Title= "News & Magazines", Description ="Some important shit here" },
                  new Category { CategoryID = 13, Title= "Photography", Description ="Some important shit here" },
                  new Category { CategoryID = 14, Title= "Productivity", Description ="Some important shit here" },
                  new Category { CategoryID = 15, Title= "Shopping", Description ="Some important shit here" },
                  new Category { CategoryID = 16, Title= "Social", Description ="Some important shit here" },
                  new Category { CategoryID = 17, Title= "Sports", Description ="Some important shit here" },
                  new Category { CategoryID = 18, Title= "Tools", Description ="Some important shit here" },
                  new Category { CategoryID = 19, Title= "Transportation", Description ="Some important shit here" },
                  new Category { CategoryID = 20, Title= "Travel & Local", Description ="Some important shit here" },
                  new Category { CategoryID = 21, Title= "Weather", Description ="Some important shit here" }
            };
            groups.ForEach(s => context.Categories.Add(s));

            for (int i = 0, j =0; i < 10; i++)
            {
                Company populate = new Company();
                populate.CompanyID = i;
                populate.CreationDate = DateTime.Now;
                populate.Description = "This is some dummy description number: " + i;
                populate.CompanyName = "Company No: " + i;
                populate.UserID = "Admin Dummy Data";

                Location tempLocation = new Location();
                tempLocation.LocationID = i;
                tempLocation.Phone = "1111111111";
                tempLocation.StreetAddress1 = "1234 Someplace NW ST";
                tempLocation.State = Enums.State.WA;
                tempLocation.ZipCode = "98402";
                tempLocation.City = "Seattle";
                tempLocation.CompanyID = populate.CompanyID;
                tempLocation.Company = populate;
                tempLocation.HoursOfOperation = new List<HoursOfOperation>();

                BusinessCategory tempBizCat = new BusinessCategory();
                tempBizCat.BusinessCategoryID = i;
                tempBizCat.Company = populate;
                tempBizCat.Description = "This is a dummy description for a biz cat" + i;
                tempBizCat.CompanyID = populate.CompanyID;
                tempBizCat.Title = "BusinessCategory Temp Holder" + i;


                populate.Locations = new List<Location> { tempLocation};
                populate.BusinessCategories = new List<BusinessCategory> {tempBizCat };

                /*
                HoursOfOperation tempHours = new HoursOfOperation();
                tempHours.HoursOfOperationID = i;
                tempHours.DayOfWeek = DayOfWeek.Friday;
                tempHours.LocationID = tempLocation.LocationID;
                tempHours.Location = tempLocation;
                tempHours.TimeOpen = "9 AM - 5 PM";

                tempLocation.HoursOfOperation.Concat(new List<HoursOfOperation> { tempHours });
                populate.Locations.Concat(new List<Location>{ tempLocation });

               
                context.HoursOfOperations.Add(tempHours);*/

                context.BusinessCategories.Add(tempBizCat);
                context.Locations.Add(tempLocation);
                context.Companies.Add(populate);
            }
            context.SaveChanges(); 
        }
    }
}