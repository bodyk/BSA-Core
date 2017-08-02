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
    public class EnrollmentsController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public EnrollmentsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/Enrollments
        [HttpGet]
        public IEnumerable<Enrollment> GetEnrollments()
        {
            return _unitOfWorkService.GetAllEnrollments();
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public Enrollment Get(int id)
        {
            return _unitOfWorkService.FindEnrollment(id);
        }

        // POST: api/Enrollments
        [HttpPost]
        public void Post([FromBody]Enrollment enrollment)
        {
            _unitOfWorkService.AddEnrollment(enrollment);
        }

        // PUT: api/Enrollments/5
        [HttpPut]
        public void Put([FromBody]Enrollment enrollment)
        {
            _unitOfWorkService.UpdateEnrollment(enrollment);
        }

        // DELETE: api/Enrollments/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWorkService.RemoveEnrollment(id);
        }
    }
}
