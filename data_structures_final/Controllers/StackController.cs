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
        static Stack<string> tempStack = new Stack<string>();

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
                ViewBag.MyStack += item.Replace("<p hidden>","<p>");
            }
            return View("Index");
        }

        //Delete from the stack
       public ActionResult Delete()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
            } 
            else
            {
                return View("Index");
            }
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        //Clear from the Stack
        public ActionResult Clear()
        {
            myStack.Clear();
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        //Search from the Stack
        public ActionResult Search()
        {
            if(myStack.Count > 0)
            {
                string stringSearch = "New Entry 15";
                string Found = "Found";
                string NotFound = "Not Found";
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                ViewBag.Status = NotFound;
                //loop to do all the work
                foreach (string item in myStack)
                {
                    if (item.Contains(stringSearch))
                    {
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.Status = Found;
                        ViewBag.StopWatch = ts;
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