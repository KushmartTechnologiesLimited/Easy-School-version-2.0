//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESIS
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int user_id { get; set; }
        public System.DateTime created { get; set; }
        public System.DateTime lastupdate { get; set; }
        public bool status { get; set; }
    
        public virtual user_role user_role { get; set; }
    }
}