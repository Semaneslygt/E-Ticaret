using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Ticaret.Models.ViewModel
{
    public class Kategori
    {
        public class KategoriListeModel
        {
            public int kategoriID { get; set; }
            public string kategoriAdi { get; set; }
        }
        public class KategoriOlusturModel
        {
            public string kategoriAdi { get; set; }
        }
        public class KategoriGuncelleModel
        {
            public int kategoriID { get; set; }
            public string kategoriAdi { get; set; }
        }
    }
}