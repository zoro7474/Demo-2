
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MvcRestaurant.Models.Entity
{

using System;
    using System.Collections.Generic;
    
public partial class TBLYEMEK
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public TBLYEMEK()
    {

        this.TBLHAREKET = new HashSet<TBLHAREKET>();

    }


    public int ID { get; set; }

    public string AD { get; set; }

    public Nullable<byte> KATEGORI { get; set; }

    public Nullable<int> SEF { get; set; }

    public Nullable<int> UCRET { get; set; }

    public Nullable<bool> DURUM { get; set; }

    public string Resim { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TBLHAREKET> TBLHAREKET { get; set; }

    public virtual TBLKATAGORI TBLKATAGORI { get; set; }

    public virtual TBLSEF TBLSEF { get; set; }

}

}
