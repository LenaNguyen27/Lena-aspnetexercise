using ExerciseWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseWebApp.DAL
{
    public class CompanyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            base.Seed(context);
            var companies = new List<CompanyViewModel>
           {
                new CompanyViewModel{ is_Active = true,company_name = "McDonalds", create_date = DateTime.Now, number_of_employees = 20 },
                new CompanyViewModel{ is_Active = false,company_name = "Aldo", create_date = DateTime.Now, number_of_employees = 20 },
                new CompanyViewModel{ is_Active = false, company_name = "Nike", create_date = DateTime.Now, number_of_employees = 200 },
                new CompanyViewModel{ is_Active = false,company_name = "Arctic", create_date = DateTime.Now, number_of_employees = 20 },
                new CompanyViewModel{ is_Active = true,company_name = "Google", create_date = DateTime.Now, number_of_employees = 20 },

           };

            context.Companies.AddRange(companies);
            context.SaveChanges();
        }
        
    }
}