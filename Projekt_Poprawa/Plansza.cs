using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    class Plansza : IUstawieniaPlanszy
    {
        bool CzyWygrana();
        void WstawZnak(int indeks, int znak);
        int[] ReturnTablica();
    }
}
