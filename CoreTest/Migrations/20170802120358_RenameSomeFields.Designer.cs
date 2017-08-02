using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreTest.Data;

namespace CoreTest.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20170802120358_RenameSomeFields")]
    partial class RenameSomeFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreTest.Models.Course", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("Credits");

                    b.Property<string>("Title");

                    b.HasKey("CourseId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("CoreTest.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseId");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentId");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("CoreTest.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("CoreTest.Models.Enrollment", b =>
                {
                    b.HasOne("CoreTest.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreTest.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
