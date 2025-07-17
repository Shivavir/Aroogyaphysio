using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourFitnessAlly.Models
{
    public class ContactFormModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Goal { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool AllowMessage { get; set; }
    }
}