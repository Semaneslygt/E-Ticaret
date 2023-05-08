using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Ticaret.Models.ViewModel
{
    public class Urun
    {
        public class UrunListeModel
        {
            public int urunID { get; set; }
            public int? kategoriID { get; set; }
            public int? markaID { get; set; }
            public string urunAdi { get; set; }
            public string urunAciklama { get; set; }
            public string listeGorsel { get; set; }
            public int? stok { get; set; }
            public decimal? gelisFiyati { get; set; }
            public decimal? satisFiyati { get; set; }
            public int? kdvOran { get; set; }
            public int? satılanAdet { get; set; }
            public Nullable<System.DateTime> olusturmaTarih { get; set; }
            public Nullable<System.DateTime> guncellemeTarih { get; set; }
        }
        public class UrunOlusturModel
        {
            public int kategoriID { get; set; }
            public int markaID { get; set; }
            public string urunAdi { get; set; }
            public string urunAciklama { get; set; }
            public string ListeGorsel { get; set; }
            public int Stok { get; set; }
            public decimal GelisFiyati { get; set; }
            public decimal SatisFiyati { get; set; }
            public int KdvOran { get; set; }
            public int SatılanAdet { get; set; }

        }
        public class UrunDuzenleModel
        {
            public int urunID { get; set; }
            public int kategoriID { get; set; }
            public int markaID { get; set; }
            public string urunAdi { get; set; }
            public string urunAciklama { get; set; }
            public string ListeGorsel { get; set; }
            public decimal GelisFiyati { get; set; }
            public decimal SatisFiyati { get; set; }
            public int KdvOran { get; set; }
            public int SatılanAdet { get; set; }
        }
        public class FavoriListeModel
        {
            public int favoriID { get; set; }
            public int? uyeID { get; set; }
            public string ipNumarası { get; set; }
            public int? urunID { get; set; }
        }

    }
}