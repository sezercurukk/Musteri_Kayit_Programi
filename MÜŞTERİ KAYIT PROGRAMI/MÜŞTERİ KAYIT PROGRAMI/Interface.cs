using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace g8_d3_Odev
{
    interface IMusteri
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        DateTime DogumTarihi { get; set; }
        string Email { get; set; }
        long TelefonNumarasi { get; set; }
        bool Durumu { get; set; } // değer default olarak true gelsin.
        string TamAd { get; }
        void BilgileriYazdir();
    }
}
