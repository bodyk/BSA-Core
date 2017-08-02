using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreTest.Services.Interfaces;
using CoreTest.Services.Implementations;
using Microsoft.Extensions.Logging;
using CoreTest.Logging;

namespace CoreTest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly LoggerService _loggerService;

        public CoursesController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
            _loggerService = new LoggerService(new CustomConsoleLogger("", new CustomConsoleLoggerConfiguration()));
        }

        // GET: api/Courses
        [HttpGet]
        public IEnumerable<Course> GetCourses()
        {
            _loggerService.LogInformation(LoggingEvents.GET_LIST_ITEMS, "GetAllCourses");
            return _unitOfWorkService.GetAllCourses();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public Course Get(int id)
        {
            _loggerService.LogInformation(LoggingEvents.GET_ITEM, $"FindCourse with id: {id}");
            return _unitOfWorkService.FindCourse(id);
        }

        // POST: api/Courses
        [HttpPost]
        public void Post([FromBody]Course course)
        {
            _loggerService.LogInformation(LoggingEvents.POST_ITEM, $"AddCourse: {course.Title}");
            _unitOfWorkService.AddCourse(course);
        }

        // PUT: api/Courses/5
        [HttpPut]
        public void Put([FromBody]Course course)
        {
            _loggerService.LogInformation(LoggingEvents.PUT_ITEM, $"UpdateCourse: {course.Title}");
            _unitOfWorkService.UpdateCourse(course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _loggerService.LogInformation(LoggingEvents.DELETE_ITEM, $"RemoveCourse with id: {id}");
            _unitOfWorkService.RemoveCourse(id);
        }
    }
}
