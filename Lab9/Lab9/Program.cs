using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Program
    {
 
        static void Main(string[] args)
        {
            User us1 = new User();
           
            us1.Update += DisplayMessage;   //добавляем обработчик для события 
            us1.Info("ПО пользователя 1: Total Commander");
            us1.date = DateTime.Now;
            us1.Message("Добрый день, не забудьте обновить ПО!");


            Console.WriteLine("Введите версию, до которой хотите обновить ПО: ");

            us1.version = Console.ReadLine();
            us1.New(us1.version, us1.date);
            us1.Pass("H32");
            us1.Pass("Pavel1");

            User us2 = new User();

            us2.Update += DisplayMessage;   //добавляем обработчик для события 
            us2.Info("ПО пользователя 2: Adobe Photoshop");
            us2.date = DateTime.Today;

            Console.WriteLine("Введите версию, до которой хотите обновить ПО: ");
            us2.version = Console.ReadLine();
            us2.New(us2.version, us2.date);
            us2.Pass("I_am_User_2");

            Console.WriteLine("Введите название отчета: ");

            Lamb stroke = s => s.Insert(0,"Принято название отчета: "); //присваиваем объекту делегата лямбду
            string doc = Console.ReadLine();
            Console.WriteLine(stroke(doc));

            us1.Working += Increment;
            us1.TimeWorking(us1.Time);
            us1.TimeWorking(us1.Time);
            us1.TimeWorking(us1.Time);
            us1.Working += Decrement;
            us1.TimeWorking(us1.Time);

            Console.WriteLine("Введите строку!");
            string str = Console.ReadLine();


            //Func
            Func<string, string> newstring = Operation.RemoveStr;
            Console.WriteLine(newstring(str));
            newstring = Operation.ReplaсeStr;
            Console.WriteLine(newstring(str));
            newstring = Operation.ToUpperStr;
            Console.WriteLine(newstring(str));
            newstring = Operation.ToLowerStr;
            Console.WriteLine(newstring(str));
            Console.ReadKey();
        }
        private static void DisplayMessage<T>(T message)
        {
            Console.WriteLine(message);
        }
        private static int Increment(int i)
        {
            return ++i;
        }
        private static int Decrement(int i)
        {
            return --i;
        }

    }
    //создаем делегаты
    public delegate void Upgrade(string a);
    public delegate int Work(int a);
    public delegate string Lamb(string a);
    public class User
    { 
        //события
        public event Upgrade Update;
        public event Work Working;
        public string version;
        public object date;
        private int time;
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        public void Info(string s)
        {
            Update?.Invoke($"Версия {s} устарела!");
        }
        public void Message(string s)
        {
            Update?.Invoke($"На вашу почту было доставлено сообщение: {s}");
        }
        public void Pass(string i)
        {
            if (i.Length < 6)
            {
                Update?.Invoke("Введеный пароль должен содержать более 5 символов");
            }
            else Update?.Invoke("Введен верный пароль!");
        }
        public void New(string v, object d)
        {
            
              Update?.Invoke($"Новая версия: {v} обновлена, время: {d}");
           
        }
        public void TimeWorking(int i)
        {
            Time = Working.Invoke(i);
            Console.WriteLine($"Пользователь провел сегодня за компьютером: {Time} часов");
        }


    }
    class  Operation
    {
        public static string ToUpperStr(string str)//все буквы заглавные
        {
            Console.WriteLine("\nСтрока после преобразования в прописные:");
            return str.ToUpper();
        }
        public static string ToLowerStr(string str)//все буквы cтрочные
        {
            Console.WriteLine("\nСтрока после преобразования в строчные:");
            return str.ToLower();
        }
        public static string ReplaсeStr(string str)//удаление пробела
        {
            Console.WriteLine("\nСтрока после удаления пробела:");
            return str.Replace(" ", "");
        }
        public static string RemoveStr(string str)//удаление гласных
        {
            char[] g = { 'а', 'е', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            for (int i = 0; i < str.Length; i++)
            {
                if (g.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            Console.WriteLine("\nСтрока после удаления гласных:");
            return str;
        }
    }

}

