//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group_21_Company_selfservice_tool.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admin
    {
        public string Admin_ID { get; set; }
        public string Admin_First_Name { get; set; }
        public string Admin_Last_Name { get; set; }
        public string Contact_Phone { get; set; }
        public string Contact_Mail { get; set; }
        public string user { get; set; }
    
        public virtual User User1 { get; set; }
    }
}