using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Task_2.DB;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Query();
            }
            catch (SqlException)
            {
                TestData();
                Query();
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void TestData()
        {
            using (var context = new DBContext())
            {
                List<Book> books = new List<Book>();
                for (int i = 1; i <= 10; i++)
                {
                    books.Add(new Book("Книга" + i));
                }
                List<Book> b0 = new List<Book>();
                b0.Add(books[books.Count / 2]);
                List<Autor> autors = new List<Autor>();
                autors.Add(new Autor("Рокосовский К.К.",Autor.BaseAutor()));
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
                    count++;
                    if (count == 3)
                    {
                        count = 0;
                        b3.Add(books[i]);
                    }
                }
                autors.Add(new Autor("Малиновский Р. Я.", autors.Last(), b1));
                autors.Add(new Autor("Конев И. С.", autors.Last(), b2));
                autors.Add(new Autor("Жуков Г. К.", autors.Last(), b3));
                context.Autors.AddRange(autors);
                context.SaveChanges();
            }
        }

        public static void Query()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["DBConnection"];
            SqlConnection connection = new SqlConnection(settings.ConnectionString);
            string commandtest = "SELECT * FROM Autor";
            connection.Open();

            // посылаем запрос comand к БД ...результат в dr
            SqlCommand command = new SqlCommand(commandtest, connection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            command = new SqlCommand("SELECT NameBook, COUNT(*) AS Collaborators FROM Book GROUP BY NameBook", connection);
            reader = command.ExecuteReader();
            Console.WriteLine("\t{0,-15} | {1,15}","Название книги", "Количество со-авторов");
            while (reader.Read())
            {
                Console.WriteLine("\t{0,-10} {1,15}", reader["NameBook"].ToString(), reader["Collaborators"]);
            }
            reader.Close();
            connection.Close();
        }
    }
}
