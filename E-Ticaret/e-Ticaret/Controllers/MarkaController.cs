using e_Ticaret.Models;
using e_Ticaret.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static e_Ticaret.Models.ViewModel.Marka;

namespace e_Ticaret.Controllers
{
    public class MarkaController : ApiController
    {
        ShopDBEntities _markaDB = new ShopDBEntities();
        Sonuc sonuc = new Sonuc();

        #region Marka Liste
        [HttpGet]
        [Route("api/markalistele")]
        public List<MarkaListeModel> MarkaListele()
        {
            List<MarkaListeModel> liste = _markaDB.tblMarkalars.Select(x => new MarkaListeModel()
            {
                markaID = x.MarkaID,
                markaAdi = x.MarkaAdi

            }).ToList();
            return liste;
        }
        #endregion

        #region Marka Oluştur
        [HttpPost]
        [Route("api/markaolustur")]
        public Sonuc MarkaOlustur(MarkaOlusturModel model)
        {
            if (_markaDB.tblMarkalars.Count(s => s.MarkaAdi == model.markaAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu Marka Kayıtlı Tekrar Kayıt Edilemez!";
                return sonuc;
            }

            tblMarkalar marka = new tblMarkalar();
            marka.MarkaAdi = model.markaAdi;

            _markaDB.tblMarkalars.Add(marka);
            _markaDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Marka Oluşturuldu";
            return sonuc;
        }
        #endregion

        #region Marka Getir
        [HttpGet]
        [Route("api/markabyid/{markaID}")]
        public tblMarkalar MarkaById(int markaID)
        {
            tblMarkalar markaGetir = _markaDB.tblMarkalars.FirstOrDefault(s => s.MarkaID == markaID);
            return markaGetir;
        }
        #endregion

        #region Marka Düzenle
        [HttpPut]
        [Route("api/markaduzenle")]
        public Sonuc MakraDuzenle(MarkaGuncelleModel model)
        {
            tblMarkalar markaGetir = _markaDB.tblMarkalars.FirstOrDefault(s => s.MarkaID == model.markaID);
            if (markaGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Marka Bulunamadı !";
                return sonuc;
            }
            markaGetir.MarkaAdi = model.markaAdi;
            _markaDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Marka Düzenlendi!";
            return sonuc;
        }
        #endregion

        #region Marka Sil
        [HttpDelete]
        [Route("api/markasil/{markaid}")]
        public Sonuc MarkaSil(int markaID)
        {
            tblMarkalar markaGetir = _markaDB.tblMarkalars.FirstOrDefault(s => s.MarkaID == markaID);
            if (markaGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Marka Bulunamadı!";
                return sonuc;
            }

            if (_markaDB.tblUrunlers.Count(s => s.MarkaID == markaID) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu markaya tanımlı ürünler bulunuyor. Silinemez !";
                return sonuc;
            }
            _markaDB.tblMarkalars.Remove(markaGetir);
            _markaDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Marka Silindi";
            return sonuc;
        }
        #endregion

    }
}
