using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Ticaret.Models.ViewModel
{
    public class Sepet
    {
        public class SepetUrunAtModel
        {
            public int uyeID { get; set; }
            public string ipNumarası { get; set; }
            public int urunID { get; set; }
        }
        public class SepetListeModel
        {
            public int sepetID { get; set; }
            public int? uyeID { get; set; }
            public string ipNumarası { get; set; }
            public int? urunID { get; set; }
        }
    }
}