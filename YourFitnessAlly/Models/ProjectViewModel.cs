using System.Collections.Generic;

namespace YourFitnessAlly.Models
{
    public class ProjectViewModel
    {
        public string AppName { get; set; }
        public Details Details { get; set; }
        public List<GalleryItem> Gallery { get; set; }
        public Contact Contact { get; set; }
        public SocialLinks SocialLinks { get; set; }
        public CopyrightInfo Copyright { get; set; }
    }

    public class Details
    {
        public string Title { get; set; }
    }

    public class GalleryItem
    {
        public string Image { get; set; }
    }

    public class Contact
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
    }

    public class SocialLinks
    {
        public string Instagram { get; set; }
    }

    public class CopyrightInfo
    {
        public string YourFitnessAlly { get; set; }
        public string FlutxTechnology { get; set; }
    }
}
