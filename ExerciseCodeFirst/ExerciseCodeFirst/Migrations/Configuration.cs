namespace ExerciseCodeFirst.Migrations
{
    using ExerciseWebApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ExerciseWebApp.Models.CompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExerciseWebApp.Models.CompanyContext context)
        {
            var companies = new List<CompanyViewModel>
           {
                new CompanyViewModel{ is_Active = true,company_name = "McDonalds", create_date = DateTime.Now, number_of_employees = 20 },
                new CompanyViewModel{ is_Active = false,company_name = "Aldo", create_date = DateTime.Now, number_of_employees = 20 },
                new CompanyViewModel{ is_Active = false, company_name = "Nike", create_date = DateTime.Now, number_of_employees = 200 },
                new CompanyViewModel{ is_Active = false,company_name = "Arctic", create_date = DateTime.Now, number_of_employees = 20 },
                new CompanyViewModel{ is_Active = true,company_name = "Google", create_date = DateTime.Now, number_of_employees = 20 },

           };

            companies.ForEach(c => context.Companies.Add(c));
            context.SaveChanges();
        }
    }
}
