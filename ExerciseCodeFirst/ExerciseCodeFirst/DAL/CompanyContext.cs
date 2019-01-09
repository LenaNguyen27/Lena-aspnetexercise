using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExerciseWebApp.Models
{
    public class CompanyContext: DbContext
    {
        public CompanyContext() : base("CompanyContext")
        {
                
        }
        public DbSet<CompanyViewModel> Companies { get; set; }
    }
}