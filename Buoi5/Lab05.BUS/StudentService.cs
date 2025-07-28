using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Lab05.DAL;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lab05.BUS
{
    public class StudentService
    {
        private readonly StudentModel context;

        public StudentService()
        {
            context = new StudentModel();
        }

        public List<Student> GetAll()
        {
            return context.Students.Include("Faculty").Include("Major").ToList();
        }

        public List<Student> GetAllHasNoMajor()
        {
            return context.Students.Where(p => p.MajorID == null).ToList();
        }

        public List<Student> GetAllHasNoMajor(int facultyID)
        {
            return context.Students.Where(p => p.MajorID == null && p.FacultyID == facultyID).ToList();
        }

        public Student FindByID(string studentId)
        {
            return context.Students.FirstOrDefault(p => p.StudentID == studentId);
        }

        public Student FindStudentById(string studentId) 
        {
            return context.Students.FirstOrDefault(s => s.StudentID == studentId);
        }

        public void InsertOrUpdateStudent(Student student)
        {
            // KHÔNG tạo lại context mới, dùng context có sẵn
            try
            {
                var existing = context.Students.Find(student.StudentID);
                if (existing == null)
                {
                    context.Students.Add(student);
                }
                else
                {
                    existing.FullName = student.FullName;
                    existing.AverageScore = student.AverageScore;
                    existing.FacultyID = student.FacultyID;
                    existing.Avatar = student.Avatar;
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết: " + ex.InnerException?.Message ?? ex.Message);
            }

        }

    }
}
