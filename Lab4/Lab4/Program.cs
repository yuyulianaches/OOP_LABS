using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//1) Создать заданный в варианте класс. Определить в классе необходимые
//методы, конструкторы, индексаторы и заданные перегруженные
//операции. Написать программу тестирования, в которой проверяется
//использование перегруженных операций.
//2) Добавьте в свой класс вложенный объект Owner, который содержит Id,
//имя и организацию создателя. Проинициализируйте его
//3) Добавьте в свой класс вложенный класс Date (дата создания).
//Проинициализируйте
//4) Создайте статический класс StatisticOperation, содержащий 3 метода для
//работы с вашим классом (по варианту п.1): сумма, разница между
//максимальным и минимальным, подсчет количества элементов.
//5) Добавьте к классу StatisticOperation методы расширения для типа string
//и вашего типа из задания№1. См. задание по вариантам. 
//Класс - список List. Дополнительно перегрузить следующие
//операции: + - добавить элемент в конец (list+item); -- -
//удалить элемент из конца (типа list--); != - проверка на
//неравенство.
//Методы расширения:
//1) Подсчет количества слов.
//2) Проверка на нулевые элементы вписке
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new List.Owner("Юлиана",03108, "БГТУ");
            
            DateTime date = DateTime.Now;
            Console.WriteLine($"Владелец: {owner.name}. Персональный ID: {owner.id}. Университет:  {owner.org} Дата и время создания: {date}.");


            var elem = new List();
           elem.Add(1);
           elem.Add(2);
           elem.Add(4);
           elem.Add(9);
            Console.WriteLine("Список 1: ");
           elem.ListOut();
           
           Console.WriteLine();


            var elem2 = new List();
           elem2.Add("IS");
           elem2.Add("ETON");
           elem2.Add("GO");
           elem2.Add("DOHE");
           elem2.Add("FOATOL");
            Console.WriteLine("Список 2: ");
            elem2.ListOut();

           elem2.AddEnd("O");
           elem2.ListOut();
           StatisticOperation.MaxElement(elem2);

            var elem3 = new List();
           elem3.Add(5);
           elem3.Add(0);
           elem3.Add(0);
           elem3.Add(20);
           elem3.Add(25);
           Console.WriteLine();
            Console.WriteLine("Список 3: ");
            elem3.ListOut();
           elem3.DeleteEnd();
           elem3.ListOut();
            StatisticOperation.NullElement(elem3);

            Console.WriteLine("\nПроверка на равенство списков 1 и 3:");
            StatisticOperation.CompareList(elem3, elem);
   



            var elem4 = new List();
            elem4.Add(1);
            elem4.Add(2);
            elem4.Add(4);
            elem4.Add(9);
            Console.WriteLine("Список 4: ");
            elem4.ListOut();

            Console.WriteLine("\nПроверка на равенство списков 1 и 4:");
            StatisticOperation.CompareList(elem, elem4);

            Console.WriteLine();

      

                Console.ReadKey();
           }

    }
    public class List
    {
        public class Elem
        {
            public string Value { get; set; }
            public Elem Next { get; set; }

        }
        public Elem Head { get; set; }
        public Elem Last { get; set; }
        private Elem Current { get; set; }
        private int Size { get; set; }

        public class Owner
        {
            public string name { private set; get; }
            public string org { private set; get; }
            public int id { private set; get; }

            public Owner(string name, int id, string org)
            {
                this.name = name;
                this.id = id;
                this.org = org;
            }

            public class DateTime
            {

            }
        }
        //заполнение списка
        public void Add(int value)
        {
            Size++;
            var elem = new Elem() { Value = value.ToString() };
            if (Head == null)
            {
                Head = elem;
            }
            else
            {
                Current.Next = elem;
            }
            Current = elem;
        }
        public void Add(string value)
        {
            Size++;
            var elem = new Elem() { Value = value.ToString() };
            if (Head == null)
            {
                Head = elem;
            }
            else
            {
                Current.Next = elem;
            }
            Current = elem;
        }

        //Удаление последнего элемента списка 3
        public void DeleteEnd()
        {

            Elem Current = Head;

            while (Current.Next != null)
            {

                if (Current.Next.Next == null)
                {
                    Current.Next = null;
                    Size--;
                }
                else Current = Current.Next;

            }
            Console.WriteLine("Последний элемент удален!");
        }
        //Добавление элемента в конец списка 2
        public void AddEnd(string add)
        {
            Elem Current = Head;
            Size++;
            while (Current != null)
            {
                if (Current.Next == null)
                {
                    Current.Next = new Elem();
                    Current.Next.Value = add.ToString();
                    Current.Next.Next = null;
                    break;
                }
                else Current = Current.Next;

            }
            Console.WriteLine("Добавлен элемент в конец!");
        }

        public void ListOut()
        {
            Elem Current = Head;
            while (Current != null)
            {
                Console.Write($"{Current.Value} -> ");
                Current = Current.Next;
            }
            Console.Write("null\n");
        }
      
    }
    public static class StatisticOperation
 
    //1) Подсчет количества слов.
    //2) Проверка на нулевые элементы вписке
    {

        public static string MaxElement(List list)
        {
            List.Elem Current = list.Head;
            int count = 0;
            int max = 0;
            string str = "";
            while (Current != null)
            {
                count++;
                if (Current.Value.Length > max)
                {
                    max = Current.Value.Length;
                    str = Current.Value;
                    Current = Current.Next;
                }
                else Current = Current.Next;
            }
            Console.WriteLine("Слово максимальной длины (" + str + ") имеет " + max + " букв. Всего слов в списке: " + count);
            return str;
        }
        public static int NullElement(this List ints)
        {
            int count = 0;
            List.Elem Current = ints.Head;
            while (Current != null)
            {

                if (Current.Value.ToString() == "0")
                {
                    count++;
                    Current = Current.Next;
                }
                else Current = Current.Next;
            }
            Console.WriteLine("В данном списке содержится " + count + " нулевых элементов.");
            return count;
        }
    
        public static bool CompareList(List list1, List list2)
            {
            bool flag = false;
            //bool lenght = false;
            int times = 0;
            int count = 0;
            List.Elem Current1 = list1.Head;
            List.Elem Current2 = list2.Head;
            while ((Current1!= null)||(Current2 != null))
            {
                times++;
                
                if (Current1.Value.ToString() == Current2.Value.ToString())
                {
                    count++;
                    Current1 = Current1.Next;
                    Current2 = Current2.Next;
                }
                else
                {
                    Current1 = Current1.Next;
                    Current2 = Current2.Next;
                }
                //if ((Current1.Next == null) && (Current2.Next == null))
                //{
                //    lenght = true;
                //}
                           
            }
            if (count == times) flag = true;
           // if ((count == times) && (lenght)) flag = true;

            if (!flag) Console.WriteLine("Cписки не равны.");
            else
            {
                Console.WriteLine("Cписки равны.");
            }

            return flag;
        }


    }
}
