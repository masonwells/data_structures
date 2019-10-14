using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace data_structures_final.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        static int iCount = new int();


        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.myDictionary = myDictionary;
            return View();
        }

        //Adding one to the stack
        public ActionResult AddOne()
        {
            myDictionary.Add(++iCount, "New Entry " + (myDictionary.Count + 1));
            ViewBag.myDictionary = myDictionary;
            return View("Index");
        }

        //Adding 2000 using a for loop to push to the stack
        public ActionResult AddHugeList()
        {
            myDictionary.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add(i,"New Entry " + (myDictionary.Count + 1));
            }

         
            return View("Index");
        }

        //Displaying the stack
        public ActionResult Display()
        {
            foreach (KeyValuePair<int, string> item in myDictionary)
            {
                ViewBag.myDictionary += "<p>" + item.Value + "</p>";
            }


            return View("DisplayDict");
        }

        //Delete from the stack
        public ActionResult Delete()
        {
            if (myDictionary.Count > 0)
            {
                myDictionary.Remove(myDictionary.Keys.First());
                ViewBag.myDictionary = myDictionary;
            }
            else
            {
                ViewBag.myDictionary = " <p>Add Items to the Dictionary!</p>";
            }


            return View("Index");
        }

        //Clear from the Stack
        public ActionResult Clear()
        {
            myDictionary.Clear();
            ViewBag.myDictionary = "<p>Add Items to the Dictionary!</p>";
            return View("Index");
        }

        //Search from the Stack
        public ActionResult Search()
        {
            if (myDictionary.Count > 0)
            {
                string FindMe = "New Entry 15";
                string Found = "Found";
                string NotFound = "Not Found";
                ViewBag.DicTime = NotFound;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();
                foreach (KeyValuePair<int, string> item in myDictionary)
                {
                    if (item.Value == FindMe)
                    {
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.DicStopWatch = ts;
                        ViewBag.DicTime = Found;
                    }
                    else
                    {
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.DicStopWatch = ts;
                    }

                }
                sw.Stop();

            }
            return View("SearchDict");
        }
    }
}