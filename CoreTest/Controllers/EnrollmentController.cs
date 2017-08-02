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
    public class EnrollmentsController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        private readonly LoggerService _loggerService;

        public EnrollmentsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
            _loggerService = new LoggerService(new CustomConsoleLogger("", new CustomConsoleLoggerConfiguration()));
        }

        // GET: api/Enrollments
        [HttpGet]
        public IEnumerable<Enrollment> GetEnrollments()
        {
            _loggerService.LogInformation(LoggingEvents.GET_LIST_ITEMS, "GetAllEnrollments");
            return _unitOfWorkService.GetAllEnrollments();
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public Enrollment Get(int id)
        {
            _loggerService.LogInformation(LoggingEvents.GET_ITEM, "FindEnrollment");
            return _unitOfWorkService.FindEnrollment(id);
        }

        // POST: api/Enrollments
        [HttpPost]
        public void Post([FromBody]Enrollment enrollment)
        {
            _loggerService.LogInformation(LoggingEvents.POST_ITEM, $"AddEnrollment: Student - {enrollment.Student}; Grade - {enrollment.Grade}; Course - {enrollment.Course}");
            _unitOfWorkService.AddEnrollment(enrollment);
        }

        // PUT: api/Enrollments/5
        [HttpPut]
        public void Put([FromBody]Enrollment enrollment)
        {
            _loggerService.LogInformation(LoggingEvents.PUT_ITEM, $"UpdateEnrollment: Student - {enrollment.Student}; Grade - {enrollment.Grade}; Course - {enrollment.Course}");
            _unitOfWorkService.UpdateEnrollment(enrollment);
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _loggerService.LogInformation(LoggingEvents.DELETE_ITEM, $"RemoveEnrollment with id: {id}");
            _unitOfWorkService.RemoveEnrollment(id);
        }
    }
}
