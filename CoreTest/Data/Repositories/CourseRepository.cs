using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreTest.Data.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public Course Get(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.CourseId == id);
        }

        public void Create(Course item)
        {
            if (item != null)
            {
                _context.Courses.Add(item);
            }
        }

        public void Update(Course item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.Courses.Remove(_context.Courses.FirstOrDefault(c=>c.CourseId==id));
        }

        public void Clear()
        {
            _context.Courses.RemoveRange(_context.Courses);
        }
    }
}
