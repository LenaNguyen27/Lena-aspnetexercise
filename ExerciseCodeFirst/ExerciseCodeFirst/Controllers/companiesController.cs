using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ExerciseWebApp.Models;

namespace ExerciseWebApp.Controllers
{
    public class CompaniesController : ApiController
    {
        //private Database1 db = new Database1();
        

        // GET: api/Companies
        [HttpGet]
        public IQueryable<CompanyViewModel> Getcompanies()
        {
            CompanyContext db = new CompanyContext();
            return db.Companies;
        }

        // GET: api/Companies/5
        [HttpGet]
        public IHttpActionResult Getcompany(int id)
        {
            CompanyContext db = new CompanyContext();

            try
            {
                var result = from CompanyViewModel in db.Companies
                             select new
                             {
                                 CompanyViewModel.ID,
                                 CompanyViewModel.is_Active,
                                 CompanyViewModel.company_name,
                                 CompanyViewModel.create_date,
                                 CompanyViewModel.number_of_employees

                             };

                return Ok(result);
            }

            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //// PUT: api/Companies/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putcompany(int id, company company)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != company.company_id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(company).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!companyExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //                throw;
        //            }
        //        }

        //        return StatusCode(HttpStatusCode.NoContent);
        //}
        

        // POST: api/Companies
        [HttpPost]
        public IHttpActionResult PostCompany([FromBody]CompanyViewModel company)
        {
            CompanyContext db = new CompanyContext();
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            //using (var ctx = new CompanyViewModel())
            //{
            //    ctx.company.Add(company);
            //    return Ok();
            //}

            db.Companies.Add(company);
            return Ok();
        }
    

    //        // DELETE: api/Companies/5
    //        [ResponseType(typeof(company))]
    //public IHttpActionResult Deletecompany(int id)
    //{
    //    company company = db.companies.Find(id);
    //    if (company == null)
    //    {
    //        return NotFound();
    //    }

    //    db.companies.Remove(company);
    //    db.SaveChanges();

    //    return Ok(company);
    //}

    //protected override void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        db.Dispose();
    //    }
    //    base.Dispose(disposing);
    //}

    //private bool companyExists(int id)
    //{
    //    return db.companies.Count(e => e.company_id == id) > 0;
    //}
    }
}