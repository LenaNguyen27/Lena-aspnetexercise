using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExerciseWebApp.Models
{
    public class CompanyViewModel
    {
        [Key]
        public int ID { get; set; }
        public bool is_Active { get; set; }
        public string company_name { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> number_of_employees { get; set; }
    }
}