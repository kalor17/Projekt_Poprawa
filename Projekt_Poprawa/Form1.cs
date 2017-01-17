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
                if (gra.CzyRemis() && gra.CzyWygrana()==false)
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
                for (int i = 0; i < 9; i++)
                {
                    przyciski[i].Visible=true;
                }
                BNowaGra.Visible = true;
                BResetStat.Visible = true;
            }
        }

        private void UkryjElementy()
        {
            for (int i = 0; i < 9; i++)
            {
                przyciski[i].Hide();
            }
            LNazwa.Hide();
            LZnak.Hide();
            TNazwa.Hide();
            TZnak.Hide();
            BDodaj.Hide();
            BNowaGra.Hide();
            BResetStat.Hide();
        }

        private void BGracze_Click(object sender, EventArgs e)
        {
            LNazwa.Visible=true;
            LZnak.Visible = true;
            TNazwa.Visible = true;
            TZnak.Visible = true;
            BDodaj.Visible = true;
        }

        private void BDodaj_Click(object sender, EventArgs e)
        {
            bool ok = true;
            string nazwa = TNazwa.Text;
            string znak = TZnak.Text;

            try
            {
                if (nazwa == "" || znak == "") throw new ArgumentOutOfRangeException();
                if (znak != "X" && znak != "O") throw new ArgumentOutOfRangeException();
            }
            catch
            {
                ok = false;
                MessageBox.Show("Podaj nazwe gracza or znak (X lub O)");
            }

            if (ok)
            {
                gra.DodajGracza(nazwa, znak);
                gra.DodajKomputer();
                gra.UstawMoznaGrac(true);
                MessageBox.Show("Dodano Gracza i Komputer\nMożna zacząć grę");
                TNazwa.Text = "";
                TZnak.Text = "";

                LNazwa.Hide();
                LZnak.Hide();
                TNazwa.Hide();
                TZnak.Hide();
                BDodaj.Hide();
            }

        }

        private void Wynik()
        {
            LGraczWynik.Text = gra.GraczInfo() + Environment.NewLine + Environment.NewLine + "Remis: " + gra.ReturnRemis().ToString() + Environment.NewLine + Environment.NewLine + gra.KomputerInfo();
            
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
            for (int i = 0; i < 9; i++)
            {
                przyciski[i].Enabled = true;
                przyciski[i].BackColor = Color.White;
                przyciski[i].Text = "";
            }
        }

        private void BResetStat_Click(object sender, EventArgs e)
        {
            gra.ResetStatystyk();
            for (int i = 0; i < 9; i++)
            {
                przyciski[i].Enabled = true;
                przyciski[i].BackColor = Color.White;
                przyciski[i].Text = "";
            }
            Wynik();
        }
    }
}
