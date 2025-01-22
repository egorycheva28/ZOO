using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    public class Visitor : Person
    {
        public Guid Id { get; private set; }
        public Dictionary<string, int> Food;
        public double Money { get; set; }//сколько денег у человека
        public int FoodCost { get; set; }
        public Visitor(string name, string gender)
            : base(name, gender)
        {
            Id = Guid.NewGuid();
            Food = new Dictionary<string, int>();
            Money = 100;
            FoodCost = 10;
        }
        public bool BBuyFood<IFeed>()where IFeed:Feed
        {
            if (Money >= FoodCost )
            {
                string brandFeed = typeof(IFeed).Name;
                if (Food.ContainsKey(brandFeed))
                {
                    Food[brandFeed]++;
                    Money -= FoodCost;
                    return true;
                }
            }
            Console.WriteLine("Нет денег.");
            return false;
        }
    }
}