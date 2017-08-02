using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
