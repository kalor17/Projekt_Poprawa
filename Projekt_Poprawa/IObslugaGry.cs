using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    interface IObslugaGry
    {
        void WykonajRuchGracza(int indeks);
        void WykonajRuchGracza2(int indeks);
        int WykonajRuchKomputera();
        void UstawMoznaGrac(bool ustaw);
        void ZwiekszZwyGracz();
        void ZwiekszZwyGracz2();
        void ZwiekszZwyKomputer();
        void NowaGra();
        void ResetStatystyk();
    }
}
