using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreTest.Data.Repositories
{
    public class EnrollmentRepository : IRepository<Enrollment>
    {
        private readonly SchoolContext _context;

        public EnrollmentRepository(SchoolContext context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments;
        }

        public Enrollment Get(int id)
        {
            return _context.Enrollments.FirstOrDefault(c => c.EnrollmentId == id);
        }

        public void Create(Enrollment item)
        {
            if (item != null)
            {
                _context.Enrollments.Add(item);
            }
        }

        public void Update(Enrollment item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            _context.Enrollments.Remove(_context.Enrollments.FirstOrDefault(en=>en.EnrollmentId==id));
        }

        public void Clear()
        {
            _context.Enrollments.RemoveRange(_context.Enrollments);
        }
    }
}
