using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class ProjectViewModel
    {
        public string AppName { get; set; }
        public string Copyright { get; set; }
        public Details Details { get; set; }
        public List<Service> Services { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public SocialLinks SocialLinks { get; set; }
    }

    public class Details
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }

    public class Service
    {
        public string Image { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }

    public class SocialLinks
    {
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
    }

}