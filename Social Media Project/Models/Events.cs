﻿namespace Social_Media_Project.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public string ?Content { get; set; }
        public string ?Email { get; set; }
      //  public string Image { get; set; }
        public int IsActive { get; set; }
      //  public int IsApproved { get; set; }
    }
}
