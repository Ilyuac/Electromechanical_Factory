using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите количество элемнтов массива:");
                int Count = Convert.ToInt32(Console.ReadLine());
                uint[] Mass = new uint[Count];

                Random random = new Random();
                for (int i = 0; i < Count; i++)
                {
                    Mass[i] = (uint)random.Next(1, int.MaxValue);
                }
                uint MAX = 0;
                bool fl = false;
                for (int i = 0; i < Count; i++)
                {
                    if (i % 2 != 0 && Mass[i] % 2 == 0)
                    {
                        fl = true;
                        Mass[i] = Mass[i] * 2;
                    }
                    if (i % 2 == 0 && Mass[i] % 2 != 0)
                    {
                        if (MAX < Mass[i])
                        {
                            MAX = Mass[i];
                        }
                    }
                }

                Console.WriteLine("\nМассив:");
                foreach (var item in Mass)
                {
                    Console.Write(item.ToString() + " ");
                }
                if (MAX == 0)
                {
                    Console.WriteLine("\nВ массиве не оказалось ни одного нечетного элемента стоящего на четном месте.");
                }
                else
                {
                    Console.WriteLine("\n\nМаксимальное среди нечетных элементов на четных позициях:");
                    Console.WriteLine(MAX);
                }
                if (fl)
                {
                    Console.WriteLine("\nВ массиве не оказалось ни одного четного элемента стоящего на нечетном месте.");
                    Console.WriteLine("\nМаксимальный элемент в масиве:");
                    Console.WriteLine(Mass.Max());
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
