using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {

        // dependency injection taking care of the instances we just use the db context
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)// here press (ctrl + .) on ApplicationDbContext to implement the above line
        {
            this.dbContext = dbContext;
        }
        // --------------------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            {
                var student = new Student { name = viewModel.name, email = viewModel.email, Subscribed = viewModel.Subscribed };

                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("List","Students");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           // return NotFound();
            return View(await dbContext.Students.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await dbContext.Students.FindAsync(id));
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = (await dbContext.Students.FindAsync(viewModel.ID));
            if (student is not null)
            {
                student.name = viewModel.name;
                student.email = viewModel.email;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = (await dbContext.Students.FindAsync(id));
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();

            } 
            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = (await dbContext.Students.FindAsync(viewModel.ID));
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List", "Students");
        }  
    }
}

