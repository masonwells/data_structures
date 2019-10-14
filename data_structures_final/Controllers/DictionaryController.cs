using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace data_structures_final.Controllers
{
    public class DictionaryController : Controller
    {
        //intialize variable
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        static int iCount = new int();


        // GET: Dictioanry
        public ActionResult Index()
        {
            ViewBag.myDictionary = myDictionary;
            return View();
        }

        //Adding one to the Dictionary
        public ActionResult AddOne()
        {
            myDictionary.Add(++iCount, "New Entry " + (myDictionary.Count + 1));
            ViewBag.myDictionary = myDictionary;
            return View("Index");
        }

        //Adding 2000 using a for loop to push to the Dictionary
        public ActionResult AddHugeList()
        {
            myDictionary.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add(i,"New Entry " + (myDictionary.Count + 1));
            }

         
            return View("Index");
        }

        //Displaying the Dictionary
        public ActionResult Display()
        {
            foreach (KeyValuePair<int, string> item in myDictionary)
            {
                ViewBag.myDictionary += "<p>" + item.Value + "</p>";
            }


            return View("DisplayDict");
        }

        //Delete from the Dictionary
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

        //Clear from the Dictionary
        public ActionResult Clear()
        {
            //clear the dictionary
            myDictionary.Clear();
            ViewBag.myDictionary = "<p>Add Items to the Dictionary!</p>";
            return View("Index");
        }

        //Search from the Dictionary
        public ActionResult Search()
        {
            if (myDictionary.Count > 0)
            {
                //intialize stop watch variables
                string FindMe = "New Entry 15";
                string Found = "Found";
                string NotFound = "Not Found";
                ViewBag.DicTime = NotFound;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();
                foreach (KeyValuePair<int, string> item in myDictionary)
                {
                    //if the value is found stop the watch and record the time
                    if (item.Value == FindMe)
                    {
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.DicStopWatch = ts;
                        ViewBag.DicTime = Found;
                    }
                    else
                    {
                        //keep track of the values 
                        TimeSpan ts = sw.Elapsed;
                        ViewBag.DicStopWatch = ts;
                    }

                }
                //stop the watch afterwards in case the value is not found
                sw.Stop();

            }
            //go to the view search dictionary to see the results of the test
            return View("SearchDict");
        }
    }
}