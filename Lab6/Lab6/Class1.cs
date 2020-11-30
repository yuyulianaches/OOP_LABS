using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lab6
{
    public abstract class Base
    {
        public struct Info//структура
        {
            private int speed;
            public int Speed {
                get { return speed; }
                set
                {
                    if (value < 0)
                        throw new SpeedException("Cкорость не может быть отрицательной! Элемент не добавлен!");
                    else speed = value;
                }
            }


            public int rashod;

        }
        public Info info = new Info();
    }


    partial class Vehicle//транспортное средство
    {
        public override bool Equals(object obj)
        {
            Vehicle vehicle = (Vehicle)obj;
            return ((this.marka == vehicle.marka) && (this.numb == vehicle.numb));
        }

        public override int GetHashCode()
        {
            return this.marka.GetHashCode() + this.numb.GetHashCode();
        }

        public override string ToString()
        {
            return this.marka + " " + this.numb;
        }
    }

   
    public class Agency//контейнер
    {
        public Base[] elems;
        public int count = 0;
        public int size;


        public Agency()
        {
            this.size = 100;
            this.elems = new Base[100];
        }

        public Agency(int c)
        {
            this.size = c;
            this.elems = new Base[c];
        }

        public bool isFull()
        {
            return (count == size);
        }

        public bool isEmpty()
        {
            return (count == 0);
        }

        public void Add(Base el)
        {
            if (isFull())
                return;
            elems[count++] = el;
        }

        public void Del(Base el)

        {
            int num = 0;
            if (isEmpty())
                return;
            for (int i = 0; i < count; i++)
            {
                if (elems[i] == el)
                    num = i;
            }
            for (int i = num; i < count; i++)
            {
                elems[i] = elems[i + 1];
            }
            count--;
        }

        public void Show()
        {
            Console.WriteLine("Массив элементов \n __________");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Транспорт: "+elems[i].ToString()+". Скорость: "+elems[i].info.Speed + ". Расход топлива 1л/100км: "+elems[i].info.rashod);
               
            }
            Console.WriteLine("__________");
            Console.WriteLine();
            Console.ReadKey();
        }
    }

 
    public static class controller//статический со статическими методами,чтобы мы смогли вызывать их ранее созданными объектами 
    {
        public static void Sort(Agency agency)
        {
          
            int temp;
          
            for (int i = 0; i < agency.count-1; i++)
            {
                for (int j = i+1; j < agency.count; j++)
                {
                    if (agency.elems[i].info.Speed > agency.elems[j].info.Speed)
                    {
                        temp = agency.elems[i].info.Speed;
                        agency.elems[i].info.Speed = agency.elems[j].info.Speed;
                        agency.elems[j].info.Speed = temp;

                    }
                }
            }
          
            Console.WriteLine("Cортировка по скорости прошла успешно! ");

            for (int i = 0; i < agency.count; i++)
            {
                Console.WriteLine((i+1)+ ") Cкорость = "+ agency.elems[i].info.Speed);
            }
           
        }

        public static void minrashod(Agency agency)
        {
            Base elem;
            elem = agency.elems[0];
            int min = 99999;
            for (int i = 0; i < agency.count; i++)
            {
                if (agency.elems[i].info.rashod < min)
                {
                    min = agency.elems[i].info.rashod;
                    elem = agency.elems[i];

                }

            }
            Console.Write(elem);
            Console.WriteLine(" Минимальный расход: " + min);
            Console.ReadKey();
        }

        
    }
}
