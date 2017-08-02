using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Data;
using CoreTest.Logging;
using CoreTest.Models;
using CoreTest.Services.Implementations;
using CoreTest.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreTest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly LoggerService _loggerService;

        public StudentsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
            _loggerService = new LoggerService(new CustomConsoleLogger("", new CustomConsoleLoggerConfiguration()));
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            _loggerService.LogInformation(LoggingEvents.GET_LIST_ITEMS, "GetAllStudents");
            return _unitOfWorkService.GetAllStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Student Get(int id)
        {
            _loggerService.LogInformation(LoggingEvents.GET_ITEM, $"FindStudent with id: {id}");
            return _unitOfWorkService.FindStudent(id);
        }

        // POST: api/Students
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _loggerService.LogInformation(LoggingEvents.POST_ITEM, $"AddStudent: {student.FirstName} {student.LastName}");
            _unitOfWorkService.AddStudent(student);
        }

        // PUT: api/Students/5
        [HttpPut]
        public void Put([FromBody]Student student)
        {
            _loggerService.LogInformation(LoggingEvents.PUT_ITEM, $"UpdateStudent: {student.FirstName} {student.LastName}");
            _unitOfWorkService.UpdateStudent(student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _loggerService.LogInformation(LoggingEvents.DELETE_ITEM, $"RemoveStudent with id: {id}");
            _unitOfWorkService.RemoveStudent(id);
        }
    }
}
