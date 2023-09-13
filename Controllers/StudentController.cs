using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThucHanh1.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ThucHanh1.Controllers
{

    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        private IHostingEnvironment env;
        public StudentController(IHostingEnvironment _env)

        {
            env = _env;

            //Tạo danh sách sinh viên với 4 dữ liệu mẫu
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular=true,
                Address = "A1-2018", Email = "nam@g.com" },

                new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                Gender = Gender.Female, IsRegular=true,
                Address = "A1-2019", Email = "tu@g.com" },

                new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                Gender = Gender.Male, IsRegular=false,
                Address = "A1-2020", Email = "phong@g.com" },

                new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                Gender = Gender.Female, IsRegular = false,
                Address = "A1-2021", Email = "mai@g.com" }

            };
        }

        

        [Route("Admin/student/list")]
        [HttpGet("/list")]
        public IActionResult Index()
        {
            return View(listStudents);
        }
        [HttpGet("Admin/student/add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem{Text = "IT" ,Value = "1"},
                new SelectListItem{Text = "BE" ,Value = "2"},
                new SelectListItem{Text = "CE" ,Value = "3"},
                new SelectListItem{Text = "EE" ,Value = "4"}
            };
            return View();
        }
        [HttpPost("Admin/student/add")]
        public async Task<IActionResult> Create(Student student)
        {
            if(student.ImageURL != null)
            {
                var file = Path.Combine(env.ContentRootPath, "wwwroot\\uploads", student.ImageURL.FileName);
                using (FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    await student.ImageURL.CopyToAsync(fileStream);
                }
            }
            student.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(student);
            return View("Index", listStudents);
        }
    }

}
