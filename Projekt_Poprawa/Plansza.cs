using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    class Plansza : IUstawieniaPlanszy
    {
        private int ilelRuchow;
        private int ileRemisow;
        private int[] tablica;

        public Plansza()
        {
            tablica = new int[9];
            for (int i = 0; i < 9; i++)
               this.tablica[i] = i + 3;
            this.ilelRuchow = 0;
            this.ileRemisow = 0;
        }

        public int[] ReturnTablica()
        {
            return this.tablica;
        }

        public void WstawZnak(int indeks, int znak)
        {
            this.tablica[indeks] = znak;
            this.ilelRuchow += 1;
        }

        public bool CzyWygrana()
        {
            bool a = false;
            //Sprawdzanie poziomo
            if ((tablica[0] == tablica[1]) && (tablica[1] == tablica[2])) a = true;
            else
            if ((tablica[3] == tablica[4]) && (tablica[4] == tablica[5])) a = true;
            else
            if ((tablica[6] == tablica[7]) && (tablica[7] == tablica[8])) a = true;
            else

            //Sprawdzanie pionowo
            if ((tablica[0] == tablica[3]) && (tablica[3] == tablica[6])) a = true;
            else
            if ((tablica[1] == tablica[4]) && (tablica[4] == tablica[7])) a = true;
            else
            if ((tablica[2] == tablica[5]) && (tablica[5] == tablica[8])) a = true;
            else

            //Sprawdzanie przekątnych
            if ((tablica[0] == tablica[4]) && (tablica[4] == tablica[8])) a = true;
            else
            if ((tablica[6] == tablica[4]) && (tablica[4] == tablica[2])) a = true;


            return a;
        }

        public bool CzyRemis()
        {
            if (ilelRuchow == 9)
            {
                ileRemisow += 1;
                return true;
            }
            return false;
        }

        public int ReturnRemis()
        {
            return ileRemisow;
        }

        public void ZerujPlansze()
        {
            for (int i = 0; i < 9; i++)
                this.tablica[i] = i + 3;
            this.ilelRuchow = 0;
        }
        public void ZerujRemisy()
        {
            this.ileRemisow = 0;
        }
    }
}
