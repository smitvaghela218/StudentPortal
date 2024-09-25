﻿using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddStudentViewModel
    { 
        public string name { get; set; }
        
        public string email { get; set; }
        public bool Subscribed { get; set; }

    }
}
