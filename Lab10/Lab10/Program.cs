using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //________ЗАДАНИЕ 1__________ 
            //необобщенная коллекция ArrayList

            ArrayList list = new ArrayList();

            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                list.Add(rand.Next(25));
            }
            string stroke = "BSLU";
            string name = "Yuliana";
            object student = name;
            list.Add(stroke);
            list.Add(student);

            Console.WriteLine("ArrayList: ");

            foreach (object o in list)
            {
                Console.Write(o + "; ");
            }
            Console.WriteLine($"Количество элементов: {list.Count}");
            Console.WriteLine();
            Console.WriteLine("Введите номер элемента, который хотите удалить: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // удаляем элемент
            list.RemoveAt((n - 1));
            foreach (object o in list)
            {
                Console.Write(o + "; ");
            }
            Console.WriteLine();

            Console.WriteLine("Введите элемент, номер которого хотите найти: ");


            string find = Console.ReadLine();

            //// поиск
            bool g = false;
            int k = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (find == list[i].ToString())
                {
                    g = true;
                    k = i + 1;
                }
              
            }
            if (g == true) Console.WriteLine("Этот элемент имеет индекс " + (k));
            else Console.WriteLine("Такого элемента нет!");
            bool con = list.Contains("Yuliana");
            Console.WriteLine("В коллекции содержится элемент Yuliana: "+con);
            //_____________________ЗАДАНИЕ 2______________
            //Реализация обобщенной коллекции SortedList

            SortedList<int, char> generic_list = new SortedList<int, char>();

            // Добавим несколько элементов в коллекию
            generic_list.Add(1, 'a');
            generic_list.Add(2, 'b');
            generic_list.Add(3, 'c');
            generic_list.Add(4, 'd');
            generic_list.Add(5, 'e');
            generic_list.Add(6, 'f');
            generic_list.Add(7, 'g');
            generic_list.Add(8, 'h');
            generic_list.Add(9, 'i');
            generic_list.Add(10, 'j');


            // Коллекция ключей
            ICollection<int> keys = generic_list.Keys;
            // Коллекция значений
            IList<char> listValues = generic_list.Values;

            // Теперь используем ключи, для получения значений
            foreach (int s in keys)
                Console.WriteLine("Ключ: {0}, значение: {1}", s, generic_list[s]);

            //удаление последовательных элементов
            Console.WriteLine("Удалим несколько значений с позиции. Введите начальную позицию и количество значений: ");
            int position = Convert.ToInt32(Console.ReadLine());
            int col = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < col; i++)
            {
                generic_list.RemoveAt(position - 1);
            }
            //Вывод результата

            foreach (int s in keys)
                Console.WriteLine("Ключ: {0}, значение: {1}", s, generic_list[s]);


            //Проверка наличия ключа
            Console.WriteLine("Проверим наличие ключа, введите ключ: ");
            bool isFound1 = generic_list.ContainsKey(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(isFound1 + "\nЕще раз: ");
            bool isFound2 = generic_list.ContainsKey(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(isFound2 + "\n");

            //Проверка наличия ключа
            Console.WriteLine("Проверим наличие значения, введите cимвол: ");
            char h = (char)Console.Read();
            bool isFound3 = generic_list.ContainsValue(h);
            Console.WriteLine(isFound3 + "\nЕще раз: ");
            char h2 = (char)Console.Read();
            bool isFound4 = generic_list.ContainsValue(h2);
            Console.WriteLine(isFound4 + "\n");

            //Создание обобщенной коллекции List
            //перенос значений
            Console.WriteLine("Перенесем значения коллекции один в коллекцию 2: ");
            List<char> alphabet = new List<char>();
            for (int i = 0; i < generic_list.Count; i++)
            {

                alphabet.Add(listValues[i]);

                Console.Write(alphabet[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Введите элемент, который хотите найти: ");


            char c = (char)Console.Read();
            bool fl = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (c == alphabet[i])
                {
                    fl = true;
                }

            }
            if (fl == true) Console.WriteLine("Этот элемент есть в коллекции!");
            else Console.WriteLine("Такого элемента нет!");



            //_______________ЗАДАНИЕ 3______________________________
            SortedList<int, Train> tr = new SortedList<int, Train>();
            Train t1 = new Train("Locomotiv", 3676);
            Train t2 = new Train("Tommi", 7234);
            Train t3 = new Train("BZHD", 4630);
            Train t4 = new Train("Sapsan", 8310);
            tr.Add(1, t1);
            tr.Add(2, t2);
            tr.Add(3, t3);
            tr.Add(4, t4);
            Console.WriteLine("Выведем новую коллекцию пользовательского класса: ");
            foreach (Train t in tr.Values)
            {
                Console.WriteLine("Поезд: {0}, номер {1})", t.Name, t.Number);
            }

            List<Train> list_trains = new List<Train>();

            foreach (int a in tr.Keys)
                list_trains.Add(tr[a]);
            Console.WriteLine("Перенесем значения во вторую коллекцию: ");

            foreach (Train a in list_trains)
                Console.WriteLine(a.ToString());




            //_______________Задание 4_______
            ObservableCollection<Train> val = new ObservableCollection<Train>();
            //Класс ObservableCollection определяет событие CollectionChanged, подписавшись на которое, мы можем обработать любые изменения коллекции
            val.CollectionChanged += TrainChange;
            val.Add(t1);
            val.Add(t2);
            val.Add(t3);
            val.Add(t4);
            val.Remove(t3);
            Console.ReadKey();

        }
        private static void TrainChange(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен {e.NewItems[0].ToString()}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удалён {e.OldItems[0].ToString()}");
                    break;
            }
        }

    }

       
  
}


    
    class Train : IComparable, IComparer<Train>
    {
        private string name;
        private int number;

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 0)
                    number = value;
                else
                    number = 0;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int CompareTo(Object a)
        {
            Train b = (Train)a;
            if (this.Number < b.Number)
                return -1;
            else if (this.Number > b.Number)
                return 1;
            else
                return 0;
        }
        int IComparer<Train>.Compare(Train x, Train y)
        {
            return string.Compare(x.Name, y.Name);
        }

        public override string ToString()
        {
            return "Название поезда: " + Name + ", номер: " + Number;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() - 10;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public Train(string str, int p)
        {
            Name = str;
            Number = p;
        }

    }










