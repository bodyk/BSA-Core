using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Data;
using CoreTest.Models;
using CoreTest.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CoreTest.Services.Implementations
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly UnitOfWork _unitOfWork;

        public UnitOfWorkService(IConfigurationRoot configuration)
        {
            _unitOfWork = new UnitOfWork(configuration);
        }
        
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        #region AddOperations

        public void AddStudent(Student item)
        {
            _unitOfWork.Students.Create(item);
            _unitOfWork.Save();
        }

        public void AddCourse(Course item)
        {
            _unitOfWork.Courses.Create(item);
            _unitOfWork.Save();
        }

        public void AddEnrollment(Enrollment item)
        {
            _unitOfWork.Enrollments.Create(item);
            _unitOfWork.Save();
        }

        #endregion

        #region GetAllOperations

        public IEnumerable<Student> GetAllStudents()
        {
            return _unitOfWork.Students.GetAll();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _unitOfWork.Courses.GetAll();
        }

        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return _unitOfWork.Enrollments.GetAll();
        }

        #endregion

        #region FindOperations

        public Student FindStudent(int id)
        {
            return _unitOfWork.Students.Get(id);
        }

        public Course FindCourse(int id)
        {
            return _unitOfWork.Courses.Get(id);
        }

        public Enrollment FindEnrollment(int id)
        {
            return _unitOfWork.Enrollments.Get(id);
        }

        #endregion

        #region RemoveOperations

        public void RemoveStudent(int id)
        {
            _unitOfWork.Students.Delete(id);
            _unitOfWork.Save();
        }

        public void RemoveCourse(int id)
        {
            _unitOfWork.Courses.Delete(id);
            _unitOfWork.Save();
        }

        public void RemoveEnrollment(int id)
        {
            _unitOfWork.Enrollments.Delete(id);
            _unitOfWork.Save();
        }

        #endregion

        #region UpdateOperations

        public void UpdateStudent(Student item)
        {
            _unitOfWork.Students.Update(item);
            _unitOfWork.Save();
        }

        public void UpdateCourse(Course item)
        {
            _unitOfWork.Courses.Update(item);
            _unitOfWork.Save();
        }

        public void UpdateEnrollment(Enrollment item)
        {
            _unitOfWork.Enrollments.Update(item);
            _unitOfWork.Save();
        }

        #endregion

        #region ClearOperations

        public void ClearStudents()
        {
            _unitOfWork.Students.Clear();
            _unitOfWork.Save();
        }

        public void ClearCourses()
        {
            _unitOfWork.Courses.Clear();
            _unitOfWork.Save();
        }

        public void ClearEnrollment()
        {
            _unitOfWork.Enrollments.Clear();
            _unitOfWork.Save();
        }

        #endregion
    }
}
