//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryASSIGNMENT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MyCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyCategory()
        {
            this.MyItems = new HashSet<MyItem>();
        }
        [Required]
        public int cat_id { get; set; }
        [Required(ErrorMessage ="Please provide category name.")]
        [StringLength(10,ErrorMessage ="Category name should not exceed 7 character.")]
        public string cat_name { get; set; }
        [Required(ErrorMessage = "Add category comment.")]
        [StringLength(15, ErrorMessage = "Add your valueable comment.")]
        public string cat_comment { get; set; }
        public Nullable<System.DateTime> cat_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyItem> MyItems { get; set; }
    }
}