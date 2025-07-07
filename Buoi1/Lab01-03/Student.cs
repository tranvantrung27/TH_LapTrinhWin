using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab01_03;

namespace Lab01_02
{
    public class Student : Person
    {
        private float averageScore; 
        private string faculty;

        public Student() { }

        public Student(string id, string fullname, float averageScore, string faculty)
            : base(id, fullname) // (1)
        {
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }

        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public override void Input() // (2)
        {
            base.Input();
            Console.WriteLine($"Khoa: {this.Faculty}");
            Faculty = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            AverageScore = float.Parse(Console.ReadLine());

        }

        public override void Output() // (3)
        {
            base.Output();
            Console.WriteLine("Điểm trung bình: {0} - Khoa: {1}", this.AverageScore, this.Faculty);
        }
    }

}
