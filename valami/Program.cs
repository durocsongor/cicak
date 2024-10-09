using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valami
{
    enum Szine { Zold, Rozsaszin, Feher, Lila, Fekete}
    enum Neme { Fiu, Lany}
    class Cica
    {
        public int ID { get; set; }
        public string Neve { get; set; }
        public Szine Szine { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public Neme Neme{ get; set; }
        public int Suly { get; set; }
        public int Kor => DateTime.Now.Year - SzuletesiDatum.Year;

        public override string ToString()
        {
            return $"{ID,-5}{Neve,-20} {Szine,-10}{SzuletesiDatum.ToString("yyy.MM.dd"), -15}{Neme,-10}{Suly,-5}{Kor, -5}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>()
            {
                new Cica()
                {
                    ID=1,
                    Neme=Neme.Fiu,
                    Neve="Megatron",
                    Suly=10,
                    Szine=Szine.Fekete,
                    SzuletesiDatum=new DateTime(2018,08,13),
                },

                new Cica()
                {
                    ID=2,
                    Neme=Neme.Lany,
                    Neve="Pizsama",
                    Suly=4,
                    Szine=Szine.Rozsaszin,
                    SzuletesiDatum=new DateTime(2022,12,22),
                },

                new Cica()
                {
                    ID=3,
                    Neme=Neme.Fiu,
                    Neve="Sanyi",
                    Suly=5,
                    Szine=Szine.Feher,
                    SzuletesiDatum=new DateTime(2017,02,17),
                },

                new Cica()
                {
                    ID=4,
                    Neme=Neme.Lany,
                    Neve="Józsika",
                    Suly=2,
                    Szine=Szine.Zold,
                    SzuletesiDatum=new DateTime(2011,01,23),
                }
            };

            Cica elsoCica = cicak.First();
            Console.WriteLine(elsoCica);

            Cica utolsoCica = cicak.Last();
            Console.WriteLine(utolsoCica);

            int osszSuly = cicak.Sum(x => x.Suly);
            Console.WriteLine($"Össz súly: {osszSuly} kg");

            double atlagKor = cicak.Average(x => x.Kor);
            Console.WriteLine($"Átlag életkor: {atlagKor:0.00}");

            int lanyDb = cicak.Count(x => x.Neme == Neme.Lany);
            Console.WriteLine($"Lány cicák: {lanyDb}");

            int legveznabbMacsek = cicak.Min(x => x.Suly);
            Console.WriteLine(legveznabbMacsek);

            cicak.Where(x => x.Kor > 3).ToList().ForEach(x => Console.WriteLine(x.Neve));

            cicak.Where(x => x.Szine == Szine.Fekete).ToList().ForEach(x => Console.WriteLine(x.Neve));

            Console.ReadKey();
        }
    }
}
