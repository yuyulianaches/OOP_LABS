using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14
{
    [Serializable]
    public class Train 
    {
        public string name;
        public string color;
        public int number;
        [NonSerialized]
        public int speed;
 
        public Train(string name,string c, int n, int s)
        {
            this.name = name;
            this.color = c;
            this.number = n;
            this.speed = s;
        }
    
        public override string ToString()
        {
            return base.ToString() + "Переопределение toString() выполнено.";
        }
        public virtual void ShowTrain(int n, string col)
        {
            Console.WriteLine($"Поезд с номером {n} имеет {col} цвет!");
        }
    }
    [Serializable]
    public class Car 
    {
        public string mark;
        public Car() { }
    }
    // бесплодный класс, от которого невозможно наследование
    [Serializable]
    sealed class Carriage : Train
    {
        int numberOfCarriage;
    
        public Carriage(string name, string color, int number, int speed) : base(name,color, number, speed)
        {
            this.name = name;
            this.color = color;
            this.numberOfCarriage = number;
            this.speed = speed;
        }     
        public override int GetHashCode()
        {
            return base.GetHashCode() + numberOfCarriage;
        }
        public override string ToString()
        {
            return base.ToString() + " Это вагон" + ", вагон поезда";
        }
    }    
 }