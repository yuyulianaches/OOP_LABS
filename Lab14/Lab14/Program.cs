using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
////using System.Text.Json;


namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Train train = new Train("Tomas","red", 3429, 100);
            Train train1 = new Train("Volvo", "yellow", 6365, 100);
            Train train2 = new Train("Mitsubishi", "green", 5433, 130);
            Train train3 = new Train("Poezhd", "white", 1000, 150);

            Console.WriteLine("Объект создан");


            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("train.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, train);
                Console.WriteLine("Объект сериализован");
            }


            // десериализация из файла 
            using (FileStream fs = new FileStream("train.txt", FileMode.OpenOrCreate))
            {
                Train newTrain = (Train)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован с помощью BinaryFormatter: ");
                Console.WriteLine($"Наименование поезда: {newTrain.name} --- Цвет:{newTrain.color} --- Номер: {newTrain.number}");
            }
            //ARRAY

            Train[] trains = new Train[] { train1, train2, train3 };
            BinaryFormatter formatter4 = new BinaryFormatter();

            using (FileStream fs = new FileStream("trains.txt", FileMode.OpenOrCreate))
            {
                formatter4.Serialize(fs, trains);
                Console.WriteLine("Объекты сериализованы");
            }
            using (FileStream fs = new FileStream("trains.txt", FileMode.OpenOrCreate))
            {
                Train[] deserilizePeople = (Train[])formatter4.Deserialize(fs);
                foreach (Train t in deserilizePeople)
                {
                    Console.WriteLine($"Наименование поезда: {t.name} --- Номер: {t.number}---Цвет: {t.color}");
                }
            }

                //*********************JSON********************
            Car car1 = new Car() { mark = "Nissan" };
            Car car2 = new Car() { mark = "Lada" };
            Car car3 = new Car() { mark = "Citroen" };
            Car car4 = new Car() { mark = "Porsche" };

            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            cars.Add(car4);
            string json = JsonConvert.SerializeObject(cars);
            Console.WriteLine("Объект сериализован");
            Car[] js = JsonConvert.DeserializeObject<Car[]>(json);
            Console.WriteLine("Объекты десериализован:");
            foreach (Car c in js)
            {
                Console.WriteLine($"Марка машины: {c.mark}");
            }

            //*********************SOAP********************
            // создаем объект SoapFormatter
            Carriage carriage = new Carriage("Vagon_1", "blue", 252, 20);
            Carriage carriage1 = new Carriage("Vagon_2", "yellow", 322, 201);
            Carriage carriage2 = new Carriage("Vagon_3", "green", 634, 401);
            Carriage carriage3 = new Carriage("Vagon_4", "black", 413, 752);
            Carriage carriage4 = new Carriage("Vagon_5", "blue", 764, 230);

            Carriage[] carrs = new Carriage[] { carriage1, carriage2, carriage3, carriage4 };
           
            SoapFormatter formatter2 = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("carriage.soap", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, carriage);

                Console.WriteLine("Объект сериализован");
            }
            SoapFormatter formatter5 = new SoapFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("carriages.soap", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, carrs);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream("carriage.soap", FileMode.OpenOrCreate))
            {
                Carriage newCarriage = (Carriage)formatter2.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Номер вагона: {0} --- Цвет:: {1}", newCarriage.number, newCarriage.color);
            }
            using (FileStream fs = new FileStream("carriages.soap", FileMode.OpenOrCreate))
            {
                Carriage[] newCarrs = (Carriage[])formatter5.Deserialize(fs);
                Console.WriteLine("Объекты десериализован");
                foreach(Carriage c in newCarrs)
                {
                    Console.WriteLine($"Наименование вагона: {c.name}--- Цвет вагона: {c.color} --- Номер вагона: {c.number}");

                }
            }

            Car car = new Car() { mark = "AUDI"};
            Car[] cars2 = new Car[] { car1, car2, car3, car4 };
            // передаем в конструктор тип класса
            XmlSerializer formatter3 = new XmlSerializer(typeof(Car));
            XmlSerializer formatter6 = new XmlSerializer(typeof(Car[]));


            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("car.xml", FileMode.OpenOrCreate))
            {
                formatter3.Serialize(fs, car);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("cars.xml", FileMode.OpenOrCreate))
            {
                formatter6.Serialize(fs, cars2);
                Console.WriteLine("Объект сериализован");
            }
            // десериализация
            using (FileStream fs = new FileStream("car.xml", FileMode.OpenOrCreate))
            {
                Car newCar = (Car)formatter3.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Марка машины: : {newCar.mark}");
            }
            using (FileStream fs = new FileStream("cars.xml", FileMode.OpenOrCreate))
            {
                Car[] newCars = (Car[])formatter6.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                foreach(Car c in newCars)
                Console.WriteLine($"Марка машины: : {c.mark}");
            }
            ////
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("myDoc.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            XmlNodeList childnodes1 = xRoot.SelectNodes("student");
            foreach (XmlNode n in childnodes1)
                Console.WriteLine(n.SelectSingleNode("@name").Value);

            XmlNode childnode2 = xRoot.SelectSingleNode("student[age='18']");
            if (childnode2 != null)
                Console.WriteLine(childnode2.OuterXml);

            //*********************************************

            XDocument newDoc = new XDocument();
            //создаем корневой элемент
            XElement cats = new XElement("cats");

            XElement cat = new XElement("cats");
            XAttribute catName = new XAttribute("name", "Sam");
            XElement catColor = new XElement("color", "black");
            XElement catAge = new XElement("age", "5");
            cat.Add(catName);
            cat.Add(catColor);
            cat.Add(catAge);
      
            XElement cat1 = new XElement("cats");
            XAttribute cat1Name = new XAttribute("name", "Charls");
            XElement cat1Color = new XElement("color", "gray");
            XElement cat1Age = new XElement("age", "1");
            cat1.Add(cat1Name);
            cat1.Add(cat1Color);
            cat1.Add(cat1Age);

            XElement cat2 = new XElement("cats");
            XAttribute cat2Name = new XAttribute("name", "Mars");
            XElement cat2Color = new XElement("color", "white");
            XElement cat2Age = new XElement("age", "4");
            cat2.Add(cat2Name);
            cat2.Add(cat2Color);
            cat2.Add(cat2Age);

            // добавляем в корневой элемент
            cats.Add(cat);
            cats.Add(cat1);
            cats.Add(cat2);
            // добавляем корневой элемент в документ
            newDoc.Add(cats);
            //сохраняем документ
            newDoc.Save("cats.xml");


            XmlDocument xDoc1 = new XmlDocument();
            xDoc1.Load("cats.xml");
            XmlElement xRoot1 = xDoc1.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childn = xRoot1.SelectNodes("*");
            foreach (XmlNode n in childn)
                Console.WriteLine(n.OuterXml);

            XmlNodeList childn1 = xRoot1.SelectNodes("cat");
            foreach (XmlNode n in childn1)
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            Console.ReadLine();
        }
    }
}
