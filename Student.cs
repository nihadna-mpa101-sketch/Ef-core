using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Grade { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        override public string ToString()
        {
            return $"{Id} - {Name} - {Age} - {Grade} - GroupName: {Group.Name}";
        }
    }
}
