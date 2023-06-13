using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pracownicy";
            int n = 10; 

            Pracownik[] pracownicy = Pracownik.Generate(n); 

            foreach (Pracownik pracownik in pracownicy)
            {
                Console.WriteLine(pracownik); 
            }

            Console.ReadLine();
        }
    }
}
