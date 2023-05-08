using e_Ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static e_Ticaret.Models.ViewModel.Uye;

namespace e_Ticaret.Auth
{
    public class UyeServis
    {
        ShopDBEntities db = new ShopDBEntities();
        public UyeModel UyeOturumAc(string email, string sifre)
        {
            UyeModel uye = db.tblUyelers.Where(s => s.Email == email && s.Sifre == sifre).Select(x => new UyeModel()
            {
                uyeID = x.UyeID,
                adSoyad = x.AdSoyad,
                email = x.Email,
                adres = x.Adres,
                sifre = x.Sifre,
                admin = x.Admin
            }).FirstOrDefault();
            return uye;
        }
    }
}