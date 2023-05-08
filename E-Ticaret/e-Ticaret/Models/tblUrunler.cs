//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace e_Ticaret.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUrunler()
        {
            this.tblSepets = new HashSet<tblSepet>();
            this.tblUrunFavoris = new HashSet<tblUrunFavori>();
        }
    
        public int UrunID { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public Nullable<int> MarkaID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public string ListeGorsel { get; set; }
        public Nullable<int> Stok { get; set; }
        public Nullable<decimal> GelisFiyati { get; set; }
        public Nullable<decimal> SatisFiyati { get; set; }
        public Nullable<int> KdvOran { get; set; }
        public Nullable<int> SatılanAdet { get; set; }
        public Nullable<System.DateTime> OlusturmaTarih { get; set; }
        public Nullable<System.DateTime> GuncellemeTarih { get; set; }
    
        public virtual tblKategoriler tblKategoriler { get; set; }
        public virtual tblMarkalar tblMarkalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSepet> tblSepets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUrunFavori> tblUrunFavoris { get; set; }
    }
}