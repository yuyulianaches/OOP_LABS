using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> list = new CollectionType<int>();
                CollectionType<short> list1 = new CollectionType<short>(2);

               // list.Show();              //exception
                list.Add(9);
                //list.Add(0);              //exception
                list.Add(78);
                list.Add(22);
                list.Add(54);
                list.Add(20);
                list.Add(1);
                list.Add(58);
                list.Add(77);
                list.Show();
                list.Pop();
                list.Show();
                list1.Add(0);
                list1.Add(1);
                list1.Add(2);
                list1.Add(3);
                list1.Add(4);
                list1.Add(5);
                list1.Add(6);
                list1.Add(7);
                list1.Show();
                list1.Remove(3);
                list1.Show();

                Car car1 = new Car("BMW", 3346, "red");
                Car car2 = new Car("Nissan", 2511, "yellow");
                CollectionType<Car> cars = new CollectionType<Car>();
                cars.Add(car1);
                cars.Add(car2);
                car1.Info();
                car2.Info();
                cars.Show();

                Console.WriteLine("Исключений не выявленно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                Console.WriteLine("Конец программы.");
            }
            Console.ReadKey();
        }
    }



        //обобщенный интерфейс с операциями добавить, удалить, просмотреть.
        interface IFunction<T> where T : struct
        {
            void Add(T element);
            void Remove(int pos);
            void Show();
        }
        //обобщенный класс

        public class CollectionType<T> : IFunction<T> where T : struct
        {
            public T element;
            public List<T> List { get; set; }
            public int Count => this.List.Count;
            public CollectionType()
            {
                this.List = new List<T>();
                this.element = default(T);
            }
            public CollectionType(T el)
            {
                this.List = new List<T>();
                this.element = el;
            }
            public T Pop()//удаление последнего элемента
            {
                int lastElementIndex = this.List.Count - 1;
                T lastElement = this.List[lastElementIndex];
                this.List.RemoveAt(lastElementIndex);
                return lastElement;
            }
            public void Add(T el)//добавление элемента
            {
                if (el.Equals(0))
                {
                    throw new Exception("Невозможно добавить элемент!");
                }
                List.Add(el);
            }
            public void Show()//вывод списка
            {
                if (List.Count == 0)
                {
                    throw new Exception("Список пуст!");
                }
            Console.WriteLine("Элементы списка: ");
                for (int i = 0; i < List.Count; i++)
                {
                    Console.Write(" " +  List[i]);
                }
            Console.WriteLine();
            }
            public void Remove(int pos)//удаление элемента с позиции
            {
                this.List.RemoveAt(pos);
            }
        public static CollectionType<T> operator +(CollectionType<T> list, T element)
        {
            list.Add(element);
            return list;
        }

        // -- - извлечь элемент из стека
        public static CollectionType<T> operator --(CollectionType<T> list)
        {
            list.Pop();
            return list;
        }
        public static CollectionType<T> operator ++(CollectionType<T> list)
        {
            CollectionType<int> l = new CollectionType<int>();
            if (list is CollectionType<int>)
            {
                l = list as CollectionType<int>;
                l.Add(1);
                list = l as CollectionType<T>;
                return list;
            }
            else
            {
                Console.WriteLine("Ошибка!");
                return null;
            }
        }
    }
    // пользовательский класс, который будет использоваться в качестве параметра обобщения.
    public struct Car
    {
        public string mark;
        public int numb;
        public string color;
        public Car(string mark, int numb, string color)
        {
            this.mark = mark;
            this.numb = numb;
            this.color = color;
        }
        public void Info()
        {
            Console.WriteLine("Cars mark: " + mark + "; number:  " + numb + "; color: " + color + ".");
        }
    }
}



