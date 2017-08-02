using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreTest.Services.Interfaces;

namespace CoreTest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public CoursesController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/Courses
        [HttpGet]
        public IEnumerable<Course> GetCourses()
        {
            return _unitOfWorkService.GetAllCourses();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return _unitOfWorkService.FindCourse(id);
        }

        // POST: api/Courses
        [HttpPost]
        public void Post([FromBody]Course course)
        {
            _unitOfWorkService.AddCourse(course);
        }

        // PUT: api/Courses/5
        [HttpPut]
        public void Put([FromBody]Course course)
        {
            _unitOfWorkService.UpdateCourse(course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWorkService.RemoveCourse(id);
        }
    }
}
