using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Общее число мест в поезде: " + Train.allPlaces);
            Train train1 = new Train(548, "Минск", 14.01, 150, 190, 46);
            train1.Show();
            train1.freePlaces(out int free, train1.Cupe, train1.Platz, train1.Lux);//вызов метода
            
            Train train2 = new Train(43, "Витебск", 19.30, 549, 143, 489);
            train2.Show();
            train2.freePlaces(out free, train2.Cupe, train2.Platz, train2.Lux);//вызов метода
     
            Train train6 = new Train(605, "Брест", 12.15, 49, 210, 54);
            train6.Show();
            train6.freePlaces(out free, train6.Cupe, train6.Platz, train6.Lux);//вызов метода
 
            Train train7 = new Train(27, "Минск", 20.25, 30, 140, 79);
            train7.Show();
            train7.freePlaces(out free, train7.Cupe, train7.Platz, train7.Lux);//вызов метода
        
            Train train3 = new Train();
            train3.Show();
       
            Train train4 = new Train(23, "Минск", 16.30);
            train4.Show2();

            Train train5 = new Train(19, "Гомель", 18.45);
            train5.Show2();
            Train train8 = new Train(19, "Гомель", 18.45);
            train8.Show2();

            Console.WriteLine();
            Console.WriteLine("Количество созданных объектов: " + Train.size);
            int count = 0;
            object[] ListOfTrains = new object[7];
            ListOfTrains[0] = train1;
            ListOfTrains[1] = train2;
            ListOfTrains[2] = train3;
            ListOfTrains[3] = train4;
            ListOfTrains[4] = train5;
            ListOfTrains[5] = train6;
            ListOfTrains[6] = train7;
            Console.WriteLine("_______");
            Console.WriteLine("Сортировка массива объектов по пункту назначения и времени.");
            Console.WriteLine();

            foreach (Train trains in ListOfTrains)
            {
                count++;
                if (trains.Arrive == "Минск") Console.WriteLine("До Минска едет поезд номер " + trains.Num);
            }
            Console.WriteLine("_______");
            foreach (Train trains in ListOfTrains)
            {
                count++;
                if ((trains.Arrive == "Минск")&&(trains.Time >= 15.0)) Console.WriteLine("До Минска после 15:00 едет поезд номер " + trains.Num+". Его отправление в "+trains.Time);
            }
            Console.WriteLine("Эквивалентность поездов:");
            Console.WriteLine(train1.Equals(train2));
            Console.WriteLine(train5.Arrive.Equals(train8.Arrive));
            Console.WriteLine("Xеш коды:");
            Console.WriteLine(train1.GetHashCode());
            Console.WriteLine(train5.GetHashCode());
            Console.WriteLine(train8.GetHashCode());
            Console.WriteLine("Приводим к строке (время и номер поездов):");
            Console.WriteLine(train4.Time.ToString());
            Console.WriteLine(train7.Num.ToString());
            Console.ReadKey();
        }
    }
    public partial class Train//частичный класс partial
    {
        protected int id;
        private string arrive;
        private int numberOfTrain;
        private double time;
        public const int allPlaces = 500;
        private int cupe;//свободно в купе
        private int platz;//свободно в платцкарте
        private int lux;//свободно в люксе
        internal readonly uint trainID;//поле для чтения
        public static int size;

        public int Cupe
        //свободных мест в купе
        {
            get
            {
                return cupe;
            }
            set
            {
                if (value > 150)
                    cupe = 150;
                else if (value < 0)
                    cupe = 0;
                else cupe = value;
            }

        }
        public int Platz
        //свободных мест в платцкарте
        {
            get
            {
                return platz;
            }
            set
            {
                if (value > 250)
                    platz = 250;
                else if (value < 0)
                    platz = 0;
                else platz = value;
            }

        }
        public int Lux
        //свободных люкс-мест
        {
            get
            {
                return lux;
            }
            set
            {
                if (value > 100)
                    lux = 100;
                else if (value < 0)
                    lux = 0;
                else lux = value;
            }

        }
      
        public string Arrive
        {
            get
            {
                return this.arrive;
            }
            set
            {
                this.arrive = value;
            }

        }
        public int Num
        {
            get
            {
                return this.numberOfTrain;
            }
            set
            {
                this.numberOfTrain = value;
            }

        }
        public double Time
        //свободных мест в платцкарте
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


        
        //cтатик
        static Train()
        {
            size = 0;
        }
        //конструктор
        public Train(int numberoftrain, string arrive, double time, int cupe, int platz, int lux) //передаем значения
        {
            size++;
            this.arrive = arrive;
            this.numberOfTrain = numberoftrain;
            this.time = time;
            this.Cupe = cupe;
            this.Platz = platz;
            this.Lux = lux;
            this.trainID = Hash(out int id, arrive, time);
        }
        public Train(int numberoftrain, string arrive, double time)
        {
            size++;
            this.arrive = arrive;
            this.numberOfTrain = numberoftrain;
            this.time = time;
            this.trainID = Hash(out int id, arrive, time);
        }
        public Train()//не передаем
        {
            size++;
            arrive = "Витебск";
            numberOfTrain = 500;
            time = 19.40;
            cupe = 70;
            platz = 100;
            lux = 76;
            this.trainID = Hash(out int id, arrive, time);
        }
        
        //метод вывода общего числа свободных мест в поезде
        public int freePlaces(out int free, int cupe, int platz, int lux)
        {
            free = cupe + platz + lux;
            Console.WriteLine("Общее число свободных мест: " + free);
            return free;
        }
        public void Show()
        {
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("ID: " + trainID);
            Console.WriteLine("Номер поезда:" + numberOfTrain + "\nПункт назначения: " + arrive + "\nВремя отправления: " + time + "\nКоличество свободных мест в купе: " + cupe + "\tКоличество свободных мест в платцкарте: " + platz + "\nКоличество свободных мест в люксе: " + lux);
          
        }
        public void Show2()
        {
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("ID: " + trainID);
            Console.WriteLine("Номер поезда:" + numberOfTrain + "\nПункт назначения: " + arrive + "\nВремя отправления: " + time);
        }
        //вычисление хэша
        public uint Hash(out int id, string arrive, double time)
        {
            Random random = new Random();
            id = random.Next(1,15);
             int key = ((int)time * 13 + arrive.Length) / id * 6;
            uint hash = (uint)key;
            return hash;
        }

    }
  

}

