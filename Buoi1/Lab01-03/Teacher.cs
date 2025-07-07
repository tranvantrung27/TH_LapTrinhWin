using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Teacher : Person
    {
        private string address;

        public Teacher() { }

        public Teacher(string id, string fullname, string address)
            : base(id, fullname) // (1)
        {
            this.Address = address;
        }

        public string Address { get => address; set => address = value; }

        public override void Input()
        {
            Console.OutputEncoding = Encoding.UTF8;
            base.Input();
            Console.Write("Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }


        public override void Output() // (3)
        {
            base.Output();
            Console.WriteLine("Địa chỉ: {0}", this.Address);
        }
    }

}
