using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    class Wolf : Animal
    {
        public string Sound { get; set; }//голос животного
        public Wolf(string type)
            : base("Wolf")
        {
            Sound = "Howl!";
        }
        public override void MakeSound()
        {
            Console.WriteLine(Sound);
        }
        public override void CheckStatus()
        {
            if (Satiety <= 55)
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
            return (brandFeed == "Feed1") || (brandFeed == "Feed3");
        }
    }
}
