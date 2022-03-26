using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON__de_serialization
{
    internal class student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name},{Age}";
        }

    }
}
