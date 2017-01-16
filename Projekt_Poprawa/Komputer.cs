using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    class Komputer : Player
    {
        public Komputer() { }

        public Komputer(string nazwa)
        {
            this.nazwa = nazwa;
            this.lZwyc = 0;
        }


        public override string Info()
        {
            return nazwa + "\nWygranych: " + ReturnZwy();
        }

        public int KomputerRuch(int[] tablica)
        {
            int[] tab = tablica;
            int ruch = -1;

            ruch = WygrajZablokuj(tab, 1);
            if (ruch == -1)
            {
                ruch = WygrajZablokuj(tab, 0);
                if (ruch == -1)
                {
                    ruch = WstawRog(tab);
                    if (ruch == -1)
                    {
                        ruch = WolneMiejsce(tab);
                    }
                }
            }
            return ruch;


        }

        public int WygrajZablokuj(int[] tablica, int znak)
        {
            // Szukanie poziomo
            if ((tablica[0] == znak) && (tablica[1] == znak) && (tablica[2] > 1)) return 2;
            if ((tablica[0] == znak) && (tablica[2] == znak) && (tablica[1] > 1)) return 1;
            if ((tablica[2] == znak) && (tablica[1] == znak) && (tablica[0] > 1)) return 0;

            if ((tablica[3] == znak) && (tablica[4] == znak) && (tablica[5] > 1)) return 5;
            if ((tablica[3] == znak) && (tablica[5] == znak) && (tablica[4] > 1)) return 4;
            if ((tablica[4] == znak) && (tablica[5] == znak) && (tablica[3] > 1)) return 3;

            if ((tablica[6] == znak) && (tablica[7] == znak) && (tablica[8] > 1)) return 8;
            if ((tablica[6] == znak) && (tablica[8] == znak) && (tablica[7] > 1)) return 7;
            if ((tablica[8] == znak) && (tablica[7] == znak) && (tablica[6] > 1)) return 6;

            //Szukanie pionowo
            if ((tablica[0] == znak) && (tablica[3] == znak) && (tablica[6] > 1)) return 6;
            if ((tablica[0] == znak) && (tablica[6] == znak) && (tablica[3] > 1)) return 3;
            if ((tablica[3] == znak) && (tablica[6] == znak) && (tablica[0] > 1)) return 0;

            if ((tablica[1] == znak) && (tablica[4] == znak) && (tablica[7] > 1)) return 7;
            if ((tablica[1] == znak) && (tablica[7] == znak) && (tablica[4] > 1)) return 4;
            if ((tablica[7] == znak) && (tablica[4] == znak) && (tablica[1] > 1)) return 1;

            if ((tablica[2] == znak) && (tablica[5] == znak) && (tablica[8] > 1)) return 8;
            if ((tablica[2] == znak) && (tablica[8] == znak) && (tablica[5] > 1)) return 5;
            if ((tablica[8] == znak) && (tablica[5] == znak) && (tablica[2] > 1)) return 2;

            //Szukanie ukosne
            if ((tablica[0] == znak) && (tablica[4] == znak) && (tablica[8] > 1)) return 8;
            if ((tablica[0] == znak) && (tablica[8] == znak) && (tablica[4] > 1)) return 4;
            if ((tablica[8] == znak) && (tablica[4] == znak) && (tablica[0] > 1)) return 0;

            if ((tablica[2] == znak) && (tablica[4] == znak) && (tablica[6] > 1)) return 6;
            if ((tablica[2] == znak) && (tablica[6] == znak) && (tablica[4] > 1)) return 4;
            if ((tablica[6] == znak) && (tablica[4] == znak) && (tablica[2] > 1)) return 2;

            return -1;
        }

        public int WstawRog(int[] tablica)
        {
            if (tablica[0] == 1)
            {
                if (tablica[2] > 1) return 2;
                if (tablica[6] > 1) return 6;
                if (tablica[8] > 1) return 8;

            }
            if (tablica[2] == 1)
            {
                if (tablica[0] > 1) return 0;
                if (tablica[6] > 1) return 6;
                if (tablica[8] > 1) return 8;

            }
            if (tablica[6] == 1)
            {
                if (tablica[2] > 1) return 2;
                if (tablica[0] > 1) return 0;
                if (tablica[8] > 1) return 8;

            }
            if (tablica[8] == 0)
            {
                if (tablica[2] > 1) return 2;
                if (tablica[6] > 1) return 6;
                if (tablica[0] > 1) return 0;

            }
            if (tablica[0] > 1) return 0;
            if (tablica[2] > 1) return 2;
            if (tablica[6] > 1) return 6;
            if (tablica[8] > 1) return 8;

            return -1;
        }

        public int WolneMiejsce(int[] tablica)
        {
            int i = 0;
            foreach (var element in tablica)
            {
                if (element > 1) return i;
                i += 1;
            }

            return -1;
        }
    }
}
