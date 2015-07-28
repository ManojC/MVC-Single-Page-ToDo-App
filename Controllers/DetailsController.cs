using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class DetailsController : Controller
    {
        //
        // GET: /Details/
        public List<ToDo> Data
        {
            get { return Session["data"] as List<ToDo>; }
        }

        public ActionResult Details(long id)
        {
            return View(Data.FirstOrDefault(data => data.Id == id));
        }

    }
}
