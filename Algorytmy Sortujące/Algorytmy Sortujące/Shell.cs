using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Sortujące
{
    class Shell : ISort
    {
        public string Nazwa { get; } = "Shell";
        public void Sortuj(int[] tabela)
        {
            int l = tabela.Length;

            for(int gap = l / 2; gap > 0; gap /= 2)
            {
                for(int i = gap; i < l; i++)
                {
                    int temp = tabela[i];
                    int j;

                    for(j=i;j>=gap && tabela[j-gap] > temp; j -= gap)
                    {
                        tabela[j] = tabela[j - gap];
                    }

                    tabela[j] = temp;
                }
            }
        }
    }
}
