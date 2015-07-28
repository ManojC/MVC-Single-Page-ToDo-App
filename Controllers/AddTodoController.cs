using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class AddTodoController : Controller
    {
        //
        // GET: /Add/

        public List<ToDo> Data
        {
            get { return Session["data"] as List<ToDo>; }
        }

        public ActionResult AddTodo(ToDo toDo)
        {
            return View(toDo ?? new ToDo());
        }

    }
}
