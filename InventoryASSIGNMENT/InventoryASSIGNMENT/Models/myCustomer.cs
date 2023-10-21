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

    public partial class myCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public myCustomer()
        {
            this.MyOrders = new HashSet<MyOrder>();
        }
        [Required]
        public int cus_id { get; set; }
        [Required(ErrorMessage = "Give first name")]
        [StringLength(10, ErrorMessage = "Not exceed 10 Characters")]
        public string fname { get; set; }
        [Required(ErrorMessage = "Give last name")]
        [StringLength(10, ErrorMessage = "Not exceed 10 Characters")]
        public string lname { get; set; }
        [Required]
        public string gender { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z][-_.a-zA-Z0-9]*@gmail.com$",
            ErrorMessage = "Please enter a valid Gmail email address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Provide your phone number it is compulsory")]
        public string tel { get; set; }
        [Required(ErrorMessage = "Mandatory,Provide your Address")]
        public string address { get; set; }
        public Nullable<System.DateTime> cdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyOrder> MyOrders { get; set; }
    }
}
