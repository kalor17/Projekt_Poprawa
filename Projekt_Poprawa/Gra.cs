using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    class Gra : IUstawieniaGry, IObslugaGry, IGraInformacje
    {
        private Gracz gracz;
        private Gracz gracz2;
        private Komputer komputer;
        private Plansza plansza = new Plansza();
        private int ruch = 0; // 0 lub 1
        private bool mozna_grac = false;
        private bool graczvsgracz = false;


        public void DodajGracza(string nazwa, string znak)
        {
            gracz = new Gracz(nazwa, znak);
        }
        public void DodajGracza2(string nazwa)
        {
            gracz2 = new Gracz(nazwa);
            if (gracz.ReturnZnak() == "O") gracz2.UstawZnak("X");
            else
                gracz2.UstawZnak("O");
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
            this.ruch = 1;
        }
        public void WykonajRuchGracza2(int indeks)
        {
            plansza.WstawZnak(indeks, ruch);
            this.ruch = 0;
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
        public string ReturnZnakGracz2()
        {
            return gracz2.ReturnZnak();
        }


        public string ReturnZnakKomputer()
        {
            return komputer.ReturnZnak();
        }

        public string GraczInfo()
        {
            return gracz.Info();
        }
        public string Gracz2Info()
        {
            return gracz2.Info();
        }

        public string KomputerInfo()
        {
            return komputer.Info();
        }
        public int ReturnRemis()
        {
            return plansza.ReturnRemis();
        }
        public void ZwiekszZwyGracz()
        {
            gracz.ZwiekszZwy();
        }
        public void ZwiekszZwyGracz2()
        {
            gracz2.ZwiekszZwy();
        }
        public void ZwiekszZwyKomputer()
        {
            komputer.ZwiekszZwy();
        }
        public void NowaGra()
        {
            plansza.ZerujPlansze();
            ruch = 0;
        }
        public void ResetStatystyk()
        {
            plansza.ZerujPlansze();
            ruch = 0;
            gracz.ZerujZwy();
            komputer.ZerujZwy();
            plansza.ZerujRemisy();
        }
        public bool ReturnGraczVsGracz()
        {
            return this.graczvsgracz;
        }
        public void UstawGraczvsGracz(bool gracze)
        {
            this.graczvsgracz = gracze;
        }
        public int ReturnRuch()
        {
            return this.ruch;
        }
        
        
    }
}
