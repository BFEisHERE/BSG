using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bsg_hafta3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream("D:\\BSG.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter sifreyazdir = new StreamWriter(fileStream);
            string uckelime = textBox1.Text + textBox2.Text + textBox3.Text;
            char[] tumharfler = uckelime.ToCharArray();
            Array.Sort(tumharfler);
            for (int i = 0; i < tumharfler.Length; i++)
            {
                textBox4.Text += tumharfler[i];
            }
            int sayac = 1;
            char[] harfsec = new char[tumharfler.Length];
            
            harfsec[0] = tumharfler[0];
            textBox5.Text = Convert.ToString( harfsec[0]);
            for (int j = 0; j < tumharfler.Length-1; j++)
            {
                if (tumharfler[j]!=tumharfler[j+1])
                {
                    harfsec[sayac] = tumharfler[j+1];
                    textBox5.Text += harfsec[sayac];
                    sayac = sayac+ 1;
                   
                }

                
            }
            int sayac2 = 1;
            char[] secim1 = textBox5.Text.ToCharArray();
            char[] secim2 = new char[secim1.Length];
            for (int i = 0; i < secim1.Length; i++)
            {
                secim2[i] = secim1[i];

            }

            for (int a = 0; a < secim2.Length; a++)
            {
                for (int b = 0; b < secim2.Length; b++
                {
                    for (int c = 0; c < secim2.Length; c++)
                    {
                        for (int d = 0; d < secim2.Length; d++)
                        {
                            for (int f = 0; f < secim2.Length; f++)
                            {
                                if (secim2[a] !='a' && secim2[a] != 'e' && secim2[a] != 'ı' && secim2[a] != 'i' && secim2[a] != 'o' && secim2[a] != 'ö' && secim2[a] != 'u' && secim2[a] != 'ü' && secim2[f]!='o')
                                {
                                    string cıktı = Convert.ToString(secim2[a]) + Convert.ToString(secim2[b]) + Convert.ToString(secim2[c]) + Convert.ToString(secim2[d]) + Convert.ToString(secim2[f]);
                                    sifreyazdir.WriteLine(sayac2 + "-)" + cıktı);
                                    sayac2++;

                                }
                            }

                        }

                    }

                }
            }
            
            
        }
    }
}
