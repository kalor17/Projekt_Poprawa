using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    interface IUstawieniaGry
    {
        void DodajGracza(string nazwa, string znak);
        void DodajKomputer();
        void WykonajRuchGracza(int indeks);
        int WykonajRuchKomputera();
        bool CzyWygrana();
        bool CzyRemis();
        bool ReturnMoznaGrac();
        void UstawMoznaGrac(bool ustaw);
        string ReturnZnakGracz();
        string ReturnZnakKomputer();
        string GraczInfo();
        string KomputerInfo();
        int ReturnRemis();
        void ZwiekszZwyGracz();
        void ZwiekszZwyKomputer();
        void NowaGra();
        void ResetStatystyk();
    }
}
