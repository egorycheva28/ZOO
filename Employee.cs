using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    public class Employee : Person
    {
        public Guid Id { get; private set; }
        public string Status { get; set; }//должность сотрудника
        public Employee(string name, string gender, string status)
            : base(name, gender)
        {
            Id = Guid.NewGuid();
            Status = status;
        }
       /* public void ShowStatus()
        {
            Console.WriteLine($"Name:{employee.Name},Gender:{employee.Gender},Status:{employee.Status}");
        }*/
        /*public void FillFoodSupply(Aviary1 aviary)
        {
            if (aviary.FoodSupply == 0)
            {
                aviary.FoodSupply = 100;
            }
        }*/
    }
}
