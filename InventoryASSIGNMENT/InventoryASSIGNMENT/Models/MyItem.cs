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

    public partial class MyItem
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Add ID item")]
        public string id_item { get; set; }
        public string itname { get; set; }
        [Required(ErrorMessage ="Please provide Quantity")]
        public Nullable<int> qty { get; set; }
        [Required(ErrorMessage ="Enter Sold Quantity")]
        public Nullable<double> sold_qty { get; set; }
        [Required (ErrorMessage ="Enter cost price")]
        public Nullable<double> cost_price { get; set; }
        [Required(ErrorMessage = "Enter sold price")]
        public Nullable<double> sales_price { get; set; }
        public string manufacturer { get; set; }
        [Required(ErrorMessage = "Mandatory,Provide your Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Provide your Telephone")]
        public string tel { get; set; }
        public Nullable<int> cat_id { get; set; }
        public Nullable<int> user_id { get; set; }
    
        public virtual MyCategory MyCategory { get; set; }
        public virtual MyUser MyUser { get; set; }
    }
}
