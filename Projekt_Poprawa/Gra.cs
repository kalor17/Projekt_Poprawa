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
        private Plansza plansza = new Plansza();
        private int ruch = 0; // 0 lub 1
        private bool mozna_grac = false;


        public void DodajGracza(string nazwa, string znak)
        {
            gracz = new Gracz(nazwa, znak);
        }

        public void DodajKomputer()
        {
            komputer = new Komputer();
            if (gracz.ReturnZnak() == "O") komputer.UstawZnak("X");
            else
                komputer.UstawZnak("O");
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

        public bool ReturnMoznaGrac()
        {
            return mozna_grac;
        }
        public void UstawMoznaGrac(bool ustaw)
        {
            this.mozna_grac = ustaw;
        }
        public string ReturnZnakGracz()
        {
            return gracz.ReturnZnak();
        }

        public string ReturnZnakKomputer()
        {
            return komputer.ReturnZnak();
        }

        public string GraczInfo()
        {
            return gracz.Info();
        }

        public string KomputerInfo()
        {
            return komputer.Info();
        }
        public int ReturnRemis()
        {
            return plansza.ReturnRemis();
        }
        
    }
}
