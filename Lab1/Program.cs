using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_______Задание 1______________________________");
          
        
            //Задание 1: Типы данных
            //a)типы данных и их инициализация
            //Числа
            //целочисленные:
            int i = -20; //от -2147483648 до 2147483647
            uint ui = 21; //от 0 до 4294967295
            long l = 1000;
            ulong ul = 10000000;
            byte b = 223;//от 0 до 225
            sbyte sb = -128; //от-128 до 127
            short sh = -200; //от -32768 до 32767
            ushort ush = 3333; //от 0 до 65535
            //с плавающей точкой:
            float f = 15.1f; //7 знаков
            double d = 1888.4; //15 знаков
            //Символ и строка
            char ch = 'c';
            string str = "New line";
            //Логический
            bool bl = true;
            Console.WriteLine($"Основные типы данных и их примеры:\n int {i}, uint {ui}, long {l}, ulong {ul}, byte {b}, sbyte {sb},\n short {sh}, ushort {ush}, float {f}, double {d}, char {ch}, string {str}, bool {bl}");
            //б) Явное и неявное приведение
            //5 операций неявного преобразования:

            int i2 = b;
            long l2 = i;
            double d2 = f;
            uint ui2 = ush;
            float f2 = sb;
            Console.WriteLine($"\nЯвное преобразование типов данных: byte в int: int {i2} = {b} (b), float в double: {d2} = {f} (f), и т.д.");
            //5 операций явного преобразования:
            byte b3 = (byte)i;
            float f3 = (float)i;
            double d3 = (double)i;
            int i3 = (int)l;
            short sh3 = (short)ush;
            Console.WriteLine($"\nНеявное преобразование типов данных: int в float: float {f3} = (float)i ({i}), и т.д.");

            //3) упаковка и распаковка значимых типов
            //Преобразование типа значений к ссылочному типу сопровождается неявной операцией упаковки (boxing)
            //Преобразование ссылочного типа к типу значений вызывает операцию распаковки (unboxing) 
            // — извлечение из упаковки копии типа значения и помещение её в стек.

            object obj = i;
            int newI = (int)obj;
            Console.WriteLine($"\nУпаковка значимых типов: object obj = i(int); \n Распаковка - обратное действие. int newI = (int)obj;");

            //4) неявно типизированная переменная
            var v1 = 100;
            var v2 = "Hello"; 
            Console.WriteLine($"\nНеявно типизорованная переменная var. var v1 = 100, var v2 = \"Hello\"...");

            //5) Nullable переменная
            Console.WriteLine($"Значение nullable-переменной. Проверка значения переменной с п-ю .HasValue. Value 1 = 50, Value 2 = null. ");
            int? value1 = 50;
            if (value1.HasValue)//если значение >0 (true)
                Console.WriteLine("Значение 1 " + value1.Value + " > 0");
            else
                Console.WriteLine("Значение 1 " + value1.Value + "= 0");
            int? value2 = null;
            if (value2.HasValue)//если значение >0 (true)
                Console.WriteLine(value2.Value);
            else
                Console.WriteLine("Значение 2 " + value2 +" = 0");
            //Задание 2: строки
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_______Задание 2______________________________");

            //a) строковые литералы
            Console.Write("Первая лабораторная по С#. ");
            Console.WriteLine("Вывод строковых литералов.");

            string str1 = "Hello ";
            string str2 = "World";
            string str3 = "World";
            Console.WriteLine($"Заданные слова: {str1}, {str2} и {str3}");
            Console.WriteLine("Сравним:");
            if (str1 == str2)
                Console.WriteLine("Первое и второе слово одинаковы.");
            else
                Console.WriteLine("Первое и второе слово разные.");
            if (str2 == str3)
                Console.WriteLine("Второе и третье слово одинаковы.");
            else
                Console.WriteLine("Второе и третье слово разные.");
            Console.WriteLine("Сложим первое и второе слово:");
            Console.WriteLine(str1 + str2);
            string copy = String.Copy(str1 + str2);
            Console.WriteLine("Скопируем сочетание слов: " + copy);
            //выделим строку другим цветом
            Console.WriteLine("Выделим следующую строку:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(copy);
            Console.ForegroundColor = ConsoleColor.Yellow;
            //вставка подстроки в строку
            Console.WriteLine("Вставим слово:");
            string word = "wonderful ";
            copy = copy.Insert(6, word);
            Console.WriteLine(copy);
            //Разобьем строку на слова
            string[] words = copy.Split(' ');
            for (int a = 0; a < words.Length; a++)
            {
                Console.Write("Слово " + (a + 1) + "- " + words[a] + "; ");
            }
            Console.WriteLine();
            Console.Write("Вырежем слово из текста: ");
            copy = copy.Remove(0, 6);
            Console.WriteLine(copy);
            //Создание пустой и null-строки
            string empty = "";
            string nullLine = null;
            Console.WriteLine($"Проверим эквивалентность пустой строки \"\" и строки null: ");
            if (empty.Equals(nullLine))
                Console.Write("Строки эквивалентны");
            else
                Console.Write("Строки не эквивалентны");
            //StringBuilder и его методы:

            StringBuilder newLine = new StringBuilder("\nСоздаем строку с помощью StringBuilder");
            Console.WriteLine(newLine);
            //добавим в конец строки
            newLine.Append(";)");
            //вставим слово с заданную позицию
            newLine.Insert(8, " новую ");
            Console.Write(newLine);

            //заменим слово
            newLine.Replace("Создаем", "Изменяем");
            Console.WriteLine(newLine);

            //удалим символы
            newLine.Remove(0, 33);
            Console.WriteLine($"Удалим несколько символов... И наш итог: {newLine}.");


            //Задание 3: массивы
            //1) Создание массива в 2-мерном виде:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("_______Задание 3______________________________");
            Console.WriteLine("Создадим двухмерный массив: ");
            Random rand = new Random();
            int[,] array = new int[4, 4];
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    array[x, y] = rand.Next(0, 100);
                    Console.Write(array[x, y] + " ");
                }
                Console.WriteLine();
            }
            string[] strArray = new String[5];
            strArray[0] = "Кот";
            strArray[1] = "Лошадь";
            strArray[2] = "Собака";
            strArray[3] = "Лиса";
            strArray[4] = "Волк";
            for (int x = 0; x < strArray.Length; x++)
            {
                Console.Write($" {strArray[x]} ");
            }
            Console.WriteLine($"Количество элементов массива: {strArray.Length} ");
            Console.WriteLine("Какой элемент вы хотите поменять?");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("На какой элемент? (введите строку)?");
            string newStr = Convert.ToString(Console.ReadLine());
            strArray[num - 1] = newStr;
            Console.WriteLine("Полученный массив:");

            for (int x = 0; x < strArray.Length; x++)
            {
                Console.Write($" {strArray[x]} ");
            }


            //Ступенчатый массив
            Console.WriteLine();
            Console.WriteLine("Введите числа массива:");
            double[][] stup = new double[3][];
            stup[0] = new double[2];
            stup[1] = new double[3];
            stup[2] = new double[4];
            for (i = 0; i < 2; i++)
            {
                stup[0][i] = Convert.ToDouble(Console.ReadLine());
            }
            for (i = 0; i < 3; i++)
            {
                stup[1][i] = Convert.ToDouble(Console.ReadLine());
            }
            for (i = 0; i < 4; i++)
            {
                stup[2][i] = Convert.ToDouble(Console.ReadLine());
            }

            for (i = 0; i < 2; i++)
            {
                Console.Write(stup[0][i] + " ");
                
            }
                Console.WriteLine();
            for (i = 0; i < 3; i++)
            {
                Console.Write(stup[1][i] + " ");
            }
                Console.WriteLine();
            {
                for (i = 0; i < 4; i++)
                    Console.Write(stup[2][i] + " ");
                Console.WriteLine();
            }
         
            //Неявно типизированная переменная для массива и строки
            Console.WriteLine("\n\nНеявно типизированная переменная для строки: ");
            var varStr = new[] { "this", "is", "stroke", "array" };
            for (int x = 0; x < varStr.Length; x++)
            {
                Console.Write(varStr[x] + " ");
            }
            var varArr = new[]
            {
                 new[]{56, 56, 23, 14, 8},
                 new[]{45, 24, 1, 65, 42}
            };
            Console.WriteLine("\nНеявно типизированная переременная для массива: ");
            for (int y = 0; y < varArr.Length; y++)
            {
                for (int  z= 0; z < 5; z++)
                {
                    Console.Write(varArr[y][z] + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("_______Задание 4______________________________");

            //Задание 4: кортежи

            (int, string, char, string, ulong) tuple1 = (600, "It's", 'C', "-Sharp",318527);
            (int, string, char, string, ulong) tuple2 = ( 7,"I love",'U', "BSTU", 139);
            (int, string, char, string, ulong) tuple3 = ( 600, "It's", 'C',  "-Sharp", 318527);


            Console.WriteLine("Кортеж 1: " + tuple1.ToString());
            Console.WriteLine("Кортеж 2: " + tuple2.ToString());
            Console.WriteLine("Кортеж 3: " + tuple3.ToString());
            Console.WriteLine($"Вывод 1, 4 и 5 элементов первого кортежа: {tuple1.Item1}, {tuple1.Item4}, {tuple1.Item5} ");
          
            //Распаковка кортежа
            int first = tuple1.Item1;
            string second = tuple1.Item2;
            char thrith = tuple1.Item3;
            string fourth = tuple1.Item4;
            ulong fivth = tuple1.Item5;
            Console.WriteLine("Вывод элементов первого кортежа после распаковки: " + first + ", " + second + ", " + thrith + ", " + fourth + ", " + fivth);
            //Сравнение 2 кортежей
            var Compare1 = tuple1.CompareTo(tuple2);
            Console.WriteLine("Сравнение первого и второго кортежей дало результат:  " + Compare1);
            var Compare2 = tuple1.CompareTo(tuple3);
            Console.WriteLine("Сравнение первого и третьего кортежей дало результат: " + Compare2);

            //Задание 5: локальная функция
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("_______Задание 5______________________________");


            var foo = GetValues();
            Console.WriteLine(foo);

            Console.ReadKey();
        }
           private static (int, int, int, char) GetValues()
        {
            Console.WriteLine("Исходные данные кортежа. Массив:");

            int[] arr = new int[6] { 80, -20, 0, 1, 10, -15 };
            for(int i=0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}+\t");
            }
            string strr = "BelSTU";
            Console.WriteLine("Cтрока: " + strr);
            int max = arr.Max();
            int min = arr.Min();
            int sum = arr.Sum();
            char el = strr[0];
            var result = (max, min, sum, el);
            Console.WriteLine("Вывод максимального, минимального элемента, их суммы и первого элемента строки: ");
            return result;
            Console.ReadKey();
            Console.ResetColor();
        }

    }
}


