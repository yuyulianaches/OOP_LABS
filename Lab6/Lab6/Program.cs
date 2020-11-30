using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab6
{
    interface IDrove
    {
        string Driwing();
    }

    interface IMove
    {
        string ToString();
    }

    partial class Vehicle : Base, IMove
    {
        public string marka;

        private int numb;
        public int Numb
        {
            get { return numb; }
            set
            {
                if (value > 9999)
                    throw new CarException("Ошибка!", value); 
                else numb = value;
            }
        }

     

        public Vehicle(string marka, int numb, int speed, int rashod)
        {
            this.marka = marka;
            this.Numb = numb;
            info.Speed = speed;
            info.rashod = rashod;
        }
       
    }

    class Cars : Vehicle, IMove
    {
        public int speed, rashod;
        public string colorOfCar { get; set; }
 
        public Cars(string marka, int numb, string colorOfCar, int speed, int rashod) : base(marka, numb, speed, rashod)
        {
            this.colorOfCar = colorOfCar;
            this.speed = speed;
            this.rashod = rashod;
        }


        public override string ToString()
        {
            return base.ToString() + " " + this.colorOfCar;
        }
        public void ShowCars(string marka, int numb, string colorOfCar, int speed)
        {
            Console.WriteLine("Марка {0}, номер {1}, цвет {2}, скорость  {3}", marka, numb, colorOfCar, speed);
        }


    }

    abstract class Lorry : Cars, IMove
    {
        public int size{ get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.size;
        }

     

        public Lorry(string marka, int numb, string colorOfCar, int size, int speed, int rashod) : base(marka, numb, colorOfCar, speed, rashod)
        {
            this.size = size;
        }

        public abstract string Driwing();
    }

    sealed class Autos : Cars, IMove
    {
        public int Size { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Size;
        }

     

        public Autos(string marka, int numb, string colorOfCar, int Size,  int speed, int rashod) : base(marka, numb, colorOfCar,  speed, rashod)
        {
            this.Size = Size;
        }
    }

    class Trains : Vehicle, IMove
    {
        public string Carriage { get; set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Carriage;
        }


        public Trains(string marka, int numb, string carri, int speed, int rashod) : base(marka, numb, speed, rashod)
        {
            Carriage = carri;
        }
       
        public void Firma(int numb, int speed)
        {
            Console.WriteLine("Поезд: {0}, скорость: {1}", (firma)numb, speed);
        }
        enum firma
        {
            Lokomotiv = 1,
            Express,
            Peugeot,
            Tommi
        }
        
    }



    class Print
    {
        public static void IAmPrinting(IMove obj)
        {
            Console.WriteLine(obj.ToString());
            Console.ReadKey();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle("Honda", 6435, 250, 15);
            Vehicle vehicle2 = new Vehicle("Honday", 6111,290, 18);
            Vehicle vehicle3 = new Vehicle("Fiat", 2225, 300, 25);
            Cars auto3 = new Cars("AUDI", 1111, "зеленая", 290, 5);
            Console.WriteLine("Выведем отдельные объекты: ");
            Cars auto2 = new Cars("VOLVO", 3376, "красная", 180, 15);

            auto2.ShowCars(auto2.marka, auto2.Numb, auto2.colorOfCar, auto2.speed);
            auto3.ShowCars(auto3.marka, auto3.Numb, auto3.colorOfCar, auto3.speed);
            Console.WriteLine("Выведем массив с добавленными в него элементами: ");
            Agency agency = new Agency(10);
            agency.Add(vehicle);
            agency.Add(vehicle2);
            agency.Add(vehicle3);

            try
            {
                Vehicle vehicle4= new Vehicle("AUDI", 464653, 220, 12);
                Console.WriteLine("Исключений не вызвано!");
            }
            catch (CarException ex)
            { 
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка!");
            }
            finally
            {
                Console.WriteLine("Блок выполнился");
            }
            
            agency.Add(auto2);
            agency.Add(auto3);
            agency.Show();
            agency.Add(new Cars("BMW", 3525, "красная", 380, 14));
            agency.Add(new Trains("Renoult", 7621, "желтая", 225, 10));
            agency.Add(new Vehicle("Citroen", 5435, 320, 20));
            Trains tr1 = new Trains("BZHD", 150, "6 вагонов", 70, 60);
            Trains tr2 = new Trains("BZHD", 100, "15 вагонов", 30, 40);
            agency.Show();
            tr1.Firma(1, tr1.Numb);
            tr2.Firma(3, tr2.Numb);
            //______________________________________________
            try
            {
                agency.Add(new Vehicle("Citroen", 5435, -320, 20));
            }
            catch (CarException ex)
            {

                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }
            catch
            {
                Console.WriteLine("Некорректное значение!!");
            }
            finally
            {
                Console.WriteLine("Блок выполнился успешно!");
            }
            try
            {
                auto3.info.Speed = -32;
            }
            catch (SpeedException ex)
            {

                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Некорректное значение: {ex.Value}");
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка!");
            }
            finally
            {
                Console.WriteLine("Элемент не изменен!");
            }

            try
            {

                int x = 15;
                int y = x / 0;  // DivideByZeroException
                Console.WriteLine($"Результат: {y}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Возникло исключение DivideByZeroException");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Арифметическая ошибка!");
            }
            //InvalidCastException: генерируется при попытке произвести недопустимые преобразования типов
            Console.ReadKey();
            try
            {
                object obj = "Новый объект!";
                int num = (int)obj;
                Console.WriteLine($"Результат: {num}");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Возникло исключение InvalidCastException! Неверное преобразование типов!");
            }
            //NullReferenceException: генерируется при попытке обращения к объекту, который равен null(то есть по сути неопределен)
            Console.ReadKey();
            try
            {

                string foo = null;
                foo.ToLower();            
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Возникло исключение NullReferenceException!");
            }
            controller.Sort(agency);
            controller.minrashod(agency);
            Console.ReadKey();


        }
    }
}



