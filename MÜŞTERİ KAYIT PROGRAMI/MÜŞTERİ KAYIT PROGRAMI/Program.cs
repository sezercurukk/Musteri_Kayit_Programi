using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musteri_Kayit_Programi
{
    class Program
    {
        public static List<Musteri> musteriler = new List<Musteri>();

        static void Main(string[] args)
        {
            // MÜŞTERİ KAYIT PROGRAMI

            // 1. Müşteri Ekle
            // 2. Müşteri Güncelle (index numarasına göre)
            // 3. Müşteri Listele
            // 4. Müşteri Sil
            // 5. Silinen Müşterileri Listele
            // 6. Programdan Çık

            // Müsteri class'ını IMusteri interface'sinde tanımlı olan imzalara uygun şekilde üretimini yapınız.
            // Yukarıda belirtilmiş olan menüler dahilinde uygulamanızda kulanıcının girmiş olduğu verileri hata mekanizmasını kullanarak boş veya yanlış veri girişini engelleyiniz.
            int islemNo = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("MÜŞTERİ KAYIT PROGRAMI");
                Console.WriteLine();
                Console.WriteLine("1. Müşteri Ekle");
                Console.WriteLine("2. Müşteri Güncelle");
                Console.WriteLine("3. Müşteri Listele");
                Console.WriteLine("4. Müşteri Sil");
                Console.WriteLine("5. Silinen Müşterileri Listele");
                Console.WriteLine("6. Programdan Çık");

                islemNo = Fonksiyonlar.intSayi("Yapmak istediğiniz işlem numarasını giriniz > ", 1, 6);
                Fonksiyonlar.islemler(islemNo);

            } while (islemNo != 6);

            Console.WriteLine();
            Console.WriteLine("Programımızı kullandığınız için teşşekür ederiz.");
            Console.WriteLine("Programı kapatmak için bir tuşa basınız.");
            Console.ReadKey();
        }

        
    }
}
