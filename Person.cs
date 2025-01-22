using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    public class Person: Registry
    {
        public string Name { get; set; }//имя посетителя
        public string Gender { get; set; }//пол человека
        public Person(string name, string gender)
        {
            Name = name;
            Gender = gender;
        }
    }
}
