using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U12_BP_Gr_B
{
    // Char 
    // IsLetter()  => shkronja
    // IsDigit()  => numer
    // IsUpper() => shkronje e madhe
    // IsLower() => shkonje e vogel 

    public partial class Form1 : Form
    {
        string tekstiNgaPerdoruesi = "";
        public Form1()
        {
            InitializeComponent();
        }

        #region Eventet e butonave
        private void btnNrShkronja_Click(object sender, EventArgs e)
        {
            tekstiNgaPerdoruesi = txtTeksti.Text;

            //Metoda 1
            MessageBox.Show("Numri i shkronjave: " +
                NumriIShkronja(tekstiNgaPerdoruesi));

            //Metoda 2
            //int nrShkronjave = NumriIShkronja(tekstiNgaPerdoruesi);
            //MessageBox.Show("Numri i shkronjave: " + nrShkronjave);
        }

        private void btnNrNumrave_Click(object sender, EventArgs e)
        {
            tekstiNgaPerdoruesi = txtTeksti.Text;
            MessageBox.Show("Numri i numrave: " + 
                NumriINumrave(tekstiNgaPerdoruesi));
        }

        private void btnNrShkronjaTeMedha_Click(object sender, EventArgs e)
        {
            tekstiNgaPerdoruesi = txtTeksti.Text;
            MessageBox.Show("Numri i shkronjave te medha: " +
                     NumriIShkronjaveTeMedha(tekstiNgaPerdoruesi));
        }

        private void btnNrShkronjaTeVogla_Click(object sender, EventArgs e)
        {
            tekstiNgaPerdoruesi = txtTeksti.Text;
            int numriIShkronjave;
            NumriIShkronjaveTeVogla(tekstiNgaPerdoruesi, out numriIShkronjave);
            MessageBox.Show("Numri i shkronjave te vogla: " + numriIShkronjave);
        }

        private void btnCapitalizeWord_Click(object sender, EventArgs e)
        {
            tekstiNgaPerdoruesi = txtTeksti.Text;
            txtTeksti.Text = CapitalizeFirstWord(tekstiNgaPerdoruesi);
        }

        private void btnKerko_Click(object sender, EventArgs e)
        {
            tekstiNgaPerdoruesi = txtTeksti.Text;
            string fjala = txtKerko.Text;

            if (DoesAWordExistInAText(tekstiNgaPerdoruesi, fjala))
            {
                MessageBox.Show("U gjet fjala!");
            }
            else
            {
                MessageBox.Show("Fjala nuk u gjet");
            }
        }

        #endregion

        #region Metodat

        private int NumriIShkronja(string teksti)
        {
            int count = 0;
            for(int i=0; i< teksti.Length;i++)
            {
                if (Char.IsLetter(teksti[i]))
                {
                    count++;
                }
            }
            return count;
        }

        private int NumriINumrave(string teksti)
        {
            int count = 0;
            for (int i = 0; i < teksti.Length; i++)
            {
                if(Char.IsDigit(teksti[i]))
                {
                    count++;
                }
            }
            return count;
        }

        private int NumriIShkronjaveTeMedha(string teksti)
        {
            int count = 0;
            for (int i = 0; i < teksti.Length; i++)
            {
                if (Char.IsUpper(teksti[i]))
                {
                    count++;
                }
            }
            return count;
        }

        private void NumriIShkronjaveTeVogla(string teksti, 
            out int nrShkronja)
        {
            nrShkronja = 0;
            for (int i = 0; i < teksti.Length; i++)
            {
                if(Char.IsLower(teksti[i]))
                {
                    nrShkronja++;
                }
            }
        }

        // bazat e programimit
        // b
        // azat e programimit
        private string CapitalizeFirstWord(string text)
        {
            string firstLetter = text[0].ToString();
            string otherPartOfText = text.Substring(1, text.Length-1);

            return firstLetter.ToUpper() + otherPartOfText.ToLower();
        }

        private bool DoesAWordExistInAText(string  text, string word)
        {
            string pattern = @"" + word;
            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);
            if (match.Success)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
