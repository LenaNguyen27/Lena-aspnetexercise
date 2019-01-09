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
        private Database1Entities db = new Database1Entities();
        
        // GET: api/Companies
        public IQueryable<company> Getcompanies()
        {
            return db.companies;
        }

        // GET: api/Companies/5
        [HttpGet]
        public IHttpActionResult Getcompany(int id)
        {
            company company = db.companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
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
        public IHttpActionResult PostCompany([FromBody]company company)
        {
            company.company_id = db.companies.Count() + 1;
            company.is_Active = true;
            company.create_date = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

                db.companies.Add(company);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (companyExists(company.company_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = company.company_id }, company);

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

        private bool companyExists(int id)
        {
            return db.companies.Count(e => e.company_id == id) > 0;
        }
    }
}