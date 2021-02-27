using System;
using System.IO;

namespace DataReaderProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var file = FileOpener.GetFile(new FileInfo(@"C:\Users\kupts\Downloads\20210105.12_15_10.data.txt"));
            Console.WriteLine(file.GetProductsCount());
            Console.WriteLine(file.GetProductsPrice());
        }
    }
}