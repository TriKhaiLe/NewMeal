//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserHistory
    {
        public int UserID { get; set; }
        public int FoodID { get; set; }
        public Nullable<int> Meal { get; set; }
        public Nullable<System.DateTime> eatDate { get; set; }
    
        public virtual Food Food { get; set; }
        public virtual FUser FUser { get; set; }
    }
}
