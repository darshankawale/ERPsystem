//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERPsystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class report
    {
        public int report_id { get; set; }
        public string type { get; set; }
        public Nullable<System.DateTime> period_start { get; set; }
        public Nullable<System.DateTime> period_end { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string file_path { get; set; }
    }
}
