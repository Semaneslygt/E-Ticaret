using e_Ticaret.Models;
using e_Ticaret.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static e_Ticaret.Models.ViewModel.Uye;

namespace e_Ticaret.Controllers
{
    public class UyeController : ApiController
    {
        ShopDBEntities _uyeDB = new ShopDBEntities();
        Sonuc sonuc = new Sonuc();

        #region Üye Listesi
        [HttpGet]
        [Route("api/uyelistele")]
        public List<UyeModel> UyeListele()
        {
            List<UyeModel> liste = _uyeDB.tblUyelers.Select(x => new UyeModel()
            {
                uyeID = x.UyeID,
                adSoyad = x.AdSoyad,
                email = x.Email,
                sifre = x.Sifre,
                adres = x.Adres,
                admin = x.Admin
            }).ToList();
            return liste;
        }
        #endregion

        #region Üye Oluştur
        [HttpPost]
        [Route("api/uyeolustur")]
        public Sonuc UyeOlustur(UyeOlusturModel model)
        {
            if (_uyeDB.tblUyelers.Count(s => s.Email == model.email) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıtlı kullanıcı tekrar kayıt edilemez!";
                return sonuc;
            }

            tblUyeler uye = new tblUyeler();
            uye.AdSoyad = model.adSoyad;
            uye.Email = model.email;
            uye.Sifre = model.sifre;
            uye.Adres = model.adres;
            uye.Admin = model.admin;

            _uyeDB.tblUyelers.Add(uye);
            _uyeDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Oluşturuldu";

            return sonuc;
        }
        #endregion

        #region Üye Getir
        [HttpGet]
        [Route("api/uyegetir/{uyeID}")]
        public UyeModel UyeGetir(int uyeID)
        {
            UyeModel kayit = _uyeDB.tblUyelers.Where(s => s.UyeID == uyeID).Select(x => new UyeModel()
            {
                uyeID = x.UyeID,
                adSoyad = x.AdSoyad,
                email = x.Email,
                sifre = x.Sifre,
                adres = x.Adres,
                admin = x.Admin
            }).FirstOrDefault();
            return kayit;
        }
        #endregion

        #region Üye Düzenle
        [HttpPut]
        [Route("api/uyeduzenle")]
        public Sonuc UyeDuzenle(UyeModel model)
        {
            tblUyeler uyeGetir = _uyeDB.tblUyelers.FirstOrDefault(s => s.UyeID == model.uyeID);
            if (uyeGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Bulunamadı";
                return sonuc;
            }

            uyeGetir.AdSoyad = model.adSoyad;
            uyeGetir.Email = model.email;
            uyeGetir.Sifre = model.sifre;
            uyeGetir.Adres = model.adres;
            uyeGetir.Admin = model.admin;
            _uyeDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Güncellendi";
            return sonuc;
        }

        #endregion

        #region Uye Sil
        //[Authorize(Roles = "Admin")]
        [Authorize]
        [HttpDelete]
        [Route("api/uyesil/{uyeID}")]
        public Sonuc UyeSil(int uyeID)
        {
            tblUyeler uyeSil = _uyeDB.tblUyelers.FirstOrDefault(s => s.UyeID == uyeID);
            if (uyeSil == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye Bulunamadı";
                return sonuc;
            }

            _uyeDB.tblUyelers.Remove(uyeSil);
            _uyeDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Silindi";
            return sonuc;
        }
        #endregion

    }
}
