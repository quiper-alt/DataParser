using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataReaderProject
{
    public class FileOpener
    {
        public static string TextReader(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentException(nameof(file));
            }

            using (var streamReader = new StreamReader(file.FullName))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static DateTime DateParser(FileInfo file)
        {
            var fileName = file.Name.Split('.');
            string dateMask = "yyyyMMdd.HH_mm_ss";
            try
            {
                return DateTime.ParseExact(string.Join(".", fileName.Take(2)), dateMask, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public static OneFile GetFile(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentException(nameof(file));
            }

            string text = TextReader(file);
            var date = DateParser(file);
            var records = TextParsing.ParsText(text);
            return new OneFile() {DateTime = date, Records = records.ToList()};
        }
    }
}