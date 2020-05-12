using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Sortujące
{
    class Bubble:ISort
    {
        public string Nazwa { get; } = "Bubble";
        public void Sortuj(int[] tabela)
        {
            bool zamienione;
            for(int i = 0; i < tabela.Length; i++)
            {
                zamienione = false;
                for(int j = 0; j < tabela.Length-1; j++)
                {
                    if (tabela[j] > tabela[j + 1])
                    {
                        int temp = tabela[j + 1];
                        tabela[j + 1] = tabela[j];
                        tabela[j] = temp;
                        zamienione = true;
                    }
                }
                if (zamienione == false)
                {
                    break;
                }
            }
            
        }
    }
}
