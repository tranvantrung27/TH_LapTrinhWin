using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Lab05.DAL;
namespace Lab05.BUS
{
    public class MajorService
    {
        public List<Major> GetAllByFaculty(int facultyID)
        {
            StudentModel context = new StudentModel();
            return context.Majors.Where(p => p.FacultyID == facultyID).ToList();
        }
    }
}
