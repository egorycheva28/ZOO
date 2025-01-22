using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    class Tiger : Animal
    {
        public string Sound { get; set; }//голос животного
        public Tiger(string type)
            : base("Tiger")
        {
            Sound = "Roar!";
        }
        public override void MakeSound()
        {
            Console.WriteLine(Sound);
        }
        public override void CheckStatus()
        {
            if (Satiety <= 65)
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
            return (brandFeed == "Feed1") || (brandFeed == "Feed2");
        }
    }
}
