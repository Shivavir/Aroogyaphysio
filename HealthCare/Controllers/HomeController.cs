using HealthCare.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace HealthCare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Define the path to the JSON file in the App_Data folder
            string filePath = Server.MapPath("~/App_Data/projectDetails.json");

            // Read the JSON file
            string json = System.IO.File.ReadAllText(filePath);

            // Deserialize JSON into ProjectViewModel
            ProjectViewModel model = JsonConvert.DeserializeObject<ProjectViewModel>(json);

            // Pass the model to the view
            return View(model);
        }
        //google app password key
        //milx ijlx ntpl mjvy
        [HttpPost]
        public ActionResult SubmitContactForm(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string recipientEmail = "anandcktd41@gmail.com"; // To
                    string senderEmail = "arogyaphysiotherapyweb@gmail.com"; // From
                    string subject = "New Contact Form Arogya physiotherapy and slimming centre Web";

                    string messageBody = $@"
                        <p><strong>Name:</strong> {model.Name}</p>
                        <p><strong>Email:</strong> {model.Email}</p>
                        <p><strong>Phone:</strong> {model.Phone}</p>
                        <p><strong>Address:</strong> {model.City}</p>";

                    // Configure the SMTP client for Gmail
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(senderEmail, "milx ijlx ntpl mjvy");
                        smtp.EnableSsl = true;
                        // Create the email message
                        MailMessage mail = new MailMessage
                        {
                            From = new MailAddress(senderEmail, "Aaroyagya Clinic and Physiotherapy Center"),
                            Subject = subject,
                            Body = messageBody,
                            IsBodyHtml = true
                        };
                        mail.To.Add(recipientEmail);

                        // Send the email
                        smtp.Send(mail);
                        ViewBag.Message = "Your details were successfully submitted!";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"An error occurred: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Error = "Please fill out all required fields.";
            }
            //return View("Index");
            // Repopulate the ProjectViewModel to pass it to the view
            string filePath = Server.MapPath("~/App_Data/projectDetails.json");
            string json = System.IO.File.ReadAllText(filePath);
            ProjectViewModel projectModel = JsonConvert.DeserializeObject<ProjectViewModel>(json);

            // Return the Index view with the project model
            //return View("Index", projectModel);
            return RedirectToAction("Index");
        }


    public ActionResult GetPhoneNumber()
        {
            // Simulate getting the phone number from a database or config
            string phoneNumber = "+91 9670702912";
            return Json(new { PhoneNumber = phoneNumber }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}