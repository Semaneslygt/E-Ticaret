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
    
    public partial class urun_Foto_Bilgisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urun_Foto_Bilgisi()
        {
            this.Urun_Bilgisi = new HashSet<Urun_Bilgisi>();
        }
    
        public string urun_Foto_Urun_Id { get; set; }
        public string urun_Foto_data { get; set; }
        public string urun_Foto_Uzanti { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun_Bilgisi> Urun_Bilgisi { get; set; }
    }
}
