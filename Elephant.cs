using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    class Elephant : Animal
    {
        public string Sound { get; set; }//голос животного
        public Elephant(string type)
            : base("Elephant")
        {
            Sound = "Trumpet!";
        }
        public override void MakeSound()
        {
            Console.WriteLine(Sound);
        }
        public override void CheckStatus()
        {
            if (Satiety <= 45)
            {
                Status = "Hungry";
                Console.WriteLine($"Satiety:{Satiety},Status:{Status}");
            }
            else
            {
                Console.WriteLine($"Satiety:{Satiety},Status:{Status}");
            }
        }
        public override bool CanEatFeed<IFeed>() where IFeed : class
        {
            string brandFeed = typeof(IFeed).Name;
            return (brandFeed == "Feed2") || (brandFeed == "Feed3");
        }
    }
}
