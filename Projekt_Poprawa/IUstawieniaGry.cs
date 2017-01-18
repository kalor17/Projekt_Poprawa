﻿using System;
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
        void DodajGracza2(string nazwa);
        void UstawGraczVsGracz(bool ustaw);
        void UstawMoznaGrac(bool ustaw);

    }
}
