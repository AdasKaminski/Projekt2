using System.Numerics;

namespace ConsoleApplication2
{

    class Program
    {
        private static ulong Licznik;
        private static bool Wynik;
        static void Main(string[] args)

        {

            System.Console.WriteLine("NR;        Czas;         Złożoność");
            BigInteger[] Tablica = new BigInteger[] { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };//tabela zawierająca wartości z góry podane


            for (int i = 0; i < Tablica.Length; i++)
            {
                var czas = new System.Diagnostics.Stopwatch();
                czas.Start();//czas start

                Pierwszabezinstrumentacji(Tablica[i]);//funkcja bez instrumentacji
                czas.Stop();// czas stop
                ulong czasroznica = (ulong)czas.ElapsedTicks; // obliczanie czasu w tikach procesora

                Wynik = Pierwszazinstrumentacja(Tablica[i]);

                System.Console.WriteLine((Tablica[i]) + ";" + czas.ElapsedTicks + ";" + Licznik);

            }



        }

        private static bool Pierwszabezinstrumentacji(BigInteger Num)// funckja bez instumentacji
        {
            if (Num < 2) { return false; }
            else if (Num < 4) { return true; }
            else if (Num % 2 == 0) { return false; }
            else
                for (BigInteger u = 3; u * u <= Num; u += 2)
                { if (Num % u == 0) { return false; } }
            return true;
        }
        private static bool Pierwszazinstrumentacja(BigInteger Num) // funkcja z instrumentacją
        {
            Licznik = 1;
            if (Num < 2)
            { return false; }
            else if (Num < 4)
            { return true; }
            else if (Num % 2 == 0)
            { return false; }
            else
            {
                for (BigInteger u = 3; u * u <= Num; u += 2)
                {

                    Licznik++; // liczy ilośc operacji
                    if (Num % u == 0)

                    {
                        ;

                        return false;

                    }
                }
                return true;

            }
        }
    }
}
