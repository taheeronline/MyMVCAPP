//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMVCApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class CostCenter
    {
        public int ID { get; set; }
        public string CostCenter1 { get; set; }
        public Nullable<int> ProjectID { get; set; }
    
        public virtual Project Project { get; set; }
    }
}