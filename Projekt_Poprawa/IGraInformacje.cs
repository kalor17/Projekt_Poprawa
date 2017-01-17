﻿using System;
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
        string ReturnZnakGracz();
        string ReturnZnakKomputer();
        string GraczInfo();
        string KomputerInfo();
        int ReturnRemis();
    }
}