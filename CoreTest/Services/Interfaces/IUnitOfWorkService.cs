using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Models;

namespace CoreTest.Services.Interfaces
{
    public interface IUnitOfWorkService : IDisposable
    {
        #region AddOperations

        void AddStudent(Student item);

        void AddCourse(Course item);

        void AddEnrollment(Enrollment item);

        #endregion

        #region GetAllOperations

        IEnumerable<Student> GetAllStudents();

        IEnumerable<Course> GetAllCourses();

        IEnumerable<Enrollment> GetAllEnrollments();

        #endregion

        #region FindOperations

        Student FindStudent(int id);
        
        Course FindCourse(int id);
        
        Enrollment FindEnrollment(int id);

        #endregion

        #region RemoveOperations

        void RemoveStudent(int id);

        void RemoveCourse(int id);

        void RemoveEnrollment(int id);

        #endregion

        #region UpdateOperations

        void UpdateStudent(Student item);

        void UpdateCourse(Course item);

        void UpdateEnrollment(Enrollment item);

        #endregion

        #region ClearOperations

        void ClearStudents();

        void ClearCourses();

        void ClearEnrollment();

        #endregion
    }
}
