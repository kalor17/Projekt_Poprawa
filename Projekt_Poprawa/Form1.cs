using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Poprawa
{
    public partial class Form1 : Form
    {
        Gra gra = new Gra();
        Button[] przyciski = new Button[9];
        Button[] przyciski2 = new Button[9];
        public Form1()
        {
            InitializeComponent();
            przyciski[0] = P0;
            przyciski[1] = P1;
            przyciski[2] = P2;
            przyciski[3] = P3;
            przyciski[4] = P4;
            przyciski[5] = P5;
            przyciski[6] = P6;
            przyciski[7] = P7;
            przyciski[8] = P8;
            przyciski2[0] = R0;
            przyciski2[1] = R1;
            przyciski2[2] = R2;
            przyciski2[3] = R3;
            przyciski2[4] = R4;
            przyciski2[5] = R5;
            przyciski2[6] = R6;
            przyciski2[7] = R7;
            przyciski2[8] = R8;

            UkryjElementy();

        }

        private void PClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string nazwa = b.Name;
            int liczba = (int)Char.GetNumericValue(nazwa[1]);

            if (b.Text == "")
            {
                gra.WykonajRuchGracza(liczba);
                b.Enabled = false;
                b.Text = gra.ReturnZnakGracz();
                b.BackColor = Color.GreenYellow;


                if (gra.CzyWygrana())
                {
                    MessageBox.Show("Koniec gry wygral Gracz");
                    gra.ZwiekszZwyGracz();
                    BlokowaniePrzyciskow();
                    Wynik();
                }
                else
                    if (gra.CzyRemis() && gra.CzyWygrana() == false)
                    {
                        MessageBox.Show("Remis");
                        BlokowaniePrzyciskow();
                        Wynik();
                    }
                    else
                    {
                        if (gra.CzyWygrana() == false && gra.CzyRemis() == false)
                        {
                            int p = gra.WykonajRuchKomputera();
                            przyciski[p].Enabled = false;
                            przyciski[p].Text = gra.ReturnZnakKomputer();
                            przyciski[p].BackColor = Color.LightBlue;
                        }
                        if (gra.CzyWygrana())
                        {
                            MessageBox.Show("Koniec gry wygral Komputer");
                            gra.ZwiekszZwyKomputer();
                            BlokowaniePrzyciskow();
                            Wynik();
                        }
                        else
                            if (gra.CzyRemis() && gra.CzyWygrana() == false)
                            {
                                MessageBox.Show("Remis");
                                BlokowaniePrzyciskow();
                                Wynik();
                            }
                    }



            }

        }

        private void R_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string nazwa = b.Name;
            int liczba = (int)Char.GetNumericValue(nazwa[1]);

            if (gra.ReturnRuch() == 0)
            {
                gra.WykonajRuchGracza(liczba);
                b.Enabled = false;
                b.Text = gra.ReturnZnakGracz();
                b.BackColor = Color.GreenYellow;
            }
            else
            {
                gra.WykonajRuchGracza2(liczba);
                b.Enabled = false;
                b.Text = gra.ReturnZnakGracz2();
                b.BackColor = Color.LightBlue;
            }

            if (gra.CzyWygrana())
            {
                if (gra.ReturnRuch() == 1)
                {
                    MessageBox.Show("Koniec gry wygral Gracz1");
                    gra.ZwiekszZwyGracz();
                }
                else
                {
                    MessageBox.Show("Koniec gry wygral Gracz2");
                    gra.ZwiekszZwyGracz2();
                }
                
                BlokowaniePrzyciskow();
                Wynik();
            }
            else
                if (gra.CzyRemis() && gra.CzyWygrana() == false)
                {
                    MessageBox.Show("Remis");
                    BlokowaniePrzyciskow();
                    Wynik();
                }
        }

        private void BStart_Click(object sender, EventArgs e)
        {
            bool ok = true;

            try
            {
                if (gra.ReturnMoznaGrac() == false) throw new ArgumentOutOfRangeException();
            }
            catch
            {
                ok = false;
                MessageBox.Show("Przed rozpoczęciem gry dodaj gracza");
            }

            if (ok)
            {
                if (gra.ReturnGraczVsGracz() == false) 
                    for (int i = 0; i < 9; i++)
                        przyciski[i].Visible = true;
                else
                    for (int i = 0; i < 9; i++)
                        przyciski2[i].Visible = true;
                BNowaGra.Visible = true;
                BResetStat.Visible = true;
                BResetGry.Visible = true;
                LGraczWynik.Visible = true;
                Wynik();
                BGracze.Visible = false;
            }
        }

        private void BDodaj_Click(object sender, EventArgs e)
        {
            bool ok = true;
            string nazwa = TNazwa.Text;
            string nazwa2 = TNazwa2.Text;
            string znak = TZnak.Text;

            if (gra.ReturnGraczVsGracz() == false)
            {
                try
                {
                    if (nazwa == "" || znak == "") throw new ArgumentOutOfRangeException();
                    if (znak != "X" && znak != "O") throw new ArgumentOutOfRangeException();
                }
                catch
                {
                    ok = false;
                    MessageBox.Show("Podaj nazwe gracza oraz znak (X lub O)");
                }

                if (ok)
                {
                    gra.DodajGracza(nazwa, znak);
                    gra.DodajKomputer();
                    gra.DodajGracza2("gg");
                    gra.UstawMoznaGrac(true);
                    MessageBox.Show("Dodano Gracza i Komputer\nMożna zacząć grę");
                    TNazwa.Text = "";
                    TZnak.Text = "";

                    LNazwa.Hide();
                    LZnak.Hide();
                    TNazwa.Hide();
                    TZnak.Hide();
                    BDodaj.Hide();
                    BGraczVsKomputer.Hide();
                    BGraczVsGracz.Hide();
                    BGracze.Hide();
                }
            }
            else
            {
                try
                {
                    if (nazwa == "" || znak == "" || nazwa2 == "") throw new ArgumentOutOfRangeException();
                    if (znak != "X" && znak != "O") throw new ArgumentOutOfRangeException();
                }
                catch
                {
                    ok = false;
                    MessageBox.Show("Podaj nazwe graczy oraz znak (X lub O)");
                }

                if (ok)
                {
                    gra.DodajGracza(nazwa, znak);
                    gra.DodajGracza2(nazwa2);
                    gra.DodajKomputer();
                    gra.UstawMoznaGrac(true);
                    MessageBox.Show("Dodano Graczy\nMożna zacząć grę");
                    TNazwa.Text = "";
                    TZnak.Text = "";
                    TNazwa2.Text = "";

                    LNazwa.Hide();
                    LZnak.Hide();
                    TNazwa.Hide();
                    TZnak.Hide();
                    LNazwa2.Hide();
                    LZnak2.Hide();
                    TNazwa2.Hide();
                    BDodaj.Hide();
                    BGraczVsKomputer.Hide();
                    BGraczVsGracz.Hide();
                    BGracze.Hide();
                }
            }

        }
        #region Ustawienia Przyciskow + Wynik
        private void UkryjElementy()
        {
            for (int i = 0; i < 9; i++)
            {
                przyciski[i].Hide();
                przyciski2[i].Hide();
            }
            LNazwa.Hide();
            LZnak.Hide();
            TNazwa.Hide();
            TZnak.Hide();
            LNazwa2.Hide();
            LZnak2.Hide();
            TNazwa2.Hide();
            BDodaj.Hide();
            BNowaGra.Hide();
            BResetStat.Hide();
            BResetGry.Hide();
            LGraczWynik.Hide();
            BGracze.Hide();
            BStart.Hide();
        }

        private void BGracze_Click(object sender, EventArgs e)
        {
            LNazwa.Visible = true;
            LZnak.Visible = true;
            TNazwa.Visible = true;
            TZnak.Visible = true;
            BDodaj.Visible = true;
            if (gra.ReturnGraczVsGracz())
            {
                LNazwa2.Visible = true;
                LZnak2.Visible = true;
                TNazwa2.Visible = true;
            }
            BGracze.Visible = false;
            BGraczVsGracz.Hide();
            BGraczVsKomputer.Hide();
        }

        

        private void Wynik()
        {
            if(gra.ReturnGraczVsGracz()==false)
                LGraczWynik.Text = gra.GraczInfo() + Environment.NewLine + Environment.NewLine + "Remis: " + gra.ReturnRemis().ToString() + Environment.NewLine + Environment.NewLine + gra.KomputerInfo();
            else
                LGraczWynik.Text = gra.GraczInfo() + Environment.NewLine + Environment.NewLine + "Remis: " + gra.ReturnRemis().ToString() + Environment.NewLine + Environment.NewLine + gra.Gracz2Info();
        }
        
        private void BlokowaniePrzyciskow()
        {
            for (int i = 0; i < 9; i++)
            {
                przyciski[i].Enabled = false;
            }
        }

        private void BWyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BNowaGra_Click(object sender, EventArgs e)
        {
            gra.NowaGra();
            if (gra.ReturnGraczVsGracz() == false)
            {
                for (int i = 0; i < 9; i++)
                {
                    przyciski[i].Enabled = true;
                    przyciski[i].BackColor = Color.White;
                    przyciski[i].Text = "";
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    przyciski2[i].Enabled = true;
                    przyciski2[i].BackColor = Color.White;
                    przyciski2[i].Text = "";
                }
            }
        }

        private void BResetStat_Click(object sender, EventArgs e)
        {
            gra.ResetStatystyk();
            if (gra.ReturnGraczVsGracz() == false)
            {
                for (int i = 0; i < 9; i++)
                {
                    przyciski[i].Enabled = true;
                    przyciski[i].BackColor = Color.White;
                    przyciski[i].Text = "";
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    przyciski2[i].Enabled = true;
                    przyciski2[i].BackColor = Color.White;
                    przyciski2[i].Text = "";
                }
            }
            Wynik();
        }

        private void BResetGry_Click(object sender, EventArgs e)
        {
            UkryjElementy();
            gra = new Gra();
            if (gra.ReturnGraczVsGracz() == false)
            {
                for (int i = 0; i < 9; i++)
                {
                    przyciski[i].Enabled = true;
                    przyciski[i].BackColor = Color.White;
                    przyciski[i].Text = "";
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    przyciski2[i].Enabled = true;
                    przyciski2[i].BackColor = Color.White;
                    przyciski2[i].Text = "";
                }
            }
            BGracze.Visible = true;
            BGraczVsGracz.Visible = true;
            BGraczVsKomputer.Visible = true;
        }
        #endregion

        private void BGraczVsKomputer_Click(object sender, EventArgs e)
        {
            gra.UstawGraczVsGracz(false);
            BGracze.Visible = true;
            BStart.Visible = true;
            MessageBox.Show("Wybrano tryb Gracz vs Komputer\nWybierz Graczy");
            BGraczVsKomputer.Hide();
            BGraczVsGracz.Hide();
        }

        private void BGraczVsGracz_Click(object sender, EventArgs e)
        {
            gra.UstawGraczVsGracz(true);
            BGracze.Visible = true;
            BStart.Visible = true;
            MessageBox.Show("Wybrano tryb Gracz vs Gracz\nWybierz Graczy");
            BGraczVsKomputer.Hide();
            BGraczVsGracz.Hide();
        }

        
    }
}
