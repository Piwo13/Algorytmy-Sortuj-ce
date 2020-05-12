using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Sortujące
{
    class Heap:ISort
    {
        public string Nazwa { get; } = "Heap";

        public void Sortuj(int[] tabela)
        {
            for(int i = (tabela.Length / 2) - 1; i >= 0; i--)
            {
                Stog(tabela, tabela.Length, i);
            }

            for(int i = tabela.Length - 1; i> 0; i--)
            {
                int temp = tabela[0];
                tabela[0] = tabela[i];
                tabela[i] = temp;

                Stog(tabela, i, 0);
            }
        }

        private void Stog(int[] tabela,int dlugosc,int i)
        {
            int najwiekszy = i;
            int lewy = 2 * i + 1;
            int prawy = 2 * i + 2;

            if (lewy < dlugosc && tabela[lewy] > tabela[najwiekszy])
                najwiekszy = lewy;

            if (prawy< dlugosc && tabela[prawy] > tabela[najwiekszy])
                najwiekszy = prawy;

            if (najwiekszy != i)
            {
                int temp = tabela[i];
                tabela[i] = tabela[najwiekszy];
                tabela[najwiekszy] = temp;

                Stog(tabela, dlugosc, najwiekszy);
            }
        }
    }
}
