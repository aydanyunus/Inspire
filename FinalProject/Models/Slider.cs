//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Slider
    {
        public int Id { get; set; }
        public string Background_img { get; set; }
        public string Title { get; set; }
        public string Written_date { get; set; }
        public Nullable<int> View_Count { get; set; }
        public Nullable<int> Category1_id { get; set; }
        public Nullable<int> Category2_id { get; set; }
    
        public virtual SliderCategory SliderCategory { get; set; }
        public virtual SliderCategory SliderCategory1 { get; set; }
    }
}
