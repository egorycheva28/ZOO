// See https://aka.ms/new-console-template for more information

using ООП;
using System;
using System.Collections.Generic;
//using System.Threading;
using System.Reflection;
using System.Xml.Linq;
//using System.Timers;

class Program
{
    public static void Main()
    {
        Zoo zoo = new Zoo();
        int pausa = 0;
        
        Console.WriteLine("Добро пожаловать, выберите команду");
        Console.WriteLine("1. Добавить нового посетителя");
        Console.WriteLine("2. Добавить нового сотрудника");
        Console.WriteLine("3. Добавить нового животного");
        Console.WriteLine("4. Редактировать посетителя");
        Console.WriteLine("5. Редактировать сотрудника");
        Console.WriteLine("6. Редактировать животного");
        Console.WriteLine("7. Удалить посетителя");
        Console.WriteLine("8. Удалить сотрудника");
        Console.WriteLine("9. Удалить животного");
        Console.WriteLine("10. Показать статус посетителя");
        Console.WriteLine("11. Показать статус сотрудника");
        Console.WriteLine("12. Показать статус животного");
        Console.WriteLine("13. Показать статус зоопарка");
        Console.WriteLine("14. Показать статус вольера");
        Console.WriteLine("15. Подать животному голос");
        Console.WriteLine("16. Создать новый вольер");
        Console.WriteLine("17. Поставить таймер на паузу");
        Console.WriteLine("18. Убрать у таймера паузу");
        Console.WriteLine("19. Добавить еду в вольер");
        Console.WriteLine("20. Закрыть зоопарк");

        while (true)
        {
            string command = Console.ReadLine();
            
            if (command == "1")
            {
                Console.WriteLine("Enter the name and the gender of the visitor:");
                string name = Console.ReadLine();
                string gender = Console.ReadLine();
                Registry visitor = new Visitor(name, gender);
                zoo.AddVisitor(visitor);
            }
            else if (command == "2")
            {
                Console.WriteLine("Enter the name, the gender and the status of the employee:");
                string name = Console.ReadLine();
                string gender = Console.ReadLine();
                string status = Console.ReadLine();
                Registry employee = new Employee(name, gender, status);
                zoo.AddEmployee(employee);
            }
            else if (command == "3")
            {
                Console.WriteLine("Enter the type of the animal:");
                string type = Console.ReadLine();
                if (type == "Tiger")
                {
                    Animal tiger = new Tiger(type);
                    zoo.AddAnimal(tiger);
                }
                else if (type == "Wolf")
                {
                    Animal wolf = new Wolf(type);
                    zoo.AddAnimal(wolf);
                }
                else
                {
                    Animal elephant = new Elephant(type);
                    zoo.AddAnimal(elephant);
                }
            }
            else if (command == "4")
            {      
                zoo.EditVisitor();
            }
            else if (command == "5")
            {
                zoo.EditEmployee();
            }
            else if (command == "6")
            {
                zoo.EditAnimal();
            }
            else if (command == "7")
            {
                if (pausa == 0)
                {
                    zoo.RemoveVisitor();
                }
                else
                {
                    Console.WriteLine("Зопарк на паузе.");
                }
            }
            else if (command == "8")
            {
                if (pausa == 0)
                {
                    zoo.RemoveEmployee();
                }
                else
                {
                    Console.WriteLine("Зопарк на паузе.");
                }
            }
            else if (command == "9")
            {
                if (pausa == 0)
                {
                    zoo.RemoveAnimal();
                }
                else
                {
                    Console.WriteLine("Зопарк на паузе.");
                }
            }
            else if (command == "10")
            {
                zoo.CheckStatusVisitor();
            }
            else if (command == "11")
            {
                zoo.CheckStatusEmployee();
            }
            else if (command == "12")
            {
                zoo.CheckStatusAnimal();
            }
            else if (command == "13")
            {
                zoo.CheckStatusZoo();
            }
            else if (command == "14")
            {
                zoo.CheckStatusAviary1();
            }
            else if (command == "15")
            {
                if (pausa == 0)
                {
                    zoo.MakeAnimalSound();
                }
                else
                {
                    Console.WriteLine("Зопарк на паузе.");
                }
            }
            else if (command == "16")
            {
                if (pausa == 0)
                {
                    
                    zoo.AddAviary();
                }
                else
                {
                    Console.WriteLine("Зопарк на паузе.");
                }
            }
            else if (command == "17")
            {                
                pausa = 1;
                zoo.TimerPausaOn();
            }
            else if (command == "18")
            {
                pausa = 0;
                zoo.TimerPausaOff();
            }
            else if (command == "19")
            {
                Console.WriteLine("Enter the brand and the weight of the feed:");
                string brand = Console.ReadLine();
                int weight = Convert.ToInt32(Console.ReadLine());
                
                Feed feed = new Feed(brand, weight);
                zoo.AddFeed(feed);
            }
            else if (command == "20")
            {
                Console.WriteLine("The zoo is closed");
                break;
            }
        }
    }    
}