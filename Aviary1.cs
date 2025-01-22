using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace ООП
{
    public class Aviary1 : Registry, Aviary
    {
        public Guid Id { get; private set; }
        public Dictionary<string, int> FeedSupply;
        public string AnimalType { get; set; }//животные, которые живут в вольере
        public int MaxCapacity { get; set; }//максимальная вместимость вольера
        public int Feed1Capacity { get; set; }//вместимость корма 1
        public int Feed2Capacity { get; set; }//вместимость корма 2
        public int Feed3Capacity { get; set; }//вместимость корма 3
        private List<Animal> Animals1 { get; set; }//список животных в вольере
        public Aviary1(string animalType)
        {
            Id = Guid.NewGuid();
            AnimalType = animalType;
            MaxCapacity = 5;
            FeedSupply = new Dictionary<string, int>();
            Feed1Capacity=9;
            Feed2Capacity=10;
            Feed3Capacity=8;
            Animals1 = new List<Animal>();
        }
        public void AddAnimalToAviary(Animal animal)
        {
            Animals1.Add(animal);
            if (AnimalType == "any")
            {
                AnimalType = animal.Type;
            }
        }
        public void RemoveAnimalFromAviary(Animal animal)
        {
            Animals1.Remove(animal);
            if (Animals1.Count == 0)
            {
                AnimalType = "any";
            }
        }
        public void CheckStatusAviary()
        {
            Console.WriteLine(AnimalType);
            foreach (var animal in Animals1)
            {
                animal.CheckStatus();
            }
            string brandFeed1 = typeof(Feed1).Name;
            string brandFeed2 = typeof(Feed2).Name;
            string brandFeed3 = typeof(Feed3).Name;
            Console.WriteLine($"Feedsupply: {FeedSupply.Count}");
        }
        public bool CanAddAnimal(Animal animal)
        {
            if ((AnimalType == animal.Type || AnimalType == "any") && Animals1.Count < MaxCapacity)
            {
                return true;
            }
            return false;
        }
        public bool CanAddFeed<IFeed>() where IFeed : Feed
        {
            string brandFeed = typeof(IFeed).Name;
            int maxCapacity = GetMaxCapacity(brandFeed);
            if (AnimalType == "Tiger" && (brandFeed == "Feed1" || brandFeed == "Feed2"))
            {
                return !FeedSupply.ContainsKey(brandFeed) || (FeedSupply.ContainsKey(brandFeed) && FeedSupply[brandFeed] < maxCapacity);

            }
            if (AnimalType == "Wolf" && (brandFeed == "Feed1" || brandFeed == "Feed3"))
            {
                return !FeedSupply.ContainsKey(brandFeed) || (FeedSupply.ContainsKey(brandFeed) && FeedSupply[brandFeed] < maxCapacity);

            }
            if (AnimalType == "Elephant" && (brandFeed == "Feed2" || brandFeed == "Feed3"))
            {
                return !FeedSupply.ContainsKey(brandFeed) || (FeedSupply.ContainsKey(brandFeed) && FeedSupply[brandFeed] < maxCapacity);

            }
            return !FeedSupply.ContainsKey(brandFeed) || (FeedSupply.ContainsKey(brandFeed) && FeedSupply[brandFeed] < maxCapacity);
        }
        public int GetMaxCapacity(string brandFeed)
        {
            if (brandFeed == nameof(Feed1))
            {
                return Feed1Capacity;
            }
            else if (brandFeed == nameof(Feed2))
            {
                return Feed2Capacity;
            }
            else if (brandFeed == nameof(Feed3))
            {
                return Feed3Capacity;
            }
            else
            {
                return 0;
            }
        }
        public void AddFeedToAviary<IFeed>() where IFeed : Feed
        {
            string brandFeed = typeof(IFeed).Name;
            int maxCapacity = GetMaxCapacity(brandFeed);
            if(!FeedSupply.ContainsKey(brandFeed))
            {
                FeedSupply.Add(brandFeed, maxCapacity);
                return;
            }
            if (FeedSupply[brandFeed] < maxCapacity)
            {
                FeedSupply[brandFeed]++;
            }
            else
            {
                Console.WriteLine("Запас корма полный");
            }
        }
        public void FeedAnimal<IFeed>(Visitor visitor) where IFeed : Feed
        {
            string brandFeed = typeof(IFeed).Name;
            Random random = new Random();
            int numberAnimal = random.Next(Animals1.Count);
            if (Animals1.Count == 0 || !Animals1[numberAnimal].CanEatFeed<IFeed>())
            {
                return;
            }
            if (Animals1[numberAnimal].Status == "Hungry" && Animals1[numberAnimal].Place == "open")
            {
                visitor.Food[brandFeed]--;
                Animals1[numberAnimal].Satiety++;
            }
            else
            {
                Console.WriteLine("Животное не голодно.");
            }
        }
        public void EatFood<IFeed>() where IFeed : Feed
        {
            string brandFeed = typeof(IFeed).Name;
            Random random = new Random();
            int numberAnimal = random.Next(Animals1.Count);
            if (Animals1.Count == 0 || !FeedSupply.ContainsKey(brandFeed) || !Animals1[numberAnimal].CanEatFeed<IFeed>())
            {
                return;
            }
            if (Animals1[numberAnimal].Status == "Hungry")
            {
                if (FeedSupply[brandFeed] > 0)
                {
                    FeedSupply[brandFeed]--;
                    Animals1[numberAnimal].Satiety++;
                }
                else
                {
                    Console.WriteLine("Недостаточно корма в вольере.");
                }
            }
            else
            {
                Console.WriteLine($"Животное номер {numberAnimal} не голодно.");
            }
        }
        public void MoveNewPart()
        {
            Random random = new Random();
            int numberAnimal = random.Next(Animals1.Count);
            if (Animals1.Count == 0)
            {
                return;
            }
            if (Animals1[numberAnimal].Place == "open")
            {
                Animals1[numberAnimal].Place = "close";
            }
            else
            {
                Animals1[numberAnimal].Place = "open";
            }
        }
    }
}
