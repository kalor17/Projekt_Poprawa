using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    class Gra : IUstawieniaGry
    {
        private Gracz gracz;
        private Komputer komputer = new Komputer();
        Plansza plansza = new Plansza();
        private int ruch = 0; // 0 lub 1


        public void DodajGracza(string nazwa, char znak)
        {
            gracz = new Gracz(nazwa, znak);
        }

        public void DodajKomputer(string nazwa)
        {
            komputer = new Komputer(nazwa);
            if (gracz.ReturnZnak() == 'O') komputer.UstawZnak('X');
            else
                komputer.UstawZnak('O');
        }

        public void WykonajRuchGracza(int indeks)
        {
            plansza.WstawZnak(indeks, ruch);
            ruch = 1;
        }

        public int WykonajRuchKomputera()
        {
            int[] tab = plansza.ReturnTablica();
            int pole=0;
            pole = komputer.KomputerRuch(tab);
            plansza.WstawZnak(pole, ruch);
            ruch = 0;
            
            return pole;
        }

        public bool CzyWygrana()
        {
            return plansza.CzyWygrana();
        }
        public bool CzyRemis()
        {
            return plansza.CzyRemis();
        }

        public int[] ReturnTab()
        {
            return plansza.ReturnTablica();
        }
    }
}
