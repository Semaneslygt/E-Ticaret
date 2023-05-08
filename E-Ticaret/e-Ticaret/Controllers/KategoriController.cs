using e_Ticaret.Models;
using e_Ticaret.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static e_Ticaret.Models.ViewModel.Kategori;

namespace e_Ticaret.Controllers
{
    public class KategoriController : ApiController
    {
        ShopDBEntities _kategoriDB = new ShopDBEntities();
        Sonuc sonuc = new Sonuc();

        #region Kategori Listesi
        [HttpGet]
        [Route("api/kategorilistele")]
        public List<KategoriListeModel> KategoriListele()
        {
            List<KategoriListeModel> liste = _kategoriDB.tblKategorilers.Select(x => new KategoriListeModel()
            {
                kategoriID = x.KategoriID,
                kategoriAdi = x.KategoriAdi

            }).ToList();
            return liste;
        }
        #endregion

        #region Kategori Oluştur
        [HttpPost]
        [Route("api/kategoriolustur")]
        public Sonuc KategoriOlustur(KategoriOlusturModel model)
        {
            if (_kategoriDB.tblKategorilers.Count(s => s.KategoriAdi == model.kategoriAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Kategori Kayıtlı Tekrar Kayıt Edilemez!";
                return sonuc;
            }

            tblKategoriler kategori = new tblKategoriler();
            kategori.KategoriAdi = model.kategoriAdi;

            _kategoriDB.tblKategorilers.Add(kategori);
            _kategoriDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Oluşturuldu";

            return sonuc;
        }
        #endregion

        #region Kategori Getir
        [HttpGet]
        [Route("api/kategorigetir/{kategoriID}")]
        public tblKategoriler KategoriGetir(int kategoriID)
        {
            tblKategoriler kategoriGetir = _kategoriDB.tblKategorilers.FirstOrDefault(s => s.KategoriID == kategoriID);
            return kategoriGetir;
        }
        #endregion

        #region Kategori Düzenle
        [HttpPut]
        [Route("api/kategoriduzenle")]
        public Sonuc KategoriDuzenle(KategoriGuncelleModel model)
        {
            tblKategoriler kategoriGetir = _kategoriDB.tblKategorilers.FirstOrDefault(s => s.KategoriID == model.kategoriID);
            if (kategoriGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Bulunamadı";
                return sonuc;
            }

            kategoriGetir.KategoriAdi = model.kategoriAdi;
            _kategoriDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi";
            return sonuc;
        }

        #endregion

        #region Kategori Sil
        [HttpDelete]
        [Route("api/kategorisil/{kategoriID}")]
        public Sonuc KategoriSil(int kategoriID)
        {
            tblKategoriler kategoriGetir = _kategoriDB.tblKategorilers.FirstOrDefault(s => s.KategoriID == kategoriID);
            if (kategoriGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori Bulunamadı";
                return sonuc;
            }

            _kategoriDB.tblKategorilers.Remove(kategoriGetir);
            _kategoriDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi";
            return sonuc;
        }
        #endregion

    }
}
