using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Program
{
    class Pracownik
    {
        string imie;
        string nazwisko;
        string stanowisko;
        int stazPracy;
        double pensja;

        public string Imie { get { return imie; } }
        public string Nazwisko { get { return nazwisko; } }

        public string Stanowisko { get { return stanowisko; } }

        public int StazPracy { get { return stazPracy; } }

        public double Pensja { get { return pensja; } }


        public Pracownik()
        {
            imie = "Jan";
            nazwisko = "Kowalski";
            stanowisko = "CEO";
            stazPracy = 3;
            pensja = 5000;
        }

        public Pracownik(Pracownik osoba)
        {
            imie = osoba.Imie;
            nazwisko = osoba.Nazwisko;
            stanowisko = osoba.Stanowisko;
            stazPracy = osoba.StazPracy;
            pensja = osoba.Pensja;
        }

        public Pracownik(string imie, string nazwisko, string stanowisko, int stazPracy)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.stanowisko = stanowisko;
            this.stazPracy = stazPracy;

            pensja = 3600 + stazPracy * 150;

            if (stanowisko == "manager") pensja += 500;
            else if (stanowisko == "kierownik") pensja += 1000;

        }

        public void ZwiekszStaz()
        {
            stazPracy++;
            pensja += 150;
        }

        public bool ZwiekszPenjsa(double wzrost)
        {
            if (pensja + pensja * wzrost > 10000)
            {
                return false;
            }
            else
            {
                pensja += pensja * wzrost;
                return true;
            }
        }

        public static Pracownik[] Generate(int n)
        {
            Random rand = new Random();
            Pracownik[] workerArray = new Pracownik[n];

            string[] names = { "Ola", "Ala", "Ania", "Jan", "Adam" };
            List<string> titles = new List<string>()
            {
                "mlodszy specjalista",
                "starszy specjalista",
                "ksiegowy",
                "manager",
                "kierowinik"
            };

            int name_index;
            string name;
            int last_name_len;
            string last_name;
            int title_index;
            string title;
            int workingYears;

            int kierownik_count = 0;
            int manager_count = 0;

            for (int i = 0; i < workerArray.Length; i++)
            {
                // imie
                name_index = rand.Next(0, names.Length);
                name = names[name_index];

                // nazwisko
                last_name_len = rand.Next(3, 16);
                last_name = LastNameGenerator(last_name_len, rand);

                // tytuł
                title_index = rand.Next(0, titles.Count);
                title = titles[title_index];

                if (title == "kierownik") kierownik_count++;
                else if (title == "manager") manager_count++;

                if (kierownik_count >= 3) titles.Remove("kierownik");
                else if (manager_count >= 10) titles.Remove("manager");

                // stażPracy
                workingYears = rand.Next(0, 26);

                workerArray[i] = new Pracownik(name, last_name, title, workingYears);

            }

            return workerArray;
        }

        static string LastNameGenerator(int len, Random rand)
        {
            string name = Convert.ToString((char)rand.Next('A', 'Z' + 1));

            for (int i = 1; i < len; i++)
            {
                name += Convert.ToString((char)rand.Next('a', 'z' + 1));
            }

            return name;
        }

        public static void Ranking(Pracownik[] company, int key)
        {
            List<Pracownik> sortedList;

            // nazwisko
            if (key == 0)
            {
                sortedList = company.OrderBy(p => p.Nazwisko).ToList();
            }
            // tytuł
            else if (key == 1)
            {
                sortedList = company.OrderBy(p => p.Stanowisko).ToList();
            }
            // pensja
            else if (key == 2)
            {
                sortedList = company.OrderBy(p => p.Pensja).ToList();
            }
            else
            {
                return;
            }

            for (int i = 0; i < sortedList.Count; i++)
            {
                company[i] = sortedList[i];
            }


        }


        public override string ToString()
        {
            return $"{Imie} {Nazwisko} {Stanowisko} {StazPracy}";
        }

    }
}
