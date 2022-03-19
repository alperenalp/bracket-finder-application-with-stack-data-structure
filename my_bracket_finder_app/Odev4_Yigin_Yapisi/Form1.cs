using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev4_Yigin_Yapisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class dugum
        {
            public char deger;
            public dugum baglanti;
        }
        public dugum ilk;

        private void butonKontrol_Click(object sender, EventArgs e)
        {
            string ifade = textBox1.Text;
            int boyut = ifade.Length;
            ilk = null;
            Boolean dogruMu = true;
            Boolean kontrol = true;
            int acilan = 0;
            int kapanan = 0;
            for (int i = 0; i < boyut; i++)
            {
                char karakter = ifade[i];
                if (karakter == '(' || karakter == '{' || karakter == '[')
                {
                    push(karakter);
                    acilan++;
                }

                if (karakter == ')' || karakter == '}' || karakter == ']')
                {
                    if (isempty())
                    {
                        MessageBox.Show("Açma parantezinden eksik var.");
                        dogruMu = false;
                        break;
                    }
                    else
                    {
                        char top = peek(); // yığında tepedeki karakteri bulur
                        if (top == '(' && karakter == ')' || top == '{' && karakter == '}' || top == '[' && karakter == ']')
                        {
                            pop();  // yığında tepedeki karakteri siler
                            kapanan++;
                        }
                        else
                        {
                            MessageBox.Show("Parantezlerde uyuşmazlık var.");
                            dogruMu = false;
                            kontrol = false;
                        }
                    }
                }
            }
            if (!isempty() && kontrol && acilan > kapanan)
            {
                MessageBox.Show("Kapama parantezinden eksik var.");
                dogruMu = false;
            }

            if (dogruMu)
            {
                MessageBox.Show("Parantezlerin Doğru");
            }
        }

        private void pop()
        {
            ilk = ilk.baglanti;
        }

        private char peek()
        {
            return ilk.deger;
        }

        private bool isempty()
        {
            if (ilk != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void push(char karakter)
        {
            dugum yeni = new dugum();
            yeni.deger = karakter;
            yeni.baglanti = ilk;
            ilk = yeni;
        }
    }
}
