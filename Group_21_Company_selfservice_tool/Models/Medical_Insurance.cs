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
    
    public partial class Medical_Insurance
    {
        public string Insurance_ID { get; set; }
        public string Insurance_Name { get; set; }
        public string Insurance_Type { get; set; }
        public string Coverage_Limit { get; set; }
        public string Employee { get; set; }
    
        public virtual Employee Employee1 { get; set; }
    }
}
