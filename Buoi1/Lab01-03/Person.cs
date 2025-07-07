using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Person
    {
        private string id;
        private string fullname;

        public Person() { }

        public Person(string id, string fullname)
        {
            this.Id = id;
            this.Fullname = fullname;
        }

        public string Id { get => id; set => id = value; }

        public string Fullname { get => fullname; set => fullname = value; }

        public virtual void Input() // (1)
        {
            Console.Write("Nhập mã: ");
            Id = Console.ReadLine();
            Console.Write("Nhập họ và tên: ");
            Fullname = Console.ReadLine();
        }

        public virtual void Output() // (2)
        {
            Console.Write("ID:{0} - Name: {1}", this.Id, this.Fullname);
        }
    }

}
