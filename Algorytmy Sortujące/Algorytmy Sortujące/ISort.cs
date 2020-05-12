using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Sortujące
{
    interface ISort
    {
        string Nazwa { get; }

        void Sortuj(int[] tabela);
    }
}
