using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Sortujące
{
    class Quick:ISort
    {

        public string Nazwa { get; } = "Quick";
        public void Sortuj(int[] tabela)
        {
            Sortuj(tabela, 0, tabela.Length - 1);
        }
        private void Sortuj(int[] tabela, int lewo, int prawo)
        {
            if (lewo < prawo)
            {
                int pivot = Podzial(tabela, lewo, prawo);
               
                 Sortuj(tabela, lewo, pivot - 1);
                 Sortuj(tabela, pivot + 1, prawo);
                
            }
        }

        private static int Podzial(int[] tabela, int lewo, int prawo)
        {
            int pivot = tabela[prawo];
            int i = lewo - 1;

            for(int j = lewo; j < prawo; j++)
            {
                if (tabela[j] < pivot)
                {
                    i++;
                    int temp = tabela[i];
                    tabela[i] = tabela[j];
                    tabela[j] = temp;
                }
            }

            int temp2 = tabela[i + 1];
            tabela[i + 1] = tabela[prawo];
            tabela[prawo] = temp2;
            return i + 1;
          
        }
    }
}

