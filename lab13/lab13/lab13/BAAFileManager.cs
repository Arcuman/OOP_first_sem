﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab13
{
    internal static class BAAFileManager
    {
        private static ZipArchive zip;
        public static void FileSubdir(string name = null)
        {
            BAALog.WriteMessage("Вывод инфомации о вложенных папках и файлах диска: " + name);
            if (name != null)
            {
                Console.WriteLine("Подкаталоги:");
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
        public static void CreateA()
        {
            BAALog.WriteMessage("Создание папки,файла,заполнение,копирование,удаления");
            string path = @"D:\\БГТУ 2 курс\\OOP\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("BAAInspect");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            FileInfo file = new FileInfo(directory.FullName + "BAAInspect\\baadirinfo.txt");
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
        public static void CreateB()
        {
            BAALog.WriteMessage("Создание папки,перемещение файлов с заданым расширение из одной папки в другую");
            string path = @"D:\\БГТУ 2 курс\\OOP\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("BAAFiles");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            DirectoryInfo source = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\лекции");
            DirectoryInfo destin = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAFiles\\");
            DirectoryInfo destin1 = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect\\BAAFiles");
            foreach (FileInfo item in source.GetFiles().Where(x => x.Extension == ".txt").ToList())
            {
                item.CopyTo(destin + item.Name, true);
            }
            if (!destin1.Exists)
            {
                destin.MoveTo(destin1.FullName);
            }
        }
        //public static void Ziping(string what)
        //{
        //        bufdirectory = new DirectoryInfo(what);
        //        ZipFile.CreateFromDirectory(bufdirectory.FullName, bufdirectory.FullName + ".zip");
        //        zip = new ZipArchive(File.Open(bufdirectory.FullName + ".zip", FileMode.Open));
        //}
        //public static void UnZiping(string where)
        //{
        //        bufdirectory = new DirectoryInfo(where);
        //        foreach (ZipArchiveEntry x in zip.Entries)
        //            x.ExtractToFile(bufdirectory.FullName + '\\' + x.Name);
            
        //}
        public static void CreateC()
            {
            BAALog.WriteMessage("Архивирование папки");
            DirectoryInfo bufdirectory = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect\\BAAFiles");
            if (!File.Exists(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect\\BAAFiles.zip"))
            {
                ZipFile.CreateFromDirectory(bufdirectory.FullName, bufdirectory.FullName + ".zip");
            }
                using (ZipArchive zip = new ZipArchive(File.Open(bufdirectory.FullName + ".zip", FileMode.Open)))
                {
                    DirectoryInfo bufdirectory1 = new DirectoryInfo(@"D:\\БГТУ 2 курс\\OOP\\BAAInspect");
                    foreach (ZipArchiveEntry x in zip.Entries)
                        x.ExtractToFile(bufdirectory1.FullName + '\\' + x.Name,true);
                }
        }
    }
}
