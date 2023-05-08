using e_Ticaret.Models;
using e_Ticaret.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static e_Ticaret.Models.ViewModel.Sepet;

namespace e_Ticaret.Controllers
{
    public class SepetController : ApiController
    {
        ShopDBEntities _sepetDB = new ShopDBEntities();
        Sonuc sonuc = new Sonuc();

        #region Sepet Liste
        [HttpGet]
        [Route("api/sepetlistele")]
        public List<SepetListeModel> SepetListele()
        {
            List<SepetListeModel> liste = _sepetDB.tblSepets.Select(x => new SepetListeModel()
            {
                sepetID = x.SepetID,
                uyeID = x.UyeID,
                ipNumarası = x.IpNumarası,
                urunID = x.UrunID

            }).ToList();
            return liste;
        }
        #endregion

        #region Sepet Item Getir - SepetID
        [HttpGet]
        [Route("api/sepeturunlerbysepetid/{sepetID}")]
        public tblSepet SepetUrunlerBySepetID(int sepetID)
        {
            tblSepet sepetItemGetir = _sepetDB.tblSepets.FirstOrDefault(s => s.SepetID == sepetID);
            return sepetItemGetir;
        }
        #endregion

        #region Sepet Item Getir - UyeID
        [HttpGet]
        [Route("api/sepeturunlerbyuyeid/{uyeID}")]
        public tblSepet SepetUrunlerByUyeID(int uyeID)
        {
            tblSepet sepetItemGetir = _sepetDB.tblSepets.FirstOrDefault(s => s.UyeID == uyeID);
            return sepetItemGetir;
        }
        #endregion

        #region Sepet Item Getir - Ip Numarası
        [HttpGet]
        [Route("api/sepeturunlerbyuyeid/{ipNumarası}")]
        public tblSepet SepetUrunlerByIpNumarasiID(string ipNumarası)
        {
            tblSepet sepetItemGetir = _sepetDB.tblSepets.FirstOrDefault(s => s.IpNumarası == ipNumarası);
            return sepetItemGetir;
        }
        #endregion

        #region Sepete Ürün At
        [HttpPost]
        [Route("api/sepeteurunat")]
        public Sonuc SepeteUrunAt(SepetUrunAtModel model)
        {
            if (_sepetDB.tblUrunlers.FirstOrDefault(x => x.UrunID == model.urunID) != null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Ürün Bulunamadı";
                return sonuc;
            }

            tblSepet sepet = new tblSepet();
            sepet.UyeID = model.uyeID;
            sepet.IpNumarası = model.ipNumarası;
            sepet.UrunID = model.urunID;

            _sepetDB.tblSepets.Add(sepet);
            _sepetDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Sepete Ürün Atıldı";

            return sonuc;
        }
        #endregion

        #region Sepet Item Sil
        [HttpDelete]
        [Route("api/sepeturunsil/{sepetID}")]
        public Sonuc SepetUrunSil(int sepetID)
        {
            tblSepet sepetItemGetir = _sepetDB.tblSepets.FirstOrDefault(s => s.SepetID == sepetID);
            if (sepetItemGetir == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Sepet Detayı Bulunamadı";
                return sonuc;
            }

            _sepetDB.tblSepets.Remove(sepetItemGetir);
            _sepetDB.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Sepet Detayı Silindi";
            return sonuc;
        }
        #endregion

    }
}
