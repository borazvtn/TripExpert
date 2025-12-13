using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace firstScreen
{
    public partial class SehirDetayForm : Form
    {
        public SehirDetayForm(string sehirAdi)
        {
            InitializeComponent();
            this.Text = sehirAdi + " Mekanları";
            MekanlariGetir(sehirAdi);
        }

        private void MekanlariGetir(string sehirAdi)
        {
            panelMekanlar.Controls.Clear();

            // --- 1. KRİTİK DÜZELTME: LİSTE BOŞSA DOLDUR ---
            // Eğer hafızadaki şehir listesi boşsa (0), demek ki henüz yüklenmemiş.
            // Hemen veritabanına bağlanıp verileri çekiyoruz.
            if (DataManagement.AllCities.Count == 0)
            {
                DataManagement.LoadPlacesFromDatabase();
            }
            // ----------------------------------------------

            Sehir secilenSehir = null;

            // --- 2. DÜZELTME: BÜYÜK/KÜÇÜK HARF DUYARLILIĞINI KALDIR ---
            // Veritabanında "adana", listede "Adana" yazıyor olabilir.
            // İkisini de küçültüp (.ToLower) ve boşluklarını temizleyip (.Trim) karşılaştırıyoruz.
            foreach (var sehir in DataManagement.AllCities)
            {
                if (sehir.Name.Trim().ToLower() == sehirAdi.Trim().ToLower())
                {
                    secilenSehir = sehir;
                    break;
                }
            }

            if (secilenSehir != null)
            {
                if (secilenSehir.Mekanlar.Count == 0)
                {
                    MessageBox.Show(secilenSehir.Name + " şehri için veritabanında henüz mekan kaydı yok.");
                    return;
                }

                foreach (Mekan mekan in secilenSehir.Mekanlar)
                {
                    YeniKart kart = new YeniKart();
                    kart.BilgileriYukle(mekan);
                    kart.Margin = new Padding(15);
                    panelMekanlar.Controls.Add(kart);
                }
            }
            else
            {
                // Eğer hala bulunamadıysa gerçekten veritabanında yoktur veya isim yanlıştır.
                // Kullanıcıya listedeki toplam şehir sayısını da gösterelim ki sorunu anlayalım.
                MessageBox.Show("Hata: '" + sehirAdi + "' veritabanında bulunamadı!\n" +
                                "Hafızadaki Toplam Şehir Sayısı: " + DataManagement.AllCities.Count);
            }
        }
    }
}