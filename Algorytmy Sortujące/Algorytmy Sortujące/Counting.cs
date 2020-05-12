using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Sortujące
{
    class Counting : ISort
    {
        public string Nazwa { get; } = "Counting";

        public void Sortuj(int[] tabela)
        {
            int max = tabela.Max();
            int min = tabela.Min();
            int[] licznik = new int[max - min + 1];

            for (int i = 0; i < tabela.Length; i++)
                licznik[tabela[i] - min]++;

            for (int i = 1; i < licznik.Length; i++)
                licznik[i] += licznik[i - 1];

            int[] kopia = (int[])tabela.Clone();

            for (int i = tabela.Length - 1; i >= 0; i--)
                tabela[--licznik[kopia[i] - min]] = kopia[i];

        }
    }
}
