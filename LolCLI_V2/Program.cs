


namespace LolCLI_V2
{
    public class Program
    {
        public static List<Hos> hos = new List<Hos>();
        static void Main(string[] args)
        {
            Beolvasas();
            Kiir();
            Feladat3();
            Feladat5();
        }

        private static void Feladat5()
        {
            Hos legerosebb = hos.MaxBy(t => t.HpErtek(15))!;
            double maxHp = legerosebb.HpErtek(15);

            Console.WriteLine($"15-ös szinten a legmagasabb HP-val rendelkező hős: {legerosebb.Name}, HP értéke: {maxHp}");
        }

        private static void Feladat3()
        {
            Hos? keresett;

            do
            {
                Console.WriteLine("Kérem adja meg a hős nevét! ");

                string kod = Console.ReadLine()!;
                keresett = hos.FirstOrDefault(t => t.Name == kod);

                if (keresett == null)
                {
                    Console.WriteLine("Nincs ilyen hős a listában!");
                }
            }
            while (keresett == null);

            Console.WriteLine($"Hős neve: {keresett.Name}, adatai: HP: {keresett.HP}; Kategória: {keresett.Category}");
        }

        private static void Kiir()
        {
            Console.WriteLine($"Összesen {hos.Count} hős van a listában.");

        }

        public static void Beolvasas()
        {
            StreamReader sr = new StreamReader("champions2017_V2.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                Hos hosok = new Hos(sr.ReadLine());
                hos.Add(hosok);
            }
        }
    }
}
