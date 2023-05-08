using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_Ticaret.Models.ViewModel
{
    public class Marka
    {
        public class MarkaOlusturModel
        {
            public string markaAdi { get; set; }
        }
        public class MarkaGuncelleModel
        {
            public int markaID { get; set; }
            public string markaAdi { get; set; }
        }
        public class MarkaListeModel
        {
            public int markaID { get; set; }
            public string markaAdi { get; set; }
        }
    }
}