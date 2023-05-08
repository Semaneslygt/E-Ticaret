using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Ticaret.Models.ViewModel
{
    public class Uye
    {
        public class UyeModel
        {
            public int uyeID { get; set; }
            public string adSoyad { get; set; }
            public string email { get; set; }
            public string sifre { get; set; }
            public string adres { get; set; }
            public bool? admin { get; set; }
        }
        public class UyeOlusturModel
        {
            public string adSoyad { get; set; }
            public string email { get; set; }
            public string sifre { get; set; }
            public string adres { get; set; }
            public bool admin { get; set; }
        }




    }

}