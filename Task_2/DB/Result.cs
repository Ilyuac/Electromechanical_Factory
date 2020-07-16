using System;

namespace Task_2.DB
{
    public class Result
    {
        public string NameBook { get; }
        public int Collaborators { get; }
        public Result(string NameBook, int Collaborators)
        {
            try
            {
                if (Collaborators > 0)
                { this.Collaborators = Collaborators; }
                else
                {
                    throw new Exception("Параметр Collaborators не может быть меньше 0.");
                }
                if (!string.IsNullOrWhiteSpace(NameBook))
                    this.NameBook = NameBook;
                else
                {
                    throw new Exception("Имя книги не может быть null.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!\n"+ex.Message);
            }
        }
    }
}
