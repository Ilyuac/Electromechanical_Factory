using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2.DB;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestDB()
        {
            //TestData();
            Task_2.Query query = new Task_2.Query();
        }

        private void TestData()
        {
            using (var context = new DBContext())
            {
                List<Book> books = new List<Book>();
                for (int i = 1; i <= 10; i++)
                {
                    books.Add(new Book("Книга" + i));
                }
                context.Books.AddRange(books);
                List<Autor> autors = new List<Autor>();
                autors.Add(new Autor("Рокосовский К.К."));
                autors.Add(new Autor("Шапошников Б. М.", autors.Last(), books));
                var b1 = new List<Book>();
                var b2 = new List<Book>();
                var b3 = new List<Book>();
                int count = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (i % 2 == 0)
                    {
                        b1.Add(books[i]);
                    }
                    else
                    {
                        b2.Add(books[i]);
                    }
                    if (count == 3)
                    {
                        count = 0;
                        b3.Add(books[i]);
                    }
                    count++;
                }
                autors.Add(new Autor("Малиновский Р. Я.", autors.Last(), b1));
                autors.Add(new Autor("Конев И. С.", autors.Last(), b2));
                autors.Add(new Autor("Жуков Г. К.", autors.Last(), b3));
                context.Autors.AddRange(autors);
                context.SaveChanges();
            }
        }
    }
}

