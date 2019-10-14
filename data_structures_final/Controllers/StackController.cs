using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace data_structures_final.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        
        

        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;
            return View();
        }

        //Adding one to the stack
        public ActionResult AddOne()
        {
            myStack.Push("<p hidden>" + "New Entry " + (myStack.Count + 1) + "</p>");
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        //Adding 2000 using a for loop to push to the stack
        public ActionResult AddHugeList()
        {
            myStack.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("<p hidden>" + "New Entry " + (myStack.Count + 1) + "</p>");
            }
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        //Displaying the stack
        public ActionResult Display()
        {
            foreach (string item in myStack)
            {
                ViewBag.MyStack += item.Replace("<p hidden>", "<p>");
                ViewBag.MyStack += item.Replace("<button hidden>", "<>");
            }
            return View("Index");
        }

        //Delete from the stack
        public ActionResult Delete()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
                ViewBag.MyStack = myStack;
            }
            else
            {
                ViewBag.MyStack = " <p>Add Items to the Stack!</p>";
            }
        

        return View("Index");
        }

        //Clear from the Stack
        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.MyStack = "<p>Add Items to the Stack!</p>";
            return View("Index");
        }

        //Search from the Stack
        public ActionResult Search()
        {
            if (myStack.Count > 0)
            {
                string FindMe = "New Entry 15";
                string Found = "Found";
                string NotFound = "Not Found";
                ViewBag.Time = NotFound;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();
                foreach(string item in myStack)
                {
                    if (item.Contains(FindMe))
                    {
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.StopWatch = ts;
                        ViewBag.Time = Found;
                    }
                    else
                    {
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.StopWatch = ts;
                    }

                } 
                sw.Stop();

            }
            return View("Search");
        }
    }
}