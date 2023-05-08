using e_Ticaret.Models;
using e_Ticaret.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static e_Ticaret.Models.ViewModel.Urun;

namespace e_Ticaret.Controllers
{
    public class UrunController : ApiController
    {
        ShopDBEntities _urunDB = new ShopDBEntities();
        Sonuc sonuc = new Sonuc();

        #region Ürün Liste
        [HttpGet]
        [Route("api/urunlistele")]
        public List<UrunListeModel> UrunListele()
        {
            List<UrunListeModel> liste = _urunDB.tblUrunlers.Select(x => new UrunListeModel()
            {
                kategoriID = x.KategoriID,
                markaID = x.MarkaID,
                urunAdi = x.UrunAdi,
                urunAciklama = x.UrunAciklama,
                listeGorsel = x.ListeGorsel,
                gelisFiyati = x.GelisFiyati,
                satisFiyati = x.SatisFiyati,
                kdvOran = x.KdvOran,
                satılanAdet = x.SatılanAdet,
                olusturmaTarih = x.OlusturmaTarih

            }).ToList();
            return liste;
        }
        #endregion

        #region Ürün Oluştur
        [HttpPost]
        [Route("api/urunolustur")]
        public Sonuc UrunOlustur(UrunOlusturModel model)
        {
            if (_urunDB.tblUrunlers.Count(s => s.UrunAdi == model.urunAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Ürün Kayıtlı Tekrar Kayıt Edilemez!";
                return sonuc;
            }

            tblUrunler urun = new tblUrunler();
            urun.KategoriID = model.kategoriID;
            urun.MarkaID = model.markaID;
            urun.UrunAdi = model.urunAdi;
            urun.UrunAciklama = model.urunAciklama;
            urun.ListeGorsel = model.ListeGorsel;
            urun.GelisFiyati = model.GelisFiyati;
            urun.SatisFiyati = model.SatisFiyati;
            urun.KdvOran = model.KdvOran;
            urun.SatılanAdet = model.SatılanAdet;
            urun.OlusturmaTarih = DateTime.Now;

            _urunDB.tblUrunlers.Add(urun);
            _urunDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Ürün Oluşturuldu";
            return sonuc;
        }
        #endregion

        #region Ürün Düzenle
        [HttpPut]
        [Route("api/urunduzenle/{urunID}")]
        public Sonuc UrunDuzenle(UrunDuzenleModel model)
        {
            tblUrunler urunGetir = _urunDB.tblUrunlers.FirstOrDefault(s => s.UrunID == model.urunID);
            if (urunGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Ürün Bulunamado";
                return sonuc;
            }

            urunGetir.KategoriID = model.kategoriID;
            urunGetir.MarkaID = model.markaID;
            urunGetir.UrunAdi = model.urunAdi;
            urunGetir.UrunAciklama = model.urunAciklama;
            urunGetir.ListeGorsel = model.ListeGorsel;
            urunGetir.GelisFiyati = model.GelisFiyati;
            urunGetir.SatisFiyati = model.SatisFiyati;
            urunGetir.KdvOran = model.KdvOran;
            urunGetir.SatılanAdet = model.SatılanAdet;
            _urunDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Ürün Güncellendi";
            return sonuc;
        }
        #endregion

        #region Ürün Sil
        [HttpDelete]
        [Route("api/urunsil/{urunID}")]
        public Sonuc UrunSil(int urunID)
        {
            tblUrunler urunGetir = _urunDB.tblUrunlers.FirstOrDefault(s => s.UrunID == urunID);
            if (urunGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Ürün Bulunamadı";
                return sonuc;
            }

            if (_urunDB.tblSepets.Count(s => s.UrunID == urunID) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Ürün Bir Sepete Ekli. Silinemez !";
                return sonuc;
            }

            _urunDB.tblUrunlers.Remove(urunGetir);
            _urunDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Ürün Silindi";
            return sonuc;
        }
        #endregion

        #region Ürün Getir
        [HttpGet]
        [Route("api/urunbyıd/{urunID}")]
        public tblUrunler UrunById(int urunID)
        {
            tblUrunler urunGetir = _urunDB.tblUrunlers.FirstOrDefault(s => s.UrunID == urunID);
            return urunGetir;
        }
        #endregion

        #region Favori Liste
        [HttpGet]
        [Route("api/favorilistele")]
        public List<FavoriListeModel> FavoriListele()
        {
            List<FavoriListeModel> liste = _urunDB.tblUrunFavoris.Select(x => new FavoriListeModel()
            {
                favoriID = x.FavoriID,
                uyeID = x.UyeID,
                ipNumarası = x.IpNumarası,
                urunID = x.UrunID

            }).ToList();
            return liste;

        }
        #endregion

        #region Favori Item Getir - Favori
        [HttpGet]
        [Route("api/favoriurunlerbyfavoriid/{favoriID}")]
        public tblUrunFavori FavoriUrunlerByFavoriID(int favoriID)
        {
            tblUrunFavori favoriItemGetir = _urunDB.tblUrunFavoris.FirstOrDefault(s => s.FavoriID == favoriID);
            return favoriItemGetir;
        }
        #endregion

        #region Favori Item Getir - UyeID
        [HttpGet]
        [Route("api/favoriurunlerbyuyeid/{uyeID}")]
        public tblUrunFavori FavoriUrunlerByUyeID(int uyeID)
        {
            tblUrunFavori favoriItemGetir = _urunDB.tblUrunFavoris.FirstOrDefault(s => s.UyeID == uyeID);
            return favoriItemGetir;
        }
        #endregion

        #region Favori Item Getir - Ip Numarası
        [HttpGet]
        [Route("api/favoriurunlerbyuyeid/{ipNumarası}")]
        public tblUrunFavori FavoriUrunlerByIpNumarasiID(string ipNumarası)
        {
            tblUrunFavori favoriItemGetir = _urunDB.tblUrunFavoris.FirstOrDefault(s => s.IpNumarası == ipNumarası);
            return favoriItemGetir;
        }
        #endregion

    }

}
