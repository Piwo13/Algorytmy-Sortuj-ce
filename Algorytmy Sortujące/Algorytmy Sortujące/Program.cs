using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorytmy_Sortujące
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[][] maly = new int[50][];
            int[][] duzy = new int[50][];

            for (int i = 0; i < maly.Length; i++)
            { 
                maly[i] = new int[1000];
                duzy[i] = new int[100000];

                for(int j = 0; j < maly[i].Length; j++)
                {
                    maly[i][j] = rnd.Next(-10000000, 10000000);
                }

                for(int k = 0; k < duzy[i].Length; k++)
                {
                    duzy[i][k] = rnd.Next(-10000000, 10000000);
                }
            }

            List<(string, double,double)> mczas = new List<(string, double,double)>();
            List<(string, double, double)> dczas = new List<(string, double, double)>();
            List<ISort> sortowanie = new List<ISort>();
           
            sortowanie.Add(new Bubble());
            sortowanie.Add(new Quick());
            sortowanie.Add(new Heap());
            sortowanie.Add(new Shell());
            sortowanie.Add(new Counting());
            sortowanie.Add(new Merge());

            foreach(ISort sort in sortowanie)
            {
                double[] srednia = new double[50];

                for (int i = 0; i < maly.Length; i++)
                {
                    
                    int[] kopia = (int[])maly[i].Clone();
                    Stopwatch zegar = Stopwatch.StartNew();
                    sort.Sortuj(kopia);
                    zegar.Stop();
                    srednia[i] = zegar.Elapsed.TotalMilliseconds;
                }
                double avg = srednia.Average();
                double sumakwadratow = srednia.Select(x => (x - avg) * (x - avg)).Sum();
                double sd = Math.Sqrt(sumakwadratow / srednia.Length);
                mczas.Add((sort.Nazwa, avg,sd));


                for (int i = 0; i < duzy.Length; i++)
                {
                    int[] kopia = (int[])duzy[i].Clone();
                    Stopwatch zegar = Stopwatch.StartNew();
                    sort.Sortuj(kopia);
                    zegar.Stop();
                    srednia[i] = zegar.Elapsed.TotalMilliseconds;
                }
                avg = srednia.Average();
                sumakwadratow = srednia.Select(x => (x - avg) * (x - avg)).Sum();
                sd = Math.Sqrt(sumakwadratow / srednia.Length);
                dczas.Add((sort.Nazwa, avg, sd));

                Console.WriteLine($"{sort.Nazwa} ukończone!");
           
            }
            mczas.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            dczas.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            Console.WriteLine("\nWyniki dla małego zestawu: ");
            mczas.ForEach(x => Console.WriteLine((x.Item1 + ":").PadRight(15) + x.Item2 + " ms   Odchylenie standardowe: "+ x.Item3));
            Console.WriteLine("\nWyniki dla dużego zestawu: ");
            dczas.ForEach(x => Console.WriteLine((x.Item1 + ":").PadRight(15) + x.Item2 + "ms   Odchylenie standardowe: " + x.Item3+"ms"));



            Console.ReadKey();
        }
    }
}
