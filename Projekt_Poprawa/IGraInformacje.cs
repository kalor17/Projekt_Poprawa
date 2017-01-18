using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    interface IGraInformacje
    {
        bool CzyWygrana();
        bool CzyRemis();
        bool ReturnMoznaGrac();
        bool ReturnGraczVsGracz();
        string ReturnZnakGracz();
        string ReturnZnakGracz2();
        string ReturnZnakKomputer();
        string GraczInfo();
        string Gracz2Info();
        string KomputerInfo();
        int ReturnRemis();
    }
}
