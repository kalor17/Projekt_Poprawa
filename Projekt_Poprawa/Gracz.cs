using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    class Gracz : Player
    {
        public Gracz() { }

        public Gracz(string nazwa,  string znak)
        {
            this.nazwa = nazwa;
            this.znak = znak;
            this.lZwyc = 0;
        }
        public Gracz(string nazwa)
        {
            this.nazwa = nazwa;
            this.lZwyc = 0;
        }

        public override string Info()
        {
            return this.nazwa + "\nWygrane: " + ReturnZwy();
        }
    }
}
