using System.Collections.Generic;
using System.Linq;
using CoreTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreTest.Data.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Student item)
        {
            if (item != null)
            {
                _context.Students.Add(item);
            }
        }

        public void Update(Student item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.Students.Remove(_context.Students.FirstOrDefault(s=>s.Id==id));
        }

        public void Clear()
        {
            _context.Students.RemoveRange(_context.Students);
        }
    }
}
