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

    public partial class MyOrder
    {
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage ="Enter Order Name")]
        public string order_name { get; set; }
        [Required (ErrorMessage ="Provide Quantity")]
        public Nullable<int> qty { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<System.DateTime> due_date { get; set; }
        [Required(ErrorMessage ="Add Status")]
        public string status { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> cus_id { get; set; }
        public string password { get; set; }
    
        public virtual myCustomer myCustomer { get; set; }
        public virtual MyUser MyUser { get; set; }
    }
}
