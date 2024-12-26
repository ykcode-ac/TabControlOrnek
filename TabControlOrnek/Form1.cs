using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabControlOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private readonly decimal[] yemekFiyatlari = { 20m, 50m, 40m, 10m, 25m };

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TabPage3'e geçildiğinde hesap özeti oluşturulur
            if (tabControl1.SelectedIndex == 2)
            {
                string musteriAdi = textBox1.Text;
                decimal toplamTutar = 0;
                string[] yemekler = { "Çorba", "İskender", "Köfte", "Ayran", "Tatlı" };

                string hesapOzeti = $"Müşteri Adı: {musteriAdi}\n\nSipariş Özeti:\n----------------------\n";

                // Her bir yemeğin adet ve tutar bilgisi
                NumericUpDown[] adetler = { numericUpDownCorba, numericUpDownIskender, numericUpDownKofte, numericUpDownAyran, numericUpDownTatli };

                for (int i = 0; i < yemekler.Length; i++)
                {
                    int adet = (int)adetler[i].Value;
                    decimal tutar = adet * yemekFiyatlari[i];
                    toplamTutar += tutar;

                    if (adet > 0)
                    {
                        hesapOzeti += $"{yemekler[i]} x {adet} adet = {tutar:C}\n";
                    }
                }

                hesapOzeti += $"\nToplam Tutar: {toplamTutar:C}";

                // Hesap özetini label1'e yazdır
                label1.Text = hesapOzeti;
            }
        }
    }
}
