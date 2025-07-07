using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab01_02;

namespace Lab01_03
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════╗");
                Console.WriteLine("║           📘 QUẢN LÝ THÔNG TIN SINH VIÊN & GV      ║");
                Console.WriteLine("╠════════════════════════════════════════════════════╣");
                Console.WriteLine("║ 1. Thêm sinh viên                                  ║");
                Console.WriteLine("║ 2. Thêm giáo viên                                  ║");
                Console.WriteLine("║ 3. Hiển thị danh sách sinh viên                    ║");
                Console.WriteLine("║ 4. Hiển thị danh sách giáo viên                    ║");
                Console.WriteLine("║ 5. Số lượng sinh viên & giáo viên                  ║");
                Console.WriteLine("║ 6. Sinh viên thuộc khoa 'CNTT'                     ║");
                Console.WriteLine("║ 7. Giáo viên có địa chỉ chứa 'Quận 9'              ║");
                Console.WriteLine("║ 8. SV điểm cao nhất thuộc khoa 'CNTT'              ║");
                Console.WriteLine("║ 9. Thống kê xếp loại sinh viên                     ║");
                Console.WriteLine("║ 0. Thoát                                           ║");
                Console.WriteLine("╚════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.Write("👉 Chọn chức năng: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": AddTeacher(); break;
                    case "3": DisplayStudents(); break;
                    case "4": DisplayTeachers(); break;
                    case "5": ShowCounts(); break;
                    case "6": DisplayCNTTStudents(); break;
                    case "7": DisplayTeachersInDistrict9(); break;
                    case "8": DisplayTopCNTTStudents(); break;
                    case "9": DisplayStudentClassifications(); break;
                    case "0": exit = true; Console.WriteLine("✅ Kết thúc chương trình."); break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠️ Chức năng không hợp lệ. Vui lòng chọn lại.");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine();
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("\n=== ➕ Nhập thông tin sinh viên ===");
            var s = new Student();
            s.Input();
            students.Add(s);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✔️ Đã thêm sinh viên thành công!\n");
            Console.ResetColor();
        }

        static void AddTeacher()
        {
            Console.WriteLine("\n=== ➕ Nhập thông tin giáo viên ===");
            var t = new Teacher();
            t.Input();
            teachers.Add(t);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✔️ Đã thêm giáo viên thành công!\n");
            Console.ResetColor();
        }

        static void DisplayStudents()
        {
            Console.WriteLine("\n=== 📋 DANH SÁCH SINH VIÊN ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,8}", "MSSV", "Họ tên", "Khoa", "ĐTB");
            Console.WriteLine(new string('-', 60));
            foreach (var s in students)
                Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,8:F2}", s.Id, s.Fullname, s.Faculty, s.AverageScore);
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("\n=== 📋 DANH SÁCH GIÁO VIÊN ===");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-30}", "MSGV", "Họ tên", "Địa chỉ");
            Console.WriteLine(new string('-', 70));
            foreach (var t in teachers)
                Console.WriteLine("{0,-10} | {1,-25} | {2,-30}", t.Id, t.Fullname, t.Address);
        }

        static void ShowCounts()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n👩‍🎓 Tổng số sinh viên: {students.Count}");
            Console.WriteLine($"👨‍🏫 Tổng số giáo viên: {teachers.Count}\n");
            Console.ResetColor();
        }

        static void DisplayCNTTStudents()
        {
            Console.WriteLine("\n=== 📌 Sinh viên thuộc khoa CNTT ===");
            var list = students.Where(s => s.Faculty != null && s.Faculty.Trim().ToLower() == "cntt").ToList();
            DisplayStudents(list);
        }

        static void DisplayTeachersInDistrict9()
        {
            Console.WriteLine("\n=== 📌 Giáo viên có địa chỉ chứa 'Quận 9' ===");
            var list = teachers.Where(t => t.Address != null &&
                RemoveDiacritics(t.Address.ToLower()).Contains("quan 9"))
                .ToList();
            DisplayTeachers(list);
        }

        static void DisplayTopCNTTStudents()
        {
            Console.WriteLine("\n=== 🏆 SV có ĐTB cao nhất thuộc khoa CNTT ===");
            var cnttStudents = students.Where(s => s.Faculty != null && s.Faculty.Trim().ToLower() == "cntt").ToList();
            if (cnttStudents.Count == 0) return;
            float max = cnttStudents.Max(s => s.AverageScore);
            var top = cnttStudents.Where(s => s.AverageScore == max).ToList();
            DisplayStudents(top);
        }

        static void DisplayStudentClassifications()
        {
            Console.WriteLine("\n=== 📊 Thống kê xếp loại sinh viên ===");
            var result = students.GroupBy(s => GetClassification(s.AverageScore))
                                 .Select(g => new { Type = g.Key, Count = g.Count() });
            foreach (var r in result)
                Console.WriteLine($"- {r.Type,-10}: {r.Count} sinh viên");
        }

        static string GetClassification(float score)
        {
            if (score >= 9) return "Xuất sắc";
            else if (score >= 8) return "Giỏi";
            else if (score >= 7) return "Khá";
            else if (score >= 5) return "Trung bình";
            else if (score >= 4) return "Yếu";
            else return "Kém";
        }

        static void DisplayStudents(List<Student> list)
        {
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,8}", "MSSV", "Họ tên", "Khoa", "ĐTB");
            Console.WriteLine(new string('-', 60));
            foreach (var s in list)
                Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,8:F2}", s.Id, s.Fullname, s.Faculty, s.AverageScore);
        }

        static void DisplayTeachers(List<Teacher> list)
        {
            Console.WriteLine("{0,-10} | {1,-25} | {2,-30}", "MSGV", "Họ tên", "Địa chỉ");
            Console.WriteLine(new string('-', 70));
            foreach (var t in list)
                Console.WriteLine("{0,-10} | {1,-25} | {2,-30}", t.Id, t.Fullname, t.Address);
        }

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
