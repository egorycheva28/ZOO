using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
//using System.Threading;
using System.Timers;
using ООП;
using Timer=System.Timers.Timer;

namespace ООП
{
    class Zoo
    {
        private List<Registry> zooObjects = new List<Registry>();
        //public List<Visitor> Visitors { get; set; }
        //public List<Employee> Employees { get; set; }
        //public List<Animal> Animals { get; set; }
        //public List<Aviary> Aviaries { get; set; }
        //public List<Feed> Feeds { get; set; }
        private Timer timerSatiety;
        private Timer timerMoveInAviary;
        private Timer timerFeed;
        private Timer timerEatFood;

        public Zoo()
        {
            //Visitors = new List<Visitor>();
            //Employees = new List<Employee>();
            //Animals = new List<Animal>();
            //Aviaries = new List<Aviary>();
            //Feeds = new List<Feed>();

            string[] animalTypes = { "Tiger", "Wolf", "Elephant" };

            Random random = new Random();

            for (int i = 0; i < 15; i++)
            {
                string randomType = animalTypes[random.Next(animalTypes.Length)];
                Animal animal = types(randomType);

                Aviary newAviary1 = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddAnimal(animal));
                if (newAviary1 == null)
                {
                    Aviary1 newAviary2 = new Aviary1(randomType);
                    zooObjects.Add(newAviary2);
                    newAviary1 = newAviary2;
                }
                newAviary1.AddAnimalToAviary(animal);
                zooObjects.Add(animal);

            }

            timerSatiety = new Timer(1000);
            timerSatiety.Elapsed += TimerCallback;
            timerSatiety.AutoReset = true;
            timerSatiety.Enabled = true;

            timerMoveInAviary = new Timer(5000);
            timerMoveInAviary.Elapsed += MMoveNewPart;
            timerMoveInAviary.AutoReset = true;
            timerMoveInAviary.Enabled = true;

            timerFeed = new Timer(10000);
            timerFeed.Elapsed += FFeedAnimal;
            timerFeed.AutoReset = true;
            timerFeed.Enabled = true;

            timerEatFood = new Timer(10000);
            timerEatFood.Elapsed += EEatFood;
            timerEatFood.AutoReset = true;
            timerEatFood.Enabled = true;
        }
        public Animal types(string type)
        {
            if (type == "Tiger")
            {
                return new Tiger(type);
            }
            else if (type == "Wolf")
            {
                return new Wolf(type);
            }
            else
            {
                return new Elephant(type);
            }
        }
        private void TimerCallback(object sender, ElapsedEventArgs e)
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Animal animal)
                {
                    animal.DecreaseSatiety();
                }
            }
        }
        public void MMoveNewPart(object sender, ElapsedEventArgs e)
        {
            List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();
            if (aviaries.Count == 0)
            {
                return;
            }
            Random random = new Random();
            int numberAviary = random.Next(aviaries.Count);
            aviaries[numberAviary].MoveNewPart();
        }

        public void FFeedAnimal(object sender, ElapsedEventArgs e)
        {
            List<Visitor> visitors = zooObjects.OfType<Visitor>().ToList<Visitor>();
            List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();
            visitors.ForEach(visitor =>
            {
                if (aviaries.Count == 0)
                {
                    return;
                }
                Random random = new Random();
                int brandFeed = random.Next(1,3);
                if (brandFeed == 1)
                {
                    if (visitor.BBuyFood<Feed1>())
                    {
                        int numberAviary = random.Next(aviaries.Count);
                        OpenPart openAviary = aviaries[numberAviary] as OpenPart;
                        openAviary.FeedAnimal<Feed1>(visitor);
                    }
                }
                else if (brandFeed == 2)
                {
                    if (visitor.BBuyFood<Feed2>())
                    {
                        int numberAviary = random.Next(aviaries.Count);
                        OpenPart openAviary = aviaries[numberAviary] as OpenPart;
                        openAviary.FeedAnimal<Feed2>(visitor);
                    }
                }
                else if (brandFeed == 3)
                {
                    if (visitor.BBuyFood<Feed3>())
                    {
                        int numberAviary = random.Next(aviaries.Count);
                        OpenPart openAviary = aviaries[numberAviary] as OpenPart;
                        openAviary.FeedAnimal<Feed3>(visitor);
                    }
                }
            });
        }
        public void AddFeed(Feed feed)
        {
            List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();
            
            if (feed.Brand=="Feed1")
            {
                Aviary newAviary1 = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddFeed<Feed1>());
                if (aviaries.Count > 0)
                {
                    if (newAviary1 == null)
                    {
                        Console.WriteLine("Нет доступного вольера");
                        return;
                    }
                    newAviary1.AddFeedToAviary<Feed1>();
                    zooObjects.Add(feed);
                }
                else
                {
                    Console.WriteLine("Добавьте новый вольер для этого корма");
                }
            }
            else if (feed.Brand == "Feed2")
            {
                Aviary newAviary1 = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddFeed<Feed2>());
                if (aviaries.Count > 0)
                {
                    if (newAviary1 == null)
                    {
                        Console.WriteLine("Нет доступного вольера");
                        return;
                    }
                    newAviary1.AddFeedToAviary<Feed2>();
                    zooObjects.Add(feed);
                }
                else
                {
                    Console.WriteLine("Добавьте новый вольер для этого корма");
                }
            }
            else if (feed.Brand == "Feed3")
            {
                Aviary newAviary1 = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddFeed<Feed3>());
                if (aviaries.Count > 0)
                {
                    if (newAviary1 == null)
                    {
                        Console.WriteLine("Нет доступного вольера");
                        return;
                    }
                    newAviary1.AddFeedToAviary<Feed3>();
                    zooObjects.Add(feed);
                }
                else
                {
                    Console.WriteLine("Добавьте новый вольер для этого корма");
                }
            }

        }
        public void EEatFood(object sender, ElapsedEventArgs e)
        {
            List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();
            if (aviaries.Count == 0)
            {
                return;
            }
            Random random = new Random();
            int brandFeed = random.Next(1,3);
            int numberAviary = random.Next(aviaries.Count);
            
            if(brandFeed==1)
            {
                aviaries[numberAviary].EatFood<Feed1>();
            }
            else if (brandFeed == 2)
            {
                aviaries[numberAviary].EatFood<Feed2>();
            }
            else if (brandFeed == 3)
            {
                aviaries[numberAviary].EatFood<Feed3>();
            }            
        }
        public void AddVisitor(Registry visitor)
        {
            zooObjects.Add(visitor);
        }
        public void AddEmployee(Registry employee)
        {
            zooObjects.Add(employee);
        }
        public void AddAnimal(Animal animal)
        {
            Aviary newAviary = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddAnimal(animal));
            List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();
            if (aviaries.Count > 0)
            {
                if (newAviary == null)
                {
                    Console.WriteLine("Нет свободного вольера");
                    return;
                }
                newAviary.AddAnimalToAviary(animal);
                zooObjects.Add(animal);
            }
            else
            {
                Console.WriteLine("Добавьте новый вольер для этого животного");
            }            
        }
        public void EditVisitor()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Visitor visitor)
                {
                    Console.WriteLine($"ID: {visitor.Id}");
                }
            }
            Console.WriteLine("Enter the id of the visitor:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid visitorId))
            {
                Visitor visitor1 = (Visitor)zooObjects?.Find(obj => obj is Visitor visitor && visitor.Id == visitorId);
                Console.WriteLine("Enter the new name and the new gender of the visitor:");
                visitor1.Name = Console.ReadLine();
                visitor1.Gender = Console.ReadLine();
            }
            
        }
        public void EditEmployee()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Employee employee)
                {
                    Console.WriteLine($"ID: {employee.Id}");
                }
            }
            Console.WriteLine("Enter the id of the employee:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid employeeId))
            {
                Employee employee1 = (Employee)zooObjects?.Find(obj => obj is Employee employee && employee.Id == employeeId);
                Console.WriteLine("Enter the new name, the new gender and the new status of the employee:");
                employee1.Name = Console.ReadLine();
                employee1.Gender = Console.ReadLine();
                employee1.Status = Console.ReadLine();
            }
            
        }
        public void EditAnimal()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Animal animal)
                {
                    Console.WriteLine($"ID: {animal.Id}");
                }
            }
            Console.WriteLine("Enter the id of the animal:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid animalId))
            {
                Animal animal1 = (Animal)zooObjects?.Find(obj => obj is Animal animal && animal.Id == animalId);

                Aviary newAviary = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddAnimal(animal1));
                List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();
                if (aviaries.Count > 0)
                {
                    if (newAviary == null)
                    {
                        Console.WriteLine("Вольера с такими животными нет");
                        return;
                    }
                    newAviary.RemoveAnimalFromAviary(animal1);
                    zooObjects.Remove(animal1);


                }
                else
                {
                    Console.WriteLine("Вольеров нет");
                }

                Console.WriteLine("Enter the new type of the animal:");
                animal1.Type = Console.ReadLine();

                Aviary newAviary1 = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddAnimal(animal1));
                if (aviaries.Count > 0)
                {
                    if (newAviary1 == null)
                    {
                        Console.WriteLine("Нет свободного вольера");
                        return;
                    }
                    newAviary1.AddAnimalToAviary(animal1);
                    zooObjects.Add(animal1);
                }
                else
                {
                    Console.WriteLine("Добавьте новый вольер для этого животного");
                }


            }
        }
        public void RemoveVisitor()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Visitor visitor)
                {
                    Console.WriteLine($"ID: {visitor.Id}");
                }
            }
            Console.WriteLine("Enter the id of the visitor:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid visitorId))
            {
                Visitor visitor1 = (Visitor)zooObjects?.Find(obj => obj is Visitor visitor && visitor.Id == visitorId);
                zooObjects.Remove(visitor1);
            }
        }
        public void RemoveEmployee()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Employee employee)
                {
                    Console.WriteLine($"ID: {employee.Id}");
                }
            }
            Console.WriteLine("Enter the id of the employee:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid employeeId))
            {
                Employee employee1 = (Employee)zooObjects?.Find(obj => obj is Employee employee && employee.Id == employeeId);
                zooObjects.Remove(employee1);
            }
        }
        public void RemoveAnimal()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Animal animal)
                {
                    Console.WriteLine($"ID: {animal.Id}");
                }
            }
            Console.WriteLine("Enter the id of the animal:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid animalId))
            {
                
                List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();

                if (aviaries.Count > 0)
                {
                    Animal animal1 = (Animal)zooObjects?.Find(obj => obj is Animal animal && animal.Id == animalId);
                    Aviary newAviary = zooObjects.OfType<Aviary>().FirstOrDefault(aviary => aviary.CanAddAnimal(animal1));
                    if (newAviary == null)
                    {
                        Console.WriteLine("Вольера с такими животными нет");
                        return;
                    }
                    newAviary.RemoveAnimalFromAviary(animal1);
                    zooObjects.Remove(animal1);
                }
            }
            else
            {
                Console.WriteLine("Вольеров нет");
            }
        }
        public void CheckStatusVisitor()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Visitor visitor)
                {
                    Console.WriteLine($"ID: {visitor.Id}");
                    
                }
            }
            var list = Sorted();
            foreach(var obj in list)
            {
                Console.WriteLine($"Name:{obj}");
            }
            Console.WriteLine("Enter the id of the visitor:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid visitorId))
            {
                Visitor visitor1 = (Visitor)zooObjects?.Find(obj => obj is Visitor visitor && visitor.Id == visitorId);
                if (visitor1 != null)
                {
                    Console.WriteLine($"Name:{visitor1.Name},Gender:{visitor1.Gender}, Money:{visitor1.Money}");
                }
            }
            
        }
        public IEnumerable<string> Sorted()
        {
            var sortedName = zooObjects.OfType<Visitor>().OrderBy(visitor=>visitor,new Comparator()).ToList();
            return sortedName.Select(visitor => $"{visitor.Name}");
        }
        public class Comparator:IComparer<Visitor>
        {
            public int Compare(Visitor visitor1, Visitor visitor2)

            {
                return string.Compare(visitor1.Name, visitor2.Name);
            } 
        }
        public void CheckStatusEmployee()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Employee employee)
                {
                    Console.WriteLine($"ID: {employee.Id}");
                }
            }
            Console.WriteLine("Enter the id of the employee:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid employeeId))
            {
                Employee employee1 = (Employee)zooObjects?.Find(obj => obj is Employee employee && employee.Id == employeeId);
                if (employee1 != null)
                {
                    Console.WriteLine($"Name:{employee1.Name},Gender:{employee1.Gender},Status:{employee1.Status}");
                }
            }
            
        }
        public void CheckStatusAnimal()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Animal animal)
                {
                    Console.WriteLine($"ID: {animal.Id}");
                }
            }
            Console.WriteLine("Enter the id of the animal:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid animalId))
            {
                Animal animal1 = (Animal)zooObjects?.Find(obj => obj is Animal animal && animal.Id == animalId);
                if (animal1 != null)
                {
                    animal1.CheckStatus();
                }
            }
            
        }
        public void CheckStatusZoo()
        {
            List<Visitor> visitors = zooObjects.OfType<Visitor>().ToList<Visitor>();
            List<Employee> employees = zooObjects.OfType<Employee>().ToList<Employee>();
            List<Animal> animals = zooObjects.OfType<Animal>().ToList<Animal>();
            List<Aviary> aviaries = zooObjects.OfType<Aviary>().ToList<Aviary>();
            Console.WriteLine($"Number of visitors: {visitors.Count}");
            Console.WriteLine($"Number of employees: {employees.Count}");
            Console.WriteLine($"Number of animals: {animals.Count}");
            Console.WriteLine($"Number of aviaries: {aviaries.Count}");
        }
        public void CheckStatusAviary1()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Aviary1 aviary)
                {
                    Console.WriteLine($"ID: {aviary.Id}");
                }
            }
            Console.WriteLine("Enter the id of the aviary:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid aviaryId))
            {
                Aviary1 aviary1 = (Aviary1)zooObjects?.Find(obj => obj is Aviary1 aviary && aviary.Id == aviaryId);
                if (aviary1 != null)
                {
                    aviary1.CheckStatusAviary(); 
                }
            }
            
        }
        public void MakeAnimalSound()
        {
            foreach (var obj in zooObjects)
            {
                if (obj is Animal animal)
                {
                    Console.WriteLine($"ID: {animal.Id}");
                }
            }
            Console.WriteLine("Enter the id of the animal:");
            string inputId = Console.ReadLine();
            if (Guid.TryParse(inputId, out Guid animalId))
            {
                Animal animal1 = (Animal)zooObjects?.Find(obj => obj is Animal animal && animal.Id == animalId);
                if (animal1 != null)
                {
                    animal1.MakeSound();
                }
            }
            
        }
        public void AddAviary()
        {
            Registry aviary = new Aviary1("any");
            zooObjects.Add(aviary);
        }
        public void TimerPausaOn()
        {
            timerSatiety.Enabled = false;
            timerFeed.Enabled = false;
            timerEatFood.Enabled = false;
        }
        public void TimerPausaOff()
        {
            timerSatiety.Enabled = true;
            timerFeed.Enabled = true;
            timerEatFood.Enabled = true;
        }
    }
}
