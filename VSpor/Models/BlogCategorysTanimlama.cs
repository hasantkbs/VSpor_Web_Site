﻿namespace VSporMVC.Models
{
    public class BlogCategorysTanimlama
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TanimlamaList> List{ get; set; }
    }
    public class TanimlamaList
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
