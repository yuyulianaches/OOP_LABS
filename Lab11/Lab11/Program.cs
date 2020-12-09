using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            //____________________Задание 1___________________________
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] summer_winter_months = { "January", "February", "June", "July", "August", "December" };
            //____________________Выбор по длине строки
            Console.WriteLine("Введите длину строки (до 8 символов!)");
            int n = Convert.ToInt32(Console.ReadLine());

            var selectedMon = from m in months
                              where m.Length == n
                              select m;
            foreach (string s in selectedMon) Console.Write(s + " ");
            //____________________Зимние и летние месяцы
            // Intersect - пересечение последовательностей (выбор общих элементов) 

            Console.WriteLine("\nВывод только зимних и летних месяцев: ");
            var selectedSummerWinterMon = months.Intersect<string>(summer_winter_months);
            foreach (string s in selectedSummerWinterMon) Console.Write(s + " ");

            //_________________Упорядочивание в алфавитном порядке

            var selectedOrd = from m in months
                              orderby m
                              select m;
            Console.WriteLine("\nУпорядоченный вывод: ");
            foreach (string s in selectedOrd) Console.Write(s + " ");

            //_________________содержат "u" и длиной не менее 4 символов
            Console.WriteLine("\nCодержат 'u': ");

            var selectedU = from m in months
                            where m.Contains("u")
                            select m;
            foreach (string s in selectedU) Console.Write(s + " ");
            Console.WriteLine("\nДлина более 4 символов: ");
            var selectedMore = from m in months
                               where m.Length > 4
                               select m;
            foreach (string s in selectedMore) Console.Write(s + " ");
            var selectedBoth = selectedU.Intersect<string>(selectedMore);
            Console.WriteLine("\nCодержат 'u' и длина более 4 символов: ");
            foreach (string s in selectedBoth) Console.Write(s + " ");

            List<Train> trains = new List<Train>();
            trains.Add(new Train("Ночь", 3, 50));
            trains.Add(new Train("Утро", 9, 45));
            trains.Add(new Train("Утро", 11, 10));
            trains.Add(new Train("День", 14, 35));
            trains.Add(new Train("День", 14, 30));
            trains.Add(new Train("День", 14, 30));
            trains.Add(new Train("Вечер", 17, 30));
            trains.Add(new Train("День", 15, 15));
            trains.Add(new Train("День", 16, 16));
            trains.Add(new Train("Вечер", 17, 30));
            trains.Add(new Train("Вечер", 17, 30));
            trains.Add(new Train("Вечер", 26, 20));
            trains.Add(new Train("Ночь", 2, 10));
     
            foreach (Train t in trains) t.Show();
            //выбор по заданному времени
            Console.WriteLine("\nВведите часы и минуты:");
            int h = Convert.ToInt32(Console.ReadLine());
            int min = Convert.ToInt32(Console.ReadLine());
            var selectTime = from tr1 in trains
                             where tr1.Hourse == h && tr1.Minutes == min
                             select tr1;
            foreach (Train tr1 in selectTime) tr1.Show();
            //списки по группам ночь, утро, день, вечер

            var selectedGroup = from tr2 in trains
                                group tr2 by tr2.Time;
            Console.WriteLine();
            foreach (IGrouping<string, Train> tr2 in selectedGroup)
            {
                Console.WriteLine("_____________________________");
                Console.WriteLine("Cортировка по ключевому слову: " + tr2.Key);
                foreach (var t in tr2)
                    t.Show();
                Console.WriteLine();

        
            }
        
            var selectedGroup3 = trains.GroupBy(tr3 => tr3.Time)
                        .Select(elem => new { Time = elem.Key, Count = elem.Count() });
            foreach (var train in selectedGroup3)
                Console.WriteLine($"{train.Time} : {train.Count}");

            //Минимальное время

            var MinH = trains.Min(tr4 => tr4.Hourse);
            
            var selectedMinH = from tr4 in trains
                                  where tr4.Hourse == MinH
                                  select tr4;
            var MinM = selectedMinH.Min(tr4 => tr4.Minutes);
            var selectedMinTime = from tr4 in selectedMinH
                                  where tr4.Minutes == MinM
                                  select tr4;
            Console.WriteLine("Минимальное время: ");
            foreach (var train in selectedMinTime)
                Console.WriteLine($"{train.Hourse} : {train.Minutes}");

            //Первое время, где часы и минуты совпадают

            Train train_ = trains.First(tr5 => (tr5.Hourse == tr5.Minutes));
            Console.WriteLine("Первое совпадение часов и минут: "+ train_.Hourse +" : "+train_.Minutes);

            //упорядочение
            var selectedOrdH = from tr6 in trains
                               orderby tr6.Hourse, tr6.Minutes
                               select tr6;
            Console.WriteLine("Cортировка по времени (упорядоченный список): ");
            foreach (var train in selectedOrdH)
                train.Show();

            //___________________ЗАДАНИЕ4________________________
            Console.WriteLine("Cписок 1:");

            List<Agency> persons = new List<Agency>();
            persons.Add(new Agency("Петр", "Петров", 45, 50, 800, 40));
            persons.Add(new Agency("Анна", "Сидорова", 61, 10, 700, 30));
            persons.Add(new Agency("Лилия", "Ахматова", 24, 45, 1000, 30));
            persons.Add(new Agency("Роман", "Косов", 32, 20, 700, 30));
            persons.Add(new Agency("Кира", "Нинова", 33, 0, 700, 30));
            persons.Add(new Agency("Иван", "Косов", 40, 0, 600, 40));
            foreach (Agency ag in persons)
                ag.Info();

         


            //проекция, позволяет спроектировать из текущего типа выборки какой-то другой тип.

            var selectedAge = persons.Select(p => new
            {
                FName = p.FirstName,
                Name =  p.SecondName,
                DateOfBirth = DateTime.Now.Year - p.age
            });
            var selectedNew = persons.Select(p => new
            {
                FName = p.FirstName,
                Name = p.SecondName,
                New_Sal = p.salary +p.addToSalary - p.tax
            });
            int minage= persons.Min(p=>p.age);
            Console.WriteLine("Минимальный возраст: " + minage) ;

            int maxage = persons.Max(p => p.age);
            Console.WriteLine("Максимальный возраст: " + maxage);

            double avrAge = persons.Average(p => p.age); 
            Console.WriteLine("Cредний возраст: " + avrAge);

            Console.WriteLine();
            foreach (var p in selectedAge)
                Console.WriteLine($"Дата рождения: {p.FName} {p.Name} - {p.DateOfBirth}");
            foreach (var p in selectedNew)
                Console.WriteLine($"Прибыль с учетом премии и вычетом налогов: {p.FName} {p.Name} - {p.New_Sal}");
            //сортировка (по убыванию)
            var sortedSalary = persons.OrderByDescending(p1 => p1.salary).ThenByDescending(p1=>p1.addToSalary);
            foreach (var p in sortedSalary)
                Console.WriteLine($"Упорядочивание заплаты (по убыванию): {p.FirstName} -  {p.salary}, налог: {p.addToSalary}");
            //группировка по налогу:

            var selectedGr = persons.GroupBy(p3 => p3.tax)
                        .Select(man => new { Tax = man.Key, Count = man.Count() });
            foreach (var tax_ in selectedGr)
                Console.WriteLine($"Налог {tax_.Tax} имеют {tax_.Count} человек");
            Console.WriteLine();
            Console.WriteLine("Список 2: ");
            List<Agency> persons2 = new List<Agency>();
            persons2.Add(new Agency("Петр", "Петров", 45, 50, 800, 40));
            persons2.Add(new Agency("Анна", "Сидорова", 61, 10, 700, 30));
            persons2.Add(new Agency("Жанна", "Успенская", 24, 45, 1000, 30));
            persons2.Add(new Agency("Игорь", "Артемович", 24, 45, 1000, 30));
            
            foreach (Agency ag in persons2)
                ag.Info();
            //вычитание(разность)
            Console.WriteLine("\nВычитание списков: ");
          
            var res = persons.Except(persons2);
            foreach (Agency s in res)
                s.Info();

            //объединение списков
            Console.WriteLine("\nОбъединение списков: ");

            var res2 = persons.Union(persons2).Distinct();
            foreach (Agency s in res2)
                s.Info();


            Console.WriteLine();
            Console.WriteLine("Список 3: ");
            List<City> cities = new List<City>();
            cities.Add(new City("Иван", "Брест"));
            cities.Add(new City("Анна", "Минск"));
            cities.Add(new City("Игорь", "Брест"));
            cities.Add(new City("Жанна", "Гомель"));
            cities.Add(new City("Алексей", "Витебск"));
            cities.Add(new City("Роман", "Витебск"));

            foreach(City c in cities)
            c.Print();
            //JOIN
            var all = from person in persons
                         join city in cities on person.FirstName equals city.Name
                         select new { Name = person.FirstName, F = person.SecondName, Place = city.placeOfWork };

            foreach (var info in all)
                Console.WriteLine($"Сотрудник {info.Name} {info.F} работает в городе {info.Place}");
            Console.ReadKey();

        }
        public class Train
        {

            private string time;
            private int hourse;
            private int minutes;


            public string Time
            {
                get
                {
                    return time;
                }
                set
                {
                    time = value;
                }

            }
            public int Hourse
            {
                get { return hourse; }
                set
                {
                    if (value > 23) hourse = 23;
                    else if (value < 0) hourse = 0;
                    else hourse = value;
                }
            }
            public int Minutes
            {
                get { return minutes; }
                set
                {
                    if (value > 60) minutes = 60;
                    else if (value < 0) minutes = 0;
                    else minutes = value;
                }
            }
            public Train(string time, int hourse, int minutes) //передаем значения
            {
                this.Minutes = minutes;
                this.Hourse = hourse;
                this.time = time;

            }

            public void Show()
            {
                Console.WriteLine();
                Console.Write("Время отправки поезда. Часы:" + this.Hourse + "\tМинуты: " + this.Minutes + "\tВремя суток: " + this.Time);
            }

        }
        

    }
    public class Agency
    {
        public string FirstName;
        public string SecondName;
        public int age;
        public int addToSalary;
        public int salary;
        public int tax;
        public Agency(string f, string n, int age, int a, int s, int t)
        {
            this.FirstName = f;
            this.SecondName = n;
            this.age = age;
            this.addToSalary = a;
            this.salary = s;
            this.tax = t;
        }
        public void Info()
        {
            Console.WriteLine();
            Console.Write("Cотрудник агенства " + this.FirstName+" " + this.SecondName + ", возраст: " + this.age + ", зарплата:" + this.salary + ", премия: " + this.addToSalary + ",налог : "+this.tax);
        }
    }
    public class City
    {
        public string Name;
        public string placeOfWork;
        public City(string f, string p)
        {
            this.Name = f;
            this.placeOfWork = p;
        }
        public void Print()
        {
            Console.WriteLine("Имя: "+ this.Name +", место работы: "+  this.placeOfWork);
        }
    }
}
