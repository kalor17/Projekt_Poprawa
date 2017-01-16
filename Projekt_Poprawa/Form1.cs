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
                b.Text = "O";
                

                if (gra.CzyWygrana())
                {
                    MessageBox.Show("Koniec gry wygral Gracz");
                }
                else
                if (gra.CzyRemis() && gra.CzyWygrana()==false)
                {
                    MessageBox.Show("Remis");
                }
                else
                {
                    if (gra.CzyWygrana() == false && gra.CzyRemis() == false)
                    {
                        int p = gra.WykonajRuchKomputera();
                        przyciski[p].Enabled = false;
                        przyciski[p].Text = "X";
                    }
                    if (gra.CzyWygrana())
                    {
                        MessageBox.Show("Koniec gry wygral Komputer");
                    }
                    else
                    if (gra.CzyRemis() && gra.CzyWygrana() == false)
                    {
                        MessageBox.Show("Remis");
                    }
                }

                
                
            }
        }
    }
}
