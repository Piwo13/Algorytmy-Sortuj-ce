using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Sortujące
{
    class Merge:ISort
    {
        public string Nazwa { get; } = "Merge";

        public void Sortuj(int[] tabela)
        {
            Sortuj(tabela, 0, tabela.Length - 1);
        }

        private void Sortuj(int[] tabela, int lewy,int prawy)
        {
            if (lewy < prawy)
            {
                int srodek = (lewy + prawy) / 2;

                Sortuj(tabela, lewy, srodek);
                Sortuj(tabela, srodek + 1, prawy);

                Scalenie(tabela, lewy, srodek, prawy);
            }
        }

        private void Scalenie(int[] tabela, int lewy, int srodek,int prawy)
        {
            int n1 = srodek - lewy + 1;
            int n2 = prawy - srodek;

            int[] ltab = new int[n1];
            int[] ptab = new int[n2];

            for (int i = 0; i < n1; i++)
                ltab[i] = tabela[lewy + i];

            for (int i = 0; i < n2; i++)
                ptab[i] = tabela[srodek + 1 + i];

            int l = 0;
            int p = 0;
            int k = lewy;

            while(l<n1 && p < n2)
            {
                if (ltab[l] <= ptab[p])
                {
                    tabela[k] = ltab[l];
                    l++;
                }
                else
                {
                    tabela[k] = ptab[p];
                    p++;
                }
                k++;
            }

            while (l < n1)
            {
                tabela[k] = ltab[l];
                l++;
                k++;
            }

            while (p < n2)
            {
                tabela[k] = ptab[p];
                p++;
                k++;    
            }
        }
    }
}
