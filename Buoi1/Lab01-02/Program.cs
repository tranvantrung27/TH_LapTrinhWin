using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine("║           📘 QUẢN LÝ DANH SÁCH SINH VIÊN     ║");
                Console.WriteLine("╠══════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Thêm sinh viên                            ║");
                Console.WriteLine("║ 2. Hiển thị danh sách sinh viên              ║");
                Console.WriteLine("║ 3. Sinh viên thuộc khoa CNTT                 ║");
                Console.WriteLine("║ 4. Sinh viên có điểm TB >= 5                 ║");
                Console.WriteLine("║ 5. Sắp xếp theo điểm TB tăng dần             ║");
                Console.WriteLine("║ 6. CNTT & điểm TB >= 5                       ║");
                Console.WriteLine("║ 7. SV điểm TB cao nhất & thuộc CNTT          ║");
                Console.WriteLine("║ 8. Thống kê xếp loại                         ║");
                Console.WriteLine("║ 0. Thoát                                     ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                Console.ResetColor();

                Console.Write("👉 Chọn chức năng (0-8): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(studentList); break;
                    case "2": DisplayStudentList(studentList); break;
                    case "3": DisplayStudentsByFaculty(studentList, "CNTT"); break;
                    case "4": DisplayStudentsWithHighAverageScore(studentList, 5); break;
                    case "5": SortStudentsByAverageScore(studentList); break;
                    case "6": DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5); break;
                    case "7": DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT"); break;
                    case "8": DisplayStudentClassificationStatistics(studentList); break;
                    case "0":
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("✅ Kết thúc chương trình.");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠️ Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("\n=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✔️ Thêm sinh viên thành công!\n");
            Console.ResetColor();
        }

        static void DisplayStudentList(IEnumerable<Student> studentList)
        {
            Console.WriteLine("\n=== 📋 Danh sách sinh viên ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,8}", "MSSV", "Họ tên", "Khoa", "ĐTB");
            Console.WriteLine(new string('-', 60));
            foreach (Student student in studentList)
            {
                Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,8:F2}",
                    student.StudentID, student.FullName, student.Faculty, student.AverageScore);
            }
        }

        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"\n=== Sinh viên thuộc khoa {faculty.ToUpper()} ===");
            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            DisplayStudentList(students);
        }

        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine($"\n=== Sinh viên có điểm TB >= {minDTB} ===");
            var students = studentList.Where(s => s.AverageScore >= minDTB);
            DisplayStudentList(students);
        }

        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("\n=== Sắp xếp sinh viên theo điểm TB tăng dần ===");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore);
            DisplayStudentList(sortedStudents);
        }

        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine($"\n=== Sinh viên {faculty.ToUpper()} có điểm TB >= {minDTB} ===");
            var students = studentList
                .Where(s => s.AverageScore >= minDTB && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));
            DisplayStudentList(students);
        }

        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"\n=== SV có ĐTB cao nhất và thuộc khoa {faculty.ToUpper()} ===");
            var maxScore = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .Max(s => s.AverageScore);

            var topStudents = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase) && s.AverageScore == maxScore);
            DisplayStudentList(topStudents);
        }

        static void DisplayStudentClassificationStatistics(List<Student> studentList)
        {
            Console.WriteLine("\n=== 📊 Thống kê xếp loại sinh viên ===");
            var classificationStats = studentList
                .GroupBy(s => GetClassification(s.AverageScore))
                .Select(g => new { Classification = g.Key, Count = g.Count() });

            foreach (var stat in classificationStats)
            {
                Console.WriteLine($"- {stat.Classification,-10}: {stat.Count} sinh viên");
            }
        }

        static string GetClassification(float score)
        {
            if (score >= 9.0f) return "Xuất sắc";
            else if (score >= 8.0f) return "Giỏi";
            else if (score >= 7.0f) return "Khá";
            else if (score >= 5.0f) return "Trung bình";
            else if (score >= 4.0f) return "Yếu";
            else return "Kém";
        }
    }
}
