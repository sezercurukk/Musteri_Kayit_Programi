using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace g8_d3_Odev
{
    class Musteri : IMusteri
    {
        private string _ad;

        public string Ad
        {
            get { return _ad; }
            set { _ad = value; }
        }

        private string _soyad;

        public string Soyad
        {
            get { return _soyad; }
            set { _soyad = value; }
        }
        private DateTime _dogumTarihi;

        public DateTime DogumTarihi
        {
            get { return _dogumTarihi; }
            set { _dogumTarihi = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private long _telNo;

        public long TelefonNumarasi
        {
            get { return _telNo; }
            set { _telNo = value; }
        }

        private bool _durumu;

        public bool Durumu
        {
            get { return _durumu; }
            set { _durumu = value; }
        }

        public string TamAd
        {
            get { return _ad + " " + _soyad; }
        }

        public void BilgileriYazdir()
        {
            Console.WriteLine();
            Console.WriteLine("Ad Soyad: " + TamAd);
            Console.WriteLine("Doğum Tarihi: " + _dogumTarihi.ToShortDateString());
            Console.WriteLine("Email Adresi: " + _email);
            Console.WriteLine("Telefon No: " + _telNo);
        }

        public void BilgileriYazdirKisa(int index)
        {
            Console.WriteLine(index + ". " + TamAd);
        }


    }


    public class Fonksiyonlar
    {

        public static void islemler(int islemNo)
        {
            switch (islemNo)
            {
                case 1:
                    MusteriEkle("MÜŞTERİ EKLE");
                    break;
                case 2:
                    MusteriGuncelle();
                    break;
                case 3:
                    MusterileriListele("MÜŞTERİLERİ LİSTELE");
                    break;
                case 4:
                    MüsteriSil();
                    break;
                case 5:
                    SilinenMusteriler();
                    break;
            }
        }

        private static void SilinenMusteriler()
        {
            MusterileriListele("SİLİNEN MÜŞTERİ LİSTESİ", musteriDurumu: false);
        }

        private static void MüsteriSil()
        {
            MusterileriListele("MÜŞTERİLERİ LİSTELE", false);
            Console.WriteLine();
            if (Program.musteriler.Count > 0)
            {
                int hangiMusteri = intSayi("Silmek istediğiniz müşterinin sıra numarasını giriniz > ", 1, Program.musteriler.Count);

                Program.musteriler[hangiMusteri - 1].Durumu = false;

                AnaMenuyeDon(metin: hangiMusteri + ". sıradaki müşterinin silme işlemi başarı ile tamamlandı.");
            }
            else
            {
                AnaMenuyeDon();
            }

        }

        private static void MusteriGuncelle()
        {
            MusterileriListele("MÜŞTERİLERİ LİSTELE", false);
            Console.WriteLine();
            int hangiMusteri = intSayi("Güncellemek istediğiniz müşterinin sıra numarasını giriniz > ", 1, Program.musteriler.Count);

            Program.musteriler[hangiMusteri - 1].Ad = stringIste("Adı: ");
            Program.musteriler[hangiMusteri - 1].Soyad = stringIste("Soyadı : ");
            Program.musteriler[hangiMusteri - 1].Email = stringIste("Email Adresi: ");
            Program.musteriler[hangiMusteri - 1].DogumTarihi = TarihIste("Doğum Tarihi: ");
            Program.musteriler[hangiMusteri - 1].TelefonNumarasi = TelNoIste("Telefonu: ", 10);

            AnaMenuyeDon(metin: hangiMusteri + ". sıradaki müşterinin güncelleme işlemi başarı ile tamamlandı.");
        }

        private static void MusterileriListele(string baslik, bool anaMenuDurum = true, bool musteriDurumu = true)
        {
            Console.Clear();
            Console.WriteLine(baslik);
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            if (Program.musteriler.Count > 0)
            {
                for (int i = 0; i < Program.musteriler.Count; i++)
                {
                    if (Program.musteriler[i].Durumu == musteriDurumu)
                    {
                        Program.musteriler[i].BilgileriYazdirKisa(i + 1);
                    }
                }
            }
            else
            {
                Console.WriteLine("Listelenecek müşteri bulunamadı.");
            }

            //AnaMenuyeDon(null, anaMenuDurum);
            AnaMenuyeDon(durum: anaMenuDurum);
        }

        public static void MusteriEkle(string baslik)
        {
            Console.Clear();
            Console.WriteLine(baslik);
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            Musteri mus = new Musteri();
            mus.Ad = stringIste("Adı: ");
            mus.Soyad = stringIste("Soyadı : ");
            mus.Email = stringIste("Email Adresi: ");
            mus.DogumTarihi = TarihIste("Doğum Tarihi: ");
            mus.TelefonNumarasi = TelNoIste("Telefonu: ", 10);
            mus.Durumu = true;
            Program.musteriler.Add(mus);

            AnaMenuyeDon("Müşteri ekleme işlemi başarı ile tamamlandı.");
        }

        private static void AnaMenuyeDon(string metin = null, bool durum = true)
        {
            if (durum)
            {
                Console.WriteLine();
                if (!string.IsNullOrEmpty(metin))
                {
                    Console.WriteLine(metin);
                }
                Console.Write("Ana menüye dönmek için bir tuşa basınız.");
                Console.ReadKey();
            }
        }

        private static long TelNoIste(string metin, int maxUzunluk = 18)
        {
            long sayi = 0;
            bool hataVarmi = false;
            do
            {
                Console.Write(metin);
                try
                {
                    sayi = long.Parse(Console.ReadLine());
                    if (sayi.ToString().Length < maxUzunluk)
                    {
                        Console.WriteLine("Geçersiz telefon numarası girişi.");
                        hataVarmi = true;
                    }
                    else
                    {
                        hataVarmi = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hataVarmi = true;
                }
            } while (hataVarmi);

            return sayi;
        }

        private static string stringIste(string metin)
        {
            string text = "";
            bool hataVarmi = false;
            do
            {
                Console.Write(metin);
                text = Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("Boş değer giremezsiniz.");
                    hataVarmi = true;
                }
                else
                {
                    hataVarmi = false;
                }
            } while (hataVarmi);

            return text;
        }

        private static DateTime TarihIste(string metin)
        {
            DateTime tarih = new DateTime();
            bool hataVarmi = false;
            do
            {
                Console.Write(metin);
                try
                {
                    tarih = DateTime.Parse(Console.ReadLine());
                    hataVarmi = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hataVarmi = true;
                }
            } while (hataVarmi);

            return tarih;
        }

        public static int intSayi(string baslik, int basDeger = 0, int bitDeger = 99999999)
        {
            int sayi = 0;
            bool hataVarmi = false;
            do
            {
                Console.Write(baslik);
                try
                {
                    sayi = int.Parse(Console.ReadLine());
                    if (sayi >= basDeger && sayi <= bitDeger)
                    {
                        hataVarmi = false;
                    }
                    else
                    {
                        Console.WriteLine("Lütfen {0} ile {1} sayıları arasında değer giriniz.", basDeger, bitDeger);
                        hataVarmi = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hataVarmi = true;
                }
            } while (hataVarmi);

            return sayi;
        }
    }
}
