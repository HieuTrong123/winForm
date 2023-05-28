using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2115207_DinhTrongHieu_Lab5
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int YearPublished { get; set; }
        private static void SaveToXmlFile(List<Book> books)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, books, null);
                writer.Close();
            }
        }
    }
}
