using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SamMorganWeddingPortal.Models;

namespace SamMorganWeddingPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult People()
        {
            return View();
        }

        public ActionResult Accommodations()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Registry()
        {
            return View();
        }

        public ActionResult GuestBook()
        {
            var model = new GuestBookModel
            {
                GuestBookEntries = this.GetGuestBookEntries()
            };

            return View(model);
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

        public ActionResult PostGuestBookEntry(GuestBookModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.AddNewGuestBookEntry(model.NewEntry);
            }

            return this.RedirectToAction("GuestBook");
        }

        private void AddNewGuestBookEntry(GuestBookEntryModel newEntry)
        {
            using (var sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CoreDbConnectionString"].ConnectionString))
            {
                var sqlCommand = new SqlCommand("INSERT INTO [CoreDb].[dbo].[GuestBookPosts] ([Author], [Message], [DatePosted]) VALUES (@AUTHOR, @MESSAGE, @DATEPOSTED)", sqlConn);
                sqlCommand.Parameters.AddWithValue("@AUTHOR", newEntry.Author);
                sqlCommand.Parameters.AddWithValue("@MESSAGE", newEntry.Message);
                sqlCommand.Parameters.AddWithValue("@DATEPOSTED", DateTime.Now);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        private List<GuestBookEntryModel> GetGuestBookEntries()
        {
            var guestBookEntries = new List<GuestBookEntryModel>();

            using (var sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CoreDbConnectionString"].ConnectionString))
            {          
                var sqlCommand = new SqlCommand("SELECT [Author], [Message], [DatePosted] FROM [CoreDb].[dbo].[GuestBookPosts] ORDER BY [DatePosted] DESC", sqlConn);
                sqlCommand.Connection.Open();
                var sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    guestBookEntries.Add(new GuestBookEntryModel()
                    {
                        Author = sqlReader.GetString(0),
                        Message = sqlReader.GetString(1),
                        DatePosted = sqlReader.GetDateTime(2)
                    });
                }
            }

            return guestBookEntries;

            //return new List<GuestBookEntryModel>
            //{
            //    new GuestBookEntryModel
            //    {
            //        Author = "Sam",
            //        DatePosted = new DateTime(2014, 11, 7),
            //        Message = "Congrats on the engagement! See you in a year!"
            //    },
            //    new GuestBookEntryModel
            //    {
            //        Author = "Morgan",
            //        DatePosted = new DateTime(2014, 9, 28),
            //        Message = "Woohoo! He finally put a ring on it!"
            //    },
            //    new GuestBookEntryModel
            //    {
            //        Author = "Kevin",
            //        DatePosted = new DateTime(2014, 12, 17),
            //        Message = "This is a HUGE mistake guys! Please don't do this!"
            //    },
            //    new GuestBookEntryModel
            //    {
            //        Author = "Morgan",
            //        DatePosted = new DateTime(2014, 9, 28),
            //        Message = "Woohoo! He finally put a ring on it!"
            //    },
            //    new GuestBookEntryModel
            //    {
            //        Author = "Morgan",
            //        DatePosted = new DateTime(2014, 9, 28),
            //        Message = "Woohoo! He finally put a ring on it!"
            //    },
            //    new GuestBookEntryModel
            //    {
            //        Author = "Kevin",
            //        DatePosted = new DateTime(2014, 12, 17),
            //        Message =
            //            "This is a HUGE mistake guys! Please don't do this! Lots and lots and lots and lots and lots and lots and lots and lots and lots and lots of words."
            //    },
            //    new GuestBookEntryModel
            //    {
            //        Author = "Sam",
            //        DatePosted = new DateTime(2014, 11, 7),
            //        Message = "Congrats on the engagement! See you in a year!"
            //    },
            //    new GuestBookEntryModel
            //    {
            //        Author = "Morgan",
            //        DatePosted = new DateTime(2014, 9, 28),
            //        Message = "Woohoo! He finally put a ring on it!"
            //    },
            //};
        }
    }
}