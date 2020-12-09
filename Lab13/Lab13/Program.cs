using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;


namespace _13lab
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter file = CYYLog.CreateWriter("cyylogfile.txt");
            CYYDiskInfo.InfoDisk(file); Console.WriteLine();
            CYYFileInfo.FullDirection(file, "cyylogfile.txt");
            CYYDirInfo.CreationTime(file, "..");
            CYYDirInfo.FileCount(file, "..");
            CYYDirInfo.DirCount(file, "..");
            CYYDirInfo.ParentsCount(file, ".."); Console.WriteLine();
            CYYFileManager.FileSubdir(file, "C:/");
            CYYFileManager.Part1(file);
            CYYFileManager.Part2(file);
            CYYFileManager.Part3(file);
            file.Close();

            Console.ReadKey();
        }
    }

    //Класс XXXLog: работа с текстовым файлом,
    //в который записываются все действия пользователя и
    //соответственно методами записи в текстовый файл, чтения, поиска нужной информации.

    class CYYLog

    {
        //метод создания объекта класса StreamWriter для записи в текстовый файл
        public static StreamWriter CreateWriter(string str)
        {
            StreamWriter writer = new StreamWriter(str);
            return writer;
        }
        //метод создания объекта класса StreamWriter для чтения с текстового файла
        public static StreamReader CreateReader(string str)
        {
            StreamReader reader = new StreamReader(str);
            return reader;
        }
        //метод записи даты и информации
        public static void CYYWriter(StreamWriter writer, string info)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            writer.WriteLine(date + ":\t" + info);
        }
        //Проверка на наличие заданной информации в файле
        public static void CYYSearcher(StreamReader reader, string info)
        {
            string text = reader.ReadToEnd();
            if (text.Contains(info))
            {
                Console.WriteLine("Файл содержит данную информацию");
            }
            else
            {
                Console.WriteLine("Файл не содержит данную информацию");
            }
        }
    }

    //Класс XXXDiskInfo(): вывод информации о свободном месте на диске, файловой системе.
    //Для каждого существующего диска - имя, объем, доступный объем, метка тома.
    class CYYDiskInfo
    {
        //Для представления диска в пространстве имен System.IO;
        //возвращает имена всех логических дисков компьютера
        private static DriveInfo[] Drives = DriveInfo.GetDrives();
        public static void InfoDisk(StreamWriter writer)
        {
            CYYLog.CYYWriter(writer, "Вывод информации о каждом диске");
            for (int i = 0; i < Drives.Length; i++)
            {
                if (Drives[i].IsReady)
                {
                    Console.WriteLine($"Общий объем диска: {Drives[i].TotalSize / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"Объем свободного места: {Drives[i].TotalFreeSpace / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"Корневой каталог:{Drives[i].RootDirectory}");
                    Console.WriteLine($"Метка тома:{Drives[i].VolumeLabel}");
                    Console.WriteLine($"Тип диска:{Drives[i].DriveType}\n");
                }
            }
        }
    }
    //XXXFileInfo - информация о конкретном файле
    //Полный путь
    //Размер, расширение, имя
    //Время создания

    static class CYYFileInfo
    {

        public static void FullDirection(StreamWriter writer, string f)
        {
            CYYLog.CYYWriter(writer, "Полный путь");
            FileInfo file = new FileInfo(f);
            if (file.Exists)
            {
                Console.WriteLine("Полный путь: " + file.DirectoryName);
                Console.WriteLine("\nПолный путь файла: " + file.FullName);
                Console.WriteLine("Размер файла: " + file.Length + "байт");
                Console.WriteLine("Расширение файла: " + file.Extension);
                Console.WriteLine("Имя файла: " + file.Name);
                Console.WriteLine("Дата создания файла: " + file.CreationTimeUtc);
                Console.WriteLine("Дата создания файла: " + file.CreationTime);
            }
            else Console.WriteLine("Файл не найден!");
        }


    }
    //XXXDirInfo: вывод информации о директории
    //Количество файлов
    //Время создания
    //Количество поддиректориев
    //Список родительских директориев
    class CYYDirInfo
    {
        public static void FileCount(StreamWriter writer, string s)
        {
            CYYLog.CYYWriter(writer, "Вывод информации о количестве файлов в директории");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists)
            {
                FileInfo[] file = dirinfo.GetFiles();
                Console.WriteLine("Количестве файлов: " + file.Length);
            }
            else Console.WriteLine("Директория не найдена!");
        }
        public static void CreationTime(StreamWriter writer, string s)
        {
            CYYLog.CYYWriter(writer, "Вывод информации о выводе создания директории");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists)
                Console.WriteLine("Время создания: " + dirinfo.CreationTime);
            else Console.WriteLine("Директория не найдена!");
        }
        public static void DirCount(StreamWriter writer, string s)
        {
            CYYLog.CYYWriter(writer, "Количество поддиректориев: ");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists && dirinfo.Extension == "")
            {
                DirectoryInfo[] d = dirinfo.GetDirectories();
                Console.WriteLine("Количество поддиректориев: " + d.Length);
            }
            else Console.WriteLine("Директория не найдена!");
        }
        public static void ParentsCount(StreamWriter writer, string s)//Список родительских директориев
        {
            CYYLog.CYYWriter(writer, "Список родительских директориев: ");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists)
            {
                Console.WriteLine("Список родительских директориев: " + dirinfo.Root);
            }
            else Console.WriteLine("Директория не найдена!");
        }
    }
    //Прочитать список файлов и папок заданного диска.Создать
    //директорий XXXInspect, создать текстовый файл
    //xxxdirinfo.txt и сохранить туда информацию. Создать
    //копию файла и переименовать его. Удалить
    //первоначальный файл.
    //b.Создать еще один директорий XXXFiles.Скопировать в
    //него все файлы с заданным расширением из заданного
    //пользователем директория. Переместить XXXFiles в
    //XXXInspect. 
    //c.Сделайте архив из файлов директория XXXFiles.
    //Разархивируйте его в другой директорий.
    public static class CYYFileManager
    {

        public static void FileSubdir(StreamWriter writer, string name = null)
        {
            CYYLog.CYYWriter(writer, "Вывод инфомации о вложенных папках и файлах диска " + name);
            if (name != null)
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(name);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(name);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public static void Part1(StreamWriter writer)
        {
            CYYLog.CYYWriter(writer, "Создание папки,файла,заполнение,копирование,удаления");
            string path = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("CYYInspect"); //создает каталог по указанному пути path
            if (!directory.Exists) // проверяет, существует ли каталог
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            FileInfo file = new FileInfo(directory.FullName + "CYYInspect\\CYYdirinfo.txt");
            using (FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate))
            {
                string text = "Hello World";
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fs.Write(array, 0, array.Length);
                fs.Close();
            }
            File.Copy(file.FullName, file.DirectoryName + "\\test.txt", true);
            file.CopyTo("newfile.txt", true);
            file.Delete();
        }
        public static void Part2(StreamWriter writer)
        {
            CYYLog.CYYWriter(writer, "Создание папки,перемещение файлов с заданым расширением из одной папки в другую");
            string path = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\Lab13";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("CYYFiles");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            DirectoryInfo source = new DirectoryInfo(@"C:\Users\unnamed\Documents\Универ\ООП\LABS");
            DirectoryInfo destin = new DirectoryInfo(@"C:\Users\unnamed\Documents\Универ\ООП\LABS\Lab13\CYYFiles\");
            DirectoryInfo dest = new DirectoryInfo(@"C:\Users\unnamed\Documents\Универ\ООП\LABS\CYYInspect");
            foreach (FileInfo item in source.GetFiles().Where(x => x.Extension == ".txt").ToList())
            {
                item.CopyTo(destin + item.Name, true);
            }

            if (!dest.Exists)
            {
                destin.MoveTo(dest.FullName);
            }
        }

        public static void Part3(StreamWriter writer)
        {
            CYYLog.CYYWriter(writer, "Архивирование папки");

            string startPath1 = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\Lab13\CYYFiles";
            string zipPath1 = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\Lab13\CYYFiles.zip";
            string startPath = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\CYYInspect";
            string zipPath = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\CYYInspect.zip";
            string extractPath = @"C:\Users\unnamed\Documents\Универ\ООП\LABS\CYYInspect_2";
            DirectoryInfo zipFile = new DirectoryInfo(@"C:\Users\unnamed\Documents\Универ\ООП\LABS\Lab13\YYInspect.zip");

            if (!zipFile.Exists) { 
            ZipFile.CreateFromDirectory(startPath, zipPath);
                CYYLog.CYYWriter(writer, "Папка CYYInspect архивирована в файл CYYInspect.zip");
                Console.WriteLine($"Папка CYYInspect архивирована в файл CYYInspect.zip");
            }
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            CYYLog.CYYWriter(writer, "Файл CYYInspect.zip распакован в папку CYYInspect");
            Console.WriteLine($"Файл CYYInspect.zip распакован в папку CYYInspect");

            ZipFile.CreateFromDirectory(startPath1, zipPath1);
            CYYLog.CYYWriter(writer, "Папка CYYFiles архивирована в файл CYYFiles.zip");
            Console.WriteLine($"Папка CYYFiles архивирована в файл CYYFiles.zip");

            DirectoryInfo source = new DirectoryInfo(@"C:\Users\unnamed\Documents\Универ\ООП\LABS");
; 
        }
    }
}