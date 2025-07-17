using YourFitnessAlly.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System.Collections.Generic;

namespace YourFitnessAlly.Controllers
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
                    string recipientEmail = "yogini@yourfitnessally.com"; // To
                    string senderEmail = "arogyaphysiotherapyweb@gmail.com"; // From
                    string subject = "New Contact Submission - Your Fitness Ally";

                    string messageBody = $@"
                        <h3>Contact Form Details</h3>
                <p><strong>Name:</strong> {model.Name}</p>
                <p><strong>Age:</strong> {model.Age}</p>
                <p><strong>Goal:</strong> {model.Goal}</p>
                <p><strong>Mobile:</strong> {model.Mobile}</p>
                <p><strong>Email:</strong> {model.Email}</p>
                <p><strong>Allow Message:</strong> {(model.AllowMessage ? "Yes" : "No")}</p>";


                    // Configure the SMTP client for Gmail
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(senderEmail, "milxijlxntplmjvy");
                        smtp.EnableSsl = true;
                        // Create the email message
                        MailMessage mail = new MailMessage
                        {
                            From = new MailAddress(senderEmail, "Your Fitness Ally Website"),
                            Subject = subject,
                            Body = messageBody,
                            IsBodyHtml = true
                        };
                        mail.To.Add(recipientEmail);

                        // Send the email
                        smtp.Send(mail);
                        ViewBag.Message = "Your details were successfully submitted!";
                    }
                    return Json(new { success = true }); // ✅ Return success JSON
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"An error occurred: {ex.Message}";
                    return Json(new { success = false, error = ex.Message }); // ✅ Return error info

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
            //return RedirectToAction("Index");
            return Json(new { success = false, error = "Invalid form data." }); // ✅ Return validation error

        }


        public ActionResult GetPhoneNumber()
        {
            string jsonPath = HostingEnvironment.MapPath("~/App_Data/projectDetails.json");

            // 2. Read the JSON file
            string json = System.IO.File.ReadAllText(jsonPath);

            // 3. Deserialize into the model
            ProjectViewModel model = JsonConvert.DeserializeObject<ProjectViewModel>(json);

            // 4. Get the phone number (use null check to avoid crash)
            string phoneNumber = model?.Contact?.Mobile ?? "Not Available";

            // 5. Return as JSON
            return Json(new { PhoneNumber = phoneNumber }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            string jsonPath = HostingEnvironment.MapPath("~/App_Data/projectDetails.json");
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            ProjectViewModel model = JsonConvert.DeserializeObject<ProjectViewModel>(jsonData);
            return View(model);
        }
        
        public ActionResult Privacy()
        {
            string jsonPath = HostingEnvironment.MapPath("~/App_Data/projectDetails.json");
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            ProjectViewModel model = JsonConvert.DeserializeObject<ProjectViewModel>(jsonData);
            return View(model);
        }

        public ActionResult Contact()
        {
            string jsonPath = HostingEnvironment.MapPath("~/App_Data/projectDetails.json");
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            ProjectViewModel model = JsonConvert.DeserializeObject<ProjectViewModel>(jsonData);
            return View(model);
        }

    }
}