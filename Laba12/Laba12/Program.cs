using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
namespace Laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train("red", 25351);
            Reflection.ToFile(typeof(Train));
            Reflection.ToFile(typeof(Vehicle));
            Reflection.ToFile(typeof(Carriage));
            Reflection.RandomMethod("Laba12.Train", "System.String");
            Train tr = new Train("red", 4502);

            Console.WriteLine();
            Console.WriteLine("_____Получение параметров и вызов метода:____");
            Reflection.InsaneMethod(tr, "Numb");
            Console.ReadKey();
        }
    }

    public static class Reflection
    {
           public static void FileWriter(StreamWriter f, string str)
            {
                f.WriteLine(str);
            }
            public static void ToFile(Type t)
            {
                string path = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\Laba12\date.txt";
                StreamWriter info = new StreamWriter(path, true, System.Text.Encoding.Default);
                bool haveSealed = t.IsSealed, 
                haveInterface = t.IsInterface,
                haveClass = t.IsClass, 
                haveArray = t.IsArray,
                haveAbstract = t.IsAbstract,
                haveEnum = t.IsEnum;
                FileWriter(info, $"____________Общие сведения__________: ");
                FileWriter(info, $"FullName:   [{t.FullName}]");
                FileWriter(info, $"Name:   [{t.Name}]");
                FileWriter(info, $"BaseType:   [{t.BaseType}]");
                FileWriter(info, $"IsSealed:  [{haveSealed}]");
                FileWriter(info, $"IsInterface:   [{haveInterface}]");
                FileWriter(info, $"IsClass:   [{haveClass}]");
                FileWriter(info, $"IsAbstract:    [{haveArray}]");
                FileWriter(info, $"IsEnum:    [{haveEnum}]");
                FileWriter(info, $"IsArray:   [{haveAbstract}]");
                MethodInfo[] m = t.GetMethods();
                PropertyInfo[] p = t.GetProperties();
                ConstructorInfo[] c = t.GetConstructors();
                FieldInfo[] f = t.GetFields();
                Type[] i = t.GetInterfaces();
                FileWriter(info, "Методы:");
                foreach (var s in m)
                FileWriter(info, $"    [{s.ToString()}]");
                FileWriter(info, "Свойства:");
                foreach (var b in p)
                FileWriter(info, $"   [{b.ToString()}]");
                FileWriter(info, "Конструкторы:");
                foreach (var s in c)
                FileWriter(info, $"   [{s.ToString()}]");
                FileWriter(info, "Поля:");
                foreach (var s in f)
                FileWriter(info, $"   [{s.ToString()}]");
                FileWriter(info, "Интерфейсы:");
                foreach (var s in i)
                FileWriter(info, $"   [{s.ToString()}]");
              
                info.Close();

            }
        public static void RandomMethod(string name, string type)
        {
            foreach (MethodInfo method in Type.GetType(name).GetMethods())
            {
                if (method.ReturnType == Type.GetType(type))
                    Console.WriteLine(method);
            }
        }

        public static void InsaneMethod(Train obj, string mth)
        {
            FileStream f = new FileStream(@"C:\Users\unnamed\Documents\Универ\ООП\LABS\Laba12\message.txt", FileMode.Open);
            StreamReader reader = new StreamReader(f);
            object[] stroke = { Convert.ToInt32(reader.ReadLine()) };
            Type t = typeof(Train);
            MethodInfo metod = t.GetMethod(mth);
            object m = metod.Invoke(obj, stroke);
            Console.WriteLine(m);
        }
    }
    //ЛАБОРАТОРНАЯ №5
    public abstract class Vehicle //Абстрактный класс "Транспортное средство"
    {
        protected float Speed; //наследуемое значение скорости
        public abstract void Move(); //абстрактный метод "движение"
        internal bool PartOfVehicle; // методы для всех производных абстрактного класса

        public float GetCurrentSpeed()
        {
            return Speed;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Train : Vehicle
    {
        public string color;
        public int n;
        public Train(string color, int n)
        {
            this.color = color;
            this.n = n;
        }

        public override void Move()//переопределяем метод "движение" класса-родителя
        {
            Console.WriteLine("Поезд движется.");
        }
        public virtual void TrainsCarriage() // виртуальный метод, так как потом мы можем его переопределять как вагоны поезда, но пока он просто поезд
        {
            Console.WriteLine("Это некий поезд.");
        }
        public override string ToString()
        {
            return base.ToString() + "Переопределение toString() выполнено.";
        }
        public virtual void ShowTrain(int n, string col)
        {
            Console.WriteLine($"Поезд с номером {n} имеет {col} цвет!");
        }
        public void Numb(int n)
        {
            int nn = n * n;
            Console.WriteLine("Метод реализован, получен квадрат числа " + n + ": " + nn);
        }
        public void ToConsole(string str)
        {
            Console.WriteLine("Из файла был получен message: " + str);
        }


    }
    interface Istop // интерфейс, в котором есть метод "остановиться", если мы пропишем этот интерфейс какому-нибудь классу, этот класс выполнит это

    {
        void Stopping();
    }

    // бесплодный класс, от которого невозможно наследование

    sealed class Carriage : Train, Istop
    {
        int numberOfCarriage;

        public Carriage(string color, int n) : base(color, n)
        {
            this.color = color;
            this.PartOfVehicle = true;
            this.numberOfCarriage = n;
        }


        public override void TrainsCarriage() // сейчас этот метод уже не виртуальый
        {
            Console.WriteLine("Поезд имеет несколько вагонов.");
        }


        public void Stopping() // реализация интерфейса
        {
            Console.WriteLine("Транспорт остановился");
        }

    }
}
