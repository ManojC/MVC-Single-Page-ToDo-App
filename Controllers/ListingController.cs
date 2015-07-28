using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class ListingController : Controller
    {
        //
        // GET: /Default1/

        public List<ToDo> Data
        {
            get { return Session["data"] as List<ToDo>; }
        }

        public ActionResult Listing()
        {
            if (Session["data"] == null)
                Session["data"] = new List<ToDo>()
            {
                new ToDo()
                {
                    Id = 1,
                    Description = "description1",
                    MailTo = "mchalode1@tavisca.com",
                    Priority = 4,
                    Title = "title1"
                },
                new ToDo()
                {
                    Id = 2,
                    Description = "description2",
                    MailTo = "mchalode2@tavisca.com",
                    Priority = 1,
                    Title = "title2"
                },
                new ToDo()
                {
                    Id = 3,
                    Description = "description3",
                    MailTo = "mchalode3@tavisca.com",
                    Priority = 3,
                    Title = "title3"
                },
                new ToDo()
                {
                    Id = 4,
                    Description = "description4",
                    MailTo = "mchalode4@tavisca.com",
                    Priority = 5,
                    Title = "title4"
                }
            };
            return View(Data);
        }

        public ActionResult DeleteTodo(long id)
        {
            var itemToBeDeleted = Data.SingleOrDefault(item => item.Id == id);
            if (itemToBeDeleted != null)
                Data.Remove(itemToBeDeleted);
            return RedirectToAction("Listing", "Listing", Data);
        }

        [HttpPost]
        public ActionResult AddTodo(ToDo toDo)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Listing", "Listing", Data);

            //update
            if (toDo.Id > 0)
            {
                var itemToBeUpdated = Data.SingleOrDefault(item => item.Id == toDo.Id);
                if (itemToBeUpdated != null)
                {
                    Data.Remove(itemToBeUpdated);

                    itemToBeUpdated.Title = toDo.Title;
                    itemToBeUpdated.Description = toDo.Description;
                    itemToBeUpdated.MailTo = toDo.MailTo;
                    itemToBeUpdated.Priority = toDo.Priority;

                    Data.Add(itemToBeUpdated);
                }
                return RedirectToAction("Listing", "Listing", Data);
            }

            //add new
            toDo.Id = Data.Last().Id + 1;
            Data.Add(toDo);
            return RedirectToAction("Listing", "Listing", Data);
        }

        public ActionResult EditToDo(long id)
        {
            var itemToBeEdited = Data.SingleOrDefault(item => item.Id == id);
            if (itemToBeEdited != null)
                return RedirectToAction("AddTodo", "AddTodo", itemToBeEdited);
            return RedirectToAction("Listing", "Listing", Data);
        }
    }
}
