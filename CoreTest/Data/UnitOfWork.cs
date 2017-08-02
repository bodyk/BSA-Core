using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreTest.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly SchoolContext _context;

        public UnitOfWork(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            _context = new SchoolContext(optionsBuilder.Options);
        }

        private CourseRepository _courseRepository;
        private EnrollmentRepository _enrollmentRepository;
        private StudentRepository _studentRepository;

        public CourseRepository Courses =>
            _courseRepository ?? (_courseRepository = new CourseRepository(_context));

        public EnrollmentRepository Enrollments =>
            _enrollmentRepository ?? (_enrollmentRepository = new EnrollmentRepository(_context));

        public StudentRepository Students =>
            _studentRepository ?? (_studentRepository = new StudentRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if (disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
