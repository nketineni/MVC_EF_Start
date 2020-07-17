using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
  public class DatabaseExampleController : Controller
  {
    public ApplicationDbContext dbContext;

    public DatabaseExampleController(ApplicationDbContext context)
    {
      dbContext = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<ViewResult> DatabaseOperations()
    {
      // CREATE operation
      Company MyCompany = new Company();
      MyCompany.symbol = "MCOB";
      MyCompany.name = "ISM";
      MyCompany.date = "ISM";
      MyCompany.isEnabled = true;
      MyCompany.type = "ISM";
      MyCompany.iexId = "ISM";

      Quote MyCompanyQuote1 = new Quote();
      //MyCompanyQuote1.EquityId = 123;
      MyCompanyQuote1.date = "11-23-2018";
      MyCompanyQuote1.open = 46.13F;
      MyCompanyQuote1.high = 47.18F;
      MyCompanyQuote1.low = 44.67F;
      MyCompanyQuote1.close = 47.01F;
      MyCompanyQuote1.volume = 37654000;
      MyCompanyQuote1.unadjustedVolume = 37654000;
      MyCompanyQuote1.change = 1.43F;
      MyCompanyQuote1.changePercent = 0.03F;
      MyCompanyQuote1.vwap = 9.76F;
      MyCompanyQuote1.label = "Nov 23";
      MyCompanyQuote1.changeOverTime = 0.56F;
      MyCompanyQuote1.symbol = "MCOB";

      Quote MyCompanyQuote2 = new Quote();
      //MyCompanyQuote1.EquityId = 123;
      MyCompanyQuote2.date = "11-23-2018";
      MyCompanyQuote2.open = 46.13F;
      MyCompanyQuote2.high = 47.18F;
      MyCompanyQuote2.low = 44.67F;
      MyCompanyQuote2.close = 47.01F;
      MyCompanyQuote2.volume = 37654000;
      MyCompanyQuote2.unadjustedVolume = 37654000;
      MyCompanyQuote2.change = 1.43F;
      MyCompanyQuote2.changePercent = 0.03F;
      MyCompanyQuote2.vwap = 9.76F;
      MyCompanyQuote2.label = "Nov 23";
      MyCompanyQuote2.changeOverTime = 0.56F;
      MyCompanyQuote2.symbol = "MCOB";

      dbContext.Companies.Add(MyCompany);
      dbContext.Quotes.Add(MyCompanyQuote1);
      dbContext.Quotes.Add(MyCompanyQuote2);

            Student student1 = new Student();
            student1.Name = "Neelima";

            Student student2 = new Student();
            student2.Name = "Rameez";

            Student student3 = new Student();
            student3.Name = "Eric";


            Course course1 = new Course();
            course1.Name = "Distributed systems";

            Course course2 = new Course();
            course2.Name = "Leadership";

            Course course3 = new Course();
            course3.Name = "Data Mining";

            Enrollment enrollment1 = new Enrollment();
            enrollment1.course = course1;
            enrollment1.student = student1;
            enrollment1.grade = "A";

            Enrollment enrollment2 = new Enrollment();
            enrollment2.course = course1;
            enrollment2.student = student2;
            enrollment2.grade = "A";

            Enrollment enrollment3 = new Enrollment();
            enrollment3.course = course1;
            enrollment3.student = student3;
            enrollment3.grade = "A";

            Enrollment enrollment4 = new Enrollment();
            enrollment4.course = course2;
            enrollment4.student = student1;
            enrollment4.grade = "A";

            Enrollment enrollment5 = new Enrollment();
            enrollment5.course = course2;
            enrollment5.student = student2;
            enrollment5.grade = "A";

            Enrollment enrollment6 = new Enrollment();
            enrollment6.course = course3;
            enrollment6.student = student1;
            enrollment6.grade = "A";

            dbContext.Students.Add(student1);
            dbContext.Students.Add(student2);
            dbContext.Students.Add(student3);
            dbContext.Courses.Add(course1);
            dbContext.Courses.Add(course2);
            dbContext.Courses.Add(course3);
            dbContext.Enrollments.Add(enrollment1);
            dbContext.Enrollments.Add(enrollment2);
            dbContext.Enrollments.Add(enrollment3);
            dbContext.Enrollments.Add(enrollment4);
            dbContext.Enrollments.Add(enrollment5);
            dbContext.Enrollments.Add(enrollment6);

            dbContext.SaveChanges();
      
      // READ operation
      Company CompanyRead1 = dbContext.Companies
                              .Where(c => c.symbol == "MCOB")
                              .First();

      Company CompanyRead2 = dbContext.Companies
                              .Include(c => c.Quotes)
                              .Where(c => c.symbol == "MCOB")
                              .First();

      // UPDATE operation
      CompanyRead1.iexId = "MCOB";
      dbContext.Companies.Update(CompanyRead1);
      //dbContext.SaveChanges();
      await dbContext.SaveChangesAsync();
      
      // DELETE operation
      //dbContext.Companies.Remove(CompanyRead1);
      //await dbContext.SaveChangesAsync();

      return View();
    }

    public ViewResult LINQOperations()
    {
      Company CompanyRead1 = dbContext.Companies
                                      .Where(c => c.symbol == "MCOB")
                                      .First();

      Company CompanyRead2 = dbContext.Companies
                                      .Include(c => c.Quotes)
                                      .Where(c => c.symbol == "MCOB")
                                      .First();

      Quote Quote1 = dbContext.Companies
                              .Include(c => c.Quotes)
                              .Where(c => c.symbol == "MCOB")
                              .FirstOrDefault()
                              .Quotes
                              .FirstOrDefault();

      return View();
    }

  }
}