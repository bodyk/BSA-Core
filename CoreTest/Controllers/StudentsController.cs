using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Data;
using CoreTest.Models;
using CoreTest.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreTest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public StudentsController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _unitOfWorkService.GetAllStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "Get")]
        public Student Get(int id)
        {
            return _unitOfWorkService.FindStudent(id);
        }

        // POST: api/Students
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _unitOfWorkService.AddStudent(student);
        }

        // PUT: api/Students/5
        [HttpPut]
        public void Put([FromBody]Student student)
        {
            _unitOfWorkService.UpdateStudent(student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWorkService.RemoveStudent(id);
        }
    }
}
