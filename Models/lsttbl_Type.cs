//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc4App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class lsttbl_Type
    {
        public lsttbl_Type()
        {
            this.lsttbl_Group = new HashSet<lsttbl_Group>();
        }
    
        public int TypeId { get; set; }
        public string Descrip { get; set; }
    
        public virtual ICollection<lsttbl_Group> lsttbl_Group { get; set; }
    }
}
